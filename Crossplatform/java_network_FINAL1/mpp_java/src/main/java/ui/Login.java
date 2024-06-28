package ui;


import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import domain.Trip;
import domain.*;


import javax.swing.*;
import javax.swing.table.DefaultTableCellRenderer;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.*;
import java.net.HttpURLConnection;
import java.net.Socket;
import java.net.URL;
import java.net.UnknownHostException;
import java.util.*;
import java.util.List;

public class Login extends Thread {
    private String activeUser = null;
    private JPanel bg;
    private JPanel Login;
    private JPanel TravelDetails;
    private JPanel Reservation;
    private JPanel TripLookup;
    private JTextField userField;
    private JPasswordField passwordField;
    private JLabel userLabel;
    private JLabel pswdLabel;
    private JButton loginButton;
    private JTable table1;
    private JPanel InvalidLogin;
    private JLabel labelloginfailed;
    private JButton searchOptionButton;
    private JButton reservationOptionButton;
    private JButton logoutButton;
    private JButton searchInitializeButton;
    private JTable tableSearch;
    private JTextField locationField;
    private JTextField timeStartField;
    private JTextField timeEndField;
    private JLabel Label;
    private JButton backButton;
    private JTextField tripIdField;
    private JButton reservationInitializeButton;
    private JTable table2;
    private JTextField nameFIeld;
    private JTextField pnField;
    private JTextField ntickField;
    private JButton backToTDfromRez;
    private JButton seeUsersBtn;
    private JPanel ActiveUsers;
    private JList usersList;
    private JButton backButtonUsers;
    private JButton refreshButton;

    public Login() {
        loginButton.addActionListener(new ActionListener() {

            @Override
            public void actionPerformed(ActionEvent e) {
                if (validate_login(userField.getText(), passwordField.getText())) {
                    activeUser = userField.getText();
                    bg.removeAll();
                    bg.add(TravelDetails);
                    refreshTripLookup();
                    bg.repaint();
                    bg.revalidate();
                } else {
                    JOptionPane.showMessageDialog(Login,
                            "Invalid Credentials!",
                            "Error",
                            JOptionPane.ERROR_MESSAGE);
                }

            }
        });
        searchOptionButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                bg.removeAll();
                bg.add(TripLookup);
                bg.repaint();
                bg.revalidate();

                TripLookup.isShowing();
                TripLookup.isVisible();
                TripLookup.repaint();
                TripLookup.revalidate();
            }//BUN
        });
        logoutButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                bg.removeAll();
                bg.repaint();
                bg.revalidate();

                LoginLogger userLogged = new LoginLogger(activeUser);
                ServerMessage message1 = new ServerMessage(userLogged);
                ServerMessage response = sendReceive(message1);


                System.exit(0);

            }//BUN
        });

        searchInitializeButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                GetLookupTable blankTable = new GetLookupTable( locationField.getText(),
                        Integer.parseInt(timeStartField.getText()), Integer.parseInt(timeEndField.getText()));
                ServerMessage message = new ServerMessage(blankTable);
                ServerMessage response = sendReceive(message);
                Gson gson = new Gson();
                Vector<Trip> tripVector = gson.fromJson(response.body, new TypeToken<Vector<Trip>>(){}.getType());
                DefaultTableModel model = new DefaultTableModel();
                String[] help = {"id", "location", "departure_time", "ticket_price", "available_tickets"};
                Vector<String> columnID = new Vector<>(Arrays.asList(help));
                Vector<Vector> tripsTable = new Vector<>();

                for (int i = 0; i < tripVector.size(); i++) {
                    Vector<String> tripRow = new Vector<>();
                    tripRow.add(
                            tripVector.get(i).getId()
                    );
                    tripRow.add(
                            tripVector.get(i).location
                    );
                    tripRow.add(
                            String.valueOf(tripVector.get(i).departure_time)
                    );
                    tripRow.add(
                            String.valueOf(tripVector.get(i).price)
                    );
                    tripRow.add(
                            String.valueOf(tripVector.get(i).available_seats)
                    );
                    tripsTable.add(tripRow);
                }
                model.setDataVector(tripsTable, columnID);
                tableSearch.setModel(model);
                tableSearch.repaint();
                tableSearch.revalidate();
                tableSearch.isShowing();
