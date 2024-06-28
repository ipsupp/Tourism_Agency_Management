package service;

import com.google.gson.Gson;
import domain.*;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.*;

public class SocketController {

    private static final Logger LOG = LogManager.getLogger(SocketController.class);

    private Service mainService;
    private ServerSocket serverSocket;
    private Map<Integer, ObjectOutputStream> portToSocketOutputStream = new HashMap<>();


    public SocketController(Service mainService, Properties properties) {
        this.mainService = mainService;
        serverSocket = createServerSocket(properties);
    }

    private ServerSocket createServerSocket(Properties properties) {
        try {
            String portString = properties.getProperty("server.port");
            return new ServerSocket(8888);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public void listenForClients() {
        while (true) {
            Socket clientSocket = acceptClient();
            new Thread(() -> {
                try {
                    processClient(clientSocket);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }).start();
        }
    }

    private void processClient(Socket clientSocket) throws IOException {
        ObjectInputStream in = new ObjectInputStream(clientSocket.getInputStream());
        ObjectOutputStream out = new ObjectOutputStream(clientSocket.getOutputStream());
        portToSocketOutputStream.put(clientSocket.getPort(), out);
        try {
            while (true) {
                ServerMessage serverMessage = readCommandFromClient(in);
                String requestType = serverMessage.type;
                Gson gson = new Gson();
                if ("class domain.LoginInfo".equals(requestType)) {
                    LoginInfo loginInfo = gson.fromJson(serverMessage.body,LoginInfo.class);
                    out.writeObject(new ServerMessage(mainService.HandleValidateLogin(loginInfo)));
                } else if ("class domain.GetTripsTable".equals(requestType)) {
                    GetTripsTable tripsTable = new GetTripsTable(mainService.HandleGetTripsTableData().getDataVector());
                    System.out.println("Sent Trips Table to user");
                    out.writeObject(new ServerMessage(tripsTable));
                }
                else if ("class domain.GetReservationTable".equals(requestType)) {
//                    GetReservationTable received = gson.fromJson(serverMessage.body,GetReservationTable.class);
//                    GetReservationTable tripsTable = new GetReservationTable(mainService.HandleReservationTable(received.id_trip,received.name,
//                            received.phone_number,received.no_tickets).getDataVector());
//                    System.out.println("Sent Reservation Table to user");
//                    out.writeObject(new ServerMessage(tripsTable));
                }
                else if ("class domain.GetLookupTable".equals(requestType)){
                    GetLookupTable received = gson.fromJson(serverMessage.body,GetLookupTable.class);
                    GetLookupTable tripsTable = new GetLookupTable(mainService.HandleLookupTable(received.location,received.time_start,
                            received.time_end).getDataVector());
                    System.out.println("Sent Lookup Table to user");
                    out.writeObject(new ServerMessage(tripsTable));
                } else if ("class domain.LoginLogger".equals(requestType)) {
                    LoginLogger logger = gson.fromJson(serverMessage.body,LoginLogger.class);
                    if(logger.onlineUser==null) {
                        out.writeObject(new ServerMessage(mainService.activeUsers));
                    }
                    else{
                        mainService.activeUsers.remove(logger.onlineUser);
                        System.out.println("User: "+logger.onlineUser+" logged out");
                        out.writeObject(new ServerMessage(mainService.activeUsers));
                    }
                }
            }
        } catch (Exception exception) {
            LOG.error("processClient - There has been an exception - {}", exception.getMessage());
            portToSocketOutputStream.remove(clientSocket.getPort()).close();
            in.close();
            clientSocket.close();
        }
    }

    private ServerMessage readCommandFromClient(ObjectInputStream in) {
        LOG.info("reading");
        try {
            return (ServerMessage) in.readObject();
        } catch (IOException | ClassNotFoundException e) {
            throw new RuntimeException(e);
        }
    }

    private Socket acceptClient() {
        try {
            return serverSocket.accept();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

//    private void notifyClients(CarDto carDto) {
//        for (ObjectOutputStream outputStream : portToSocketOutputStream.values()) {
//            new Thread(() -> {
//                try {
//                    notifyClient(outputStream, carDto);
//                } catch (IOException e) {
//                    throw new RuntimeException(e);
//                }
//            }).start();
//        }
//    }
//
//    private static void notifyClient(ObjectOutputStream outputStream, CarDto carDto) throws IOException {
//        outputStream.writeObject(new ResponseDto("Notify", "Success", List.of(carDto)));
//    }
}
