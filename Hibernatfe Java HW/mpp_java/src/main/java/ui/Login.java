package ui;


import com.google.gson.Gson;
import domain.*;


import javax.swing.*;
import javax.swing.table.DefaultTableCellRenderer;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.*;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Vector;

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
                validate_login(userField.getText(), passwordField.getText());

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
                try {
                    //todo; Impl user logic
                    String serverAddress = "127.0.0.1";
                    int port = 8888;
                    Socket socket = new Socket(serverAddress, port);
                    LoginLogger userLogged = new LoginLogger(activeUser);
                    ServerMessage message1 = new ServerMessage(userLogged);

                    ObjectOutputStream out = new ObjectOutputStream(socket.getOutputStream());
                    ObjectInputStream in = new ObjectInputStream(socket.getInputStream());

                    out.writeObject(message1);
                    createListener(in);

                    //  con.close();
                } catch (IOException e1) {
                    throw new RuntimeException(e1);
                }
                System.exit(0);

            }//BUN
        });

        searchInitializeButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    String serverAddress = "127.0.0.1";
                    int port = 8888;
                    Socket socket = new Socket(serverAddress, port);
                    GetLookupTable blankTable = new GetLookupTable(new DefaultTableModel().getDataVector(), locationField.getText(),
                            Integer.parseInt(timeStartField.getText()), Integer.parseInt(timeEndField.getText()));
                    ServerMessage message1 = new ServerMessage(blankTable);

                    ObjectOutputStream out = new ObjectOutputStream(socket.getOutputStream());
                    ObjectInputStream in = new ObjectInputStream(socket.getInputStream());

                    out.writeObject(message1);
                    createListener(in);
                } catch (UnknownHostException ex) {
                    throw new RuntimeException(ex);
                } catch (IOException ex) {
                    throw new RuntimeException(ex);
                }
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
                String serverAddress = "127.0.0.1";
                try {
                    int port = 8888;
                    Socket socket = new Socket(serverAddress, port);
                    String id_trip = tripIdField.getText();
                    String name = nameFIeld.getText();
                    String phone_number = pnField.getText();
                    int num_tickets = Integer.parseInt(ntickField.getText());
                    GetReservationTable blankTable = new GetReservationTable(new DefaultTableModel().getDataVector(), id_trip, name, phone_number, num_tickets);
                    ServerMessage message1 = new ServerMessage(blankTable);

                    ObjectOutputStream out = new ObjectOutputStream(socket.getOutputStream());
                    ObjectInputStream in = new ObjectInputStream(socket.getInputStream());

                    out.writeObject(message1);
                    createListener(in);

                } catch (UnknownHostException ex) {
                    throw new RuntimeException(ex);
                } catch (IOException ex) {
                    throw new RuntimeException(ex);
                }
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
    public void refreshUsers(){
        try {
            String serverAddress = "127.0.0.1";
            int port = 8888;
            Socket socket = new Socket(serverAddress, port);
            LoginLogger userLogged = new LoginLogger();
            ServerMessage message1 = new ServerMessage(userLogged);

            ObjectOutputStream out = new ObjectOutputStream(socket.getOutputStream());
            ObjectInputStream in = new ObjectInputStream(socket.getInputStream());

            out.writeObject(message1);
            createListener(in);

            //  con.close();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public void refreshTripLookup() {
        try {
            //todo; Working method
            String serverAddress = "127.0.0.1";
            int port = 8888;
            Socket socket = new Socket(serverAddress, port);
            GetTripsTable blankTable = new GetTripsTable(new DefaultTableModel().getDataVector());
            ServerMessage message1 = new ServerMessage(blankTable);

            ObjectOutputStream out = new ObjectOutputStream(socket.getOutputStream());
            ObjectInputStream in = new ObjectInputStream(socket.getInputStream());

            out.writeObject(message1);
            createListener(in);

            //  con.close();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    private void validate_login(String user, String password) {


        String serverAddress = "127.0.0.1";
        int port = 8888;
        try {
            Socket socket = new Socket(serverAddress, port);
            System.out.println("Connected to server.");

            LoginInfo loginInfo = new LoginInfo(user, password);
            ServerMessage message1 = new ServerMessage(loginInfo);

            ObjectOutputStream out = new ObjectOutputStream(socket.getOutputStream());
            ObjectInputStream in = new ObjectInputStream(socket.getInputStream());

            System.out.println(message1);
            out.writeObject(message1);
            createListener(in);

//            out.close();
//            in.close();
//            socket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
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
            GetReservationTable table = gson.fromJson(serverMessage.body, GetReservationTable.class);
            DefaultTableModel model = new DefaultTableModel();
            String[] help = {"id", "available_tickets"};
            Vector<String> columnID = new Vector<>(Arrays.asList(help));
            model.setDataVector(table.dataVector, columnID); //cand dai setDataVector nu mai faci nimic cu modelul
            table2.setModel(model);
            table2.repaint();
            table2.revalidate();
            table2.isShowing();
        } else if ("class domain.GetLookupTable".equals((serverMessage.type))) {
            GetLookupTable table = gson.fromJson(serverMessage.body, GetLookupTable.class);
            DefaultTableModel modelll = new DefaultTableModel();
            String[] help = {"id", "id_agency", "id_company", "location", "departure_time", "ticket_price", "available_tickets"};
            Vector<String> columns = new Vector<>(Arrays.asList(help));
            modelll.setDataVector(table.dataVector, columns);
            tableSearch.setModel(modelll);
            tableSearch.repaint();
            tableSearch.revalidate();
            tableSearch.isShowing();

        } else if ("class java.util.ArrayList".equals(serverMessage.type)) {
            List<String> loggedInUsers = gson.fromJson(serverMessage.body,ArrayList.class);
            DefaultListModel listModel = new DefaultListModel();
            for (int i = 0; i < loggedInUsers.size(); i++)
            {
                listModel.addElement(loggedInUsers.get(i));
            }
            usersList.setModel(listModel);
        }
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