//                    ServerMessage message1 = new ServerMessage(blankTable);
//
//                    ObjectOutputStream out = new ObjectOutputStream(socket.getOutputStream());
//                    ObjectInputStream in = new ObjectInputStream(socket.getInputStream());
//
//                    out.writeObject(message1);
//                    createListener(in);
            }
        }); //BUN
        backButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {

                bg.removeAll();
                bg.add(TravelDetails);
//                refreshTripLookup();
                bg.repaint();
                bg.revalidate();
            }
        });//BUN
        reservationOptionButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                bg.removeAll();
                bg.add(Reservation);
                bg.repaint();
                bg.revalidate();

                Reservation.isShowing();
                Reservation.isVisible();
                Reservation.repaint();
                Reservation.revalidate();
            }
        });
        backToTDfromRez.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                nameFIeld.setText(null);
                tripIdField.setText(null);
                pnField.setText(null);
                ntickField.setText(null);

                bg.removeAll();
                bg.add(TravelDetails);
                bg.repaint();
                refreshTripLookup();
                bg.revalidate();

            }
        });

        //AICEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        reservationInitializeButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String id_trip = tripIdField.getText();
                String name = nameFIeld.getText();
                String phone_number = pnField.getText();
                int num_tickets = Integer.parseInt(ntickField.getText());

                GetReservationTable blankTable = new GetReservationTable(id_trip, name, phone_number, num_tickets);
                ServerMessage message = new ServerMessage(blankTable);
                ServerMessage response = sendReceive(message);
                Gson gson = new Gson();
                if (Objects.equals(response.type, "True")){
                    Vector<Trip> tripVector = gson.fromJson(response.body, new TypeToken<Vector<Trip>>(){}.getType());
                    DefaultTableModel model = new DefaultTableModel();
                    String[] help = {"id", "available_tickets"};
                    Vector<String> columnID = new Vector<>(Arrays.asList(help));
                    // model.setDataVector(tripVector.stream().map(trip -> {trip.getId(),trip.getAgency_id(),
                    //trip.getCompany_id(),trip.location,trip.departure_time,trip.ticket_price,trip.available_tickets}), columnID); //cand dai setDataVector nu mai faci nimic cu modelul
                    Vector<Vector> tripsTable = new Vector<>();
                    for (int i = 0; i < tripVector.size(); i++) {
                        Vector<String> tripRow = new Vector<>();
                        tripRow.add(
                                tripVector.get(i).getId()
                        );
                        tripRow.add(
                                String.valueOf(tripVector.get(i).available_seats)
                        );
                        tripsTable.add(tripRow);
                    }
                    model.setDataVector(tripsTable, columnID);
                    table2.setModel(model);
                    table2.repaint();
                    table2.revalidate();
                    table2.isShowing();
                }
                else {
                    JOptionPane.showMessageDialog(Login,
                            "Invalid Reservation!",
                            "Error",
                            JOptionPane.ERROR_MESSAGE);
                }



//                    ServerMessage message1 = new ServerMessage(blankTable);
//
//                    ObjectOutputStream out = new ObjectOutputStream(socket.getOutputStream());
//                    ObjectInputStream in = new ObjectInputStream(socket.getInputStream());

//                    out.writeObject(message1);
//                    createListener(in);

            }
        });
        seeUsersBtn.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                bg.removeAll();
                bg.add(ActiveUsers);
                bg.repaint();
                bg.revalidate();
                refreshUsers();
                ActiveUsers.isShowing();
                ActiveUsers.isVisible();
                ActiveUsers.repaint();
                ActiveUsers.revalidate();
            }
        });
        backButtonUsers.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                bg.removeAll();
                bg.add(TravelDetails);
                bg.repaint();
                bg.revalidate();

            }
        });
        refreshButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                refreshUsers();
            }
        });
    }

    public void refreshUsers() {
        LoginLogger userLogged = new LoginLogger();
        ServerMessage message1 = new ServerMessage(userLogged);
        ServerMessage response = sendReceive(message1);

        Gson jsonehe = new Gson();
        List<String> loggedInUsers = jsonehe.fromJson(response.body, ArrayList.class);
        DefaultListModel listModel = new DefaultListModel();
        for (int i = 0; i < loggedInUsers.size(); i++) {
            listModel.addElement(loggedInUsers.get(i));
        }
        usersList.setModel(listModel);

    }

    public void refreshTripLookup() {
        GetTripsTable blankTable = new GetTripsTable(new DefaultTableModel().getDataVector());

        ServerMessage message = new ServerMessage(blankTable);
        ServerMessage response = sendReceive(message);
        Gson gson = new Gson();
        Vector<Trip> tripVector = gson.fromJson(response.body, new TypeToken<Vector<Trip>>(){}.getType());
        DefaultTableModel model = new DefaultTableModel();
        String[] help = {"id", "id_agency", "id_company", "location", "departure_time", "ticket_price", "available_tickets"};
        Vector<String> columnID = new Vector<>(Arrays.asList(help));
        // model.setDataVector(tripVector.stream().map(trip -> {trip.getId(),trip.getAgency_id(),
        //trip.getCompany_id(),trip.location,trip.departure_time,trip.ticket_price,trip.available_tickets}), columnID); //cand dai setDataVector nu mai faci nimic cu modelul
        Vector<Vector> tripsTable = new Vector<>();

        for (int i = 0; i < tripVector.size(); i++) {
            Vector<String> tripRow = new Vector<>();
            tripRow.add(
                    tripVector.get(i).getId()
            );
            tripRow.add(
                    tripVector.get(i).getAgency_id()
            );

            tripRow.add(
                    tripVector.get(i).getCompany_id()
            );
            tripRow.add(
                    tripVector.get(i).location
            );
            tripRow.add(
                    String.valueOf(tripVector.get(i).departure_time)
            );
            tripRow.add(
                    String.valueOf(tripVector.get(i).price)
            );
            tripRow.add(
                    String.valueOf(tripVector.get(i).available_seats)
            );
            tripsTable.add(tripRow);
        }
        model.setDataVector(tripsTable, columnID);
        table1.setModel(model);
        table1.setDefaultRenderer(Object.class, new DefaultTableCellRenderer() {
            @Override
            public Component getTableCellRendererComponent(JTable table, Object value, boolean isSelected,
                                                           boolean hasFocus, int row, int column) {
                Component c = super.getTableCellRendererComponent(table, value, isSelected, hasFocus, row, column);
                try {
                    if (table.getValueAt(row, 6).equals("0")) {
                        c.setBackground(Color.red);
                    } else {
                        c.setBackground(table.getBackground());
                    }
                    return c;
                } catch (ArrayIndexOutOfBoundsException e) {
                    System.err.println("Index OOB");
                    return c;
                }
            }
        });
        table1.repaint();
        table1.revalidate();
        table1.isShowing();
        //return boolData.status;
    }

    private ServerMessage sendReceive(ServerMessage message) {
        String serverAddress = "127.0.0.1";
        int port = 8888;
        String serverUrl = "http://" + serverAddress + ":" + port + "/";
        // Convert servermsg object to JSON
        Gson gson = new Gson();
        String json = gson.toJson(message);
        System.out.println(json);
        HttpURLConnection connection = null;
        try {
            //Create connection
            URL url = new URL(serverUrl);
            connection = (HttpURLConnection) url.openConnection();
            connection.setRequestMethod("POST");
            connection.setRequestProperty("Content-Type",
                    "application/x-www-form-urlencoded");

            connection.setRequestProperty("Content-Length",
                    Integer.toString(json.getBytes().length));
            connection.setRequestProperty("Content-Language", "en-US");

            connection.setUseCaches(false);
            connection.setDoOutput(true);

            //Send request
            DataOutputStream wr = new DataOutputStream(
                    connection.getOutputStream());
            wr.writeBytes(json);
            wr.close();

            //Get Response
            InputStream is = connection.getInputStream();
            BufferedReader rd = new BufferedReader(new InputStreamReader(is));
            StringBuffer response = new StringBuffer(); // or StringBuffer if Java version 5+
            String line;
            ServerMessage serverMessage = new ServerMessage();
            while ((line = rd.readLine()) != null) {
                response.append(line);
                response.append('\r');
                String reply = response.toString();
                serverMessage = gson.fromJson(reply, ServerMessage.class);
            }
            rd.close();
            return serverMessage;
            //  return response.toString();
        } catch (Exception e) {
            e.printStackTrace();
            //return null;
        } finally {
            if (connection != null) {
                connection.disconnect();
            }

        }
        return new ServerMessage();
    }

    private boolean validate_login(String user, String password) {

        LoginInfo loginInfo = new LoginInfo(user, password);
        ServerMessage message = new ServerMessage(loginInfo);
        ServerMessage response = sendReceive(message);
        Gson gson = new Gson();
        BoolData boolData = gson.fromJson(response.body, BoolData.class);
        return boolData.status;
    }

    public void initcomp() {
        JFrame frame = new JFrame("Login");
        frame.setContentPane(new Login().bg);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.pack();
        frame.setVisible(true);
    }//BUN

    private void createListener(ObjectInputStream in) {
        new Thread(() -> {
            try {
                reader(in);
            } catch (IOException | ClassNotFoundException e) {
                throw new RuntimeException(e);
            }
        }).start();
    }

    private void reader(ObjectInputStream in) throws IOException, ClassNotFoundException {
        ServerMessage serverMessage = (ServerMessage) in.readObject();
        Gson gson = new Gson();
        if ("class domain.BoolData".equals(serverMessage.type)) {
            BoolData boolData = gson.fromJson(serverMessage.body, BoolData.class);
            if (boolData.status) {
                activeUser = userField.getText();
                bg.removeAll();
                bg.add(TravelDetails);
                refreshTripLookup();
                bg.repaint();
                bg.revalidate();
            } else {
//                bg.removeAll();
//                bg.add(InvalidLogin);
//                bg.repaint();
//                bg.revalidate();
                JOptionPane.showMessageDialog(Login,
                        "Invalid Credentials!",
                        "Error",
                        JOptionPane.ERROR_MESSAGE);
            }
            return;
        } else if ("class domain.GetTripsTable".equals(serverMessage.type)) {
            GetTripsTable tripsTable = gson.fromJson(serverMessage.body, GetTripsTable.class);
            DefaultTableModel model = new DefaultTableModel();
            String[] help = {"id", "id_agency", "id_company", "location", "departure_time", "ticket_price", "available_tickets"};
            Vector<String> columnID = new Vector<>(Arrays.asList(help));
            model.setDataVector(tripsTable.dataVector, columnID); //cand dai setDataVector nu mai faci nimic cu modelul
            table1.setModel(model);
//            for(int row=0; row<table1.getRowCount();row++){
//                if(table1.getValueAt(row, 6).equals(0)){
//                    table1.setBackground(Color.white);
//                } else {
//                    table1.setBackground(table1.getBackground());
//                }
//
//            }
            // [{"id": 1, "id_agency", "id_company", "location", "departure_time", "ticket_price", "available_tickets"}, {}]
            table1.setDefaultRenderer(Object.class, new DefaultTableCellRenderer() {
                @Override
                public Component getTableCellRendererComponent(JTable table, Object value, boolean isSelected,
                                                               boolean hasFocus, int row, int column) {
                    Component c = super.getTableCellRendererComponent(table, value, isSelected, hasFocus, row, column);
                    try {
                        if (table.getValueAt(row, 6).equals(0.0)) {
                            c.setBackground(Color.red);
                        } else {
                            c.setBackground(table.getBackground());
                        }
                        return c;
                    } catch (ArrayIndexOutOfBoundsException e) {
                        System.err.println("Index OOB");
                        return c;
                    }
                }
            });
            table1.repaint();
            table1.revalidate();
            table1.isShowing();
        } else if ("class domain.GetReservationTable".equals((serverMessage.type))) {
//            GetReservationTable table = gson.fromJson(serverMessage.body, GetReservationTable.class);
//            DefaultTableModel model = new DefaultTableModel();
//            String[] help = {"id", "available_tickets"};
//            Vector<String> columnID = new Vector<>(Arrays.asList(help));
//            model.setDataVector(table.dataVector, columnID); //cand dai setDataVector nu mai faci nimic cu modelul
//            table2.setModel(model);
//            table2.repaint();
//            table2.revalidate();
//            table2.isShowing();
        } else if ("class domain.GetLookupTable".equals((serverMessage.type))) {

            GetLookupTable table = gson.fromJson(serverMessage.body, GetLookupTable.class);
            DefaultTableModel modelll = new DefaultTableModel();
            String[] help = {"id", "id_agency", "id_company", "location", "departure_time", "ticket_price", "available_tickets"};
            Vector<String> columns = new Vector<>(Arrays.asList(help));
        //    modelll.setDataVector(table.dataVector, columns);
//            tableSearch.setModel(modelll);
//            tableSearch.repaint();
//            tableSearch.revalidate();
//            tableSearch.isShowing();

        }
        //TODO DACA PUSCA PROBABIL AICI
//        else if ("class java.util.ArrayList".equals(serverMessage.type)) {
//            List<String> loggedInUsers = gson.fromJson(serverMessage.body, ArrayList.class);
//            DefaultListModel listModel = new DefaultListModel();
//            for (int i = 0; i < loggedInUsers.size(); i++) {
//                listModel.addElement(loggedInUsers.get(i));
//            }
//            usersList.setModel(listModel);
//        }
//            if ("Notify".equals(serverMessage.getResponseType())) {
//                System.out.println("New car was added!!!");
//                System.out.println(serverMessage.getCarDtoList().get(0));
//            } else if ("findAllCars".equals(serverMessage.getResponseType())) {
//                serverMessage.getCarDtoList().forEach(System.out::println);
//            } else if ("saveCar".equals(serverMessage.getResponseType())) {
//                System.out.println("Success!");
//            } else {
//                System.out.println("Unrecognised response type.");
//            }
    }
}


