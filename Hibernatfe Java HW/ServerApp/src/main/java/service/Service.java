package service;


import com.fasterxml.jackson.core.JsonProcessingException;
import com.google.gson.Gson;
import domain.*;
import repository.*;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.stream.Collectors;

public class Service extends Thread {
    BufferedReader in;
    PrintWriter out;
    Gson gson = new Gson();
    private AgencyRepo agency_repository;
    private EmployeeRepo employee_repository;
    private TCompanyRepo company_repository;
    private TripRepo trip_repository;
    private ReservationRepo reservation_repository;
    private ChatLogs chatlogs = new ChatLogs();
    public List<String> activeUsers = new ArrayList<String>();

    public Service(AgencyRepo ag, EmployeeRepo em, TCompanyRepo tc, TripRepo tr, ReservationRepo rs) {
        this.agency_repository = ag;
        this.employee_repository = em;
        this.company_repository = tc;
        this.trip_repository = tr;
        this.reservation_repository = rs;
    }


    //    public void HandleMessage(Socket socket, String message) throws IOException {
//    //DE REVIZIUT CLIPURILE PROFEI
//        // System.out.println("Received: " + message);
//        ServerMessage serverMessage = gson.fromJson(message,ServerMessage.class);
//        String type = serverMessage.type;
//        if(Objects.equals(type, "class domain.LoginInfo")){
//            LoginInfo loginInfo = gson.fromJson(serverMessage.body,LoginInfo.class);
//            HandleValidateLogin(loginInfo);
//        }
//
//    }
    public DefaultTableModel HandleGetTripsTableData() {
        DefaultTableModel model = new DefaultTableModel(new String[]{"id", "id_agency", "id_company", "location", "departure_time", "ticket_price", "available_tickets"}, 0);
        model.setRowCount(0);
        try {
            Class.forName("org.sqlite.JDBC");
            //    Connection con = DriverManager.getConnection("jdbc:sqlite:C:/Users/Ioana/Downloads/java_bfr_networking/java-uihalf working/mpp-java-lab/identifier.sqlite", "root", "");
            Connection con = DriverManager.getConnection("jdbc:sqlite:C:/Users/popov/OneDrive/Desktop/Hibernate Java HW/java_network_FINAL1/identifier.sqlite", "root", "");
            String sql = "select * from Trip";
            PreparedStatement pstmt = con.prepareStatement(sql);
            ResultSet rez = pstmt.executeQuery();
            while (rez.next()) {
                String id = rez.getString("id");
                String id_ag = rez.getString("id_agency");
                String id_com = rez.getString("id_company");
                String loc = rez.getString("location");
                int dep = rez.getInt("departure_time");
                float price = rez.getFloat("ticket_price");
                int available_tickets = rez.getInt("available_tickets");
                model.addRow(new Object[]{id, id_ag, id_com, loc, dep, price, available_tickets});
            }
            return model;
        } catch (SQLException e) {
            throw new RuntimeException(e);
        } catch (ClassNotFoundException e) {
            throw new RuntimeException(e);
        }
    }

    public DefaultTableModel HandleLookupTable(String location, int time_start, int time_end) throws ClassNotFoundException, SQLException {
        DefaultTableModel model2 = new DefaultTableModel(new String[]{"id", "id_agency", "id_company", "location", "departure_time", "ticket_price", "available_tickets"}, 0);
        String[] help = {"id", "id_agency", "id_company", "location", "departure_time", "ticket_price", "available_tickets"};
        model2.setColumnIdentifiers(help);
        model2.setRowCount(0);
        Class.forName("org.sqlite.JDBC");
        //       Connection con = DriverManager.getConnection("jdbc:sqlite:C:/Users/popov/IdeaProjects/java_network/identifier.sqlite", "root", "");

        Connection con = DriverManager.getConnection("jdbc:sqlite:C:/Users/popov/OneDrive/Desktop/Hibernate Java HW/java_network_FINAL1/identifier.sqlite", "root", "");
        String sql = "select * from Trip where location=? and departure_time between ? and ?";
        PreparedStatement pstmt = con.prepareStatement(sql);
        pstmt.setString(1, location);
        pstmt.setInt(2, time_start);
        pstmt.setInt(3, time_end);
        ResultSet rez = pstmt.executeQuery();
        while (rez.next()) {
            String id = rez.getString("id");
            String id_ag = rez.getString("id_agency");
            String id_com = rez.getString("id_company");
            int dep = rez.getInt("departure_time");
            float price = rez.getFloat("ticket_price");
            int available_tickets = rez.getInt("available_tickets");
            model2.addRow(new Object[]{id, id_ag, id_com, location, dep, price, available_tickets});
        }
        con.close();
        return model2;

    }

    public DefaultTableModel HandleReservationTable(String id, String name, String phone_number, int num_tickets) throws ClassNotFoundException, SQLException {
        DefaultTableModel model2 = new DefaultTableModel(new String[]{"id", "available_tickets"}, 0);
        String[] help = {"id", "available_tickets"};
        model2.setColumnIdentifiers(help);
        model2.setRowCount(0);
//        String id_trip = tripIdField.getText();
//        String name = nameFIeld.getText();
//        String phone_number = pnField.getText();
//        int num_tickets = Integer.parseInt(ntickField.getText());
        Class.forName("org.sqlite.JDBC");
        Connection con = DriverManager.getConnection("jdbc:sqlite:C:/Users/popov/OneDrive/Desktop/Hibernate Java HW/java_network_FINAL1/identifier.sqlite", "root", "");
        String sql = "select * from Trip where id=?";
        PreparedStatement pstmt = con.prepareStatement(sql);
        pstmt.setString(1, id);
        ResultSet rez = pstmt.executeQuery();
//                    System.out.println(rez.getInt(7));
        int available_tickets = rez.getInt("available_tickets");
        if (available_tickets >= num_tickets) {
            int new_ticket_number = available_tickets - num_tickets;
            String sql2 = "update Trip set available_tickets=? where id=?";
            PreparedStatement pstmt2 = con.prepareStatement(sql2);
            pstmt2.setInt(1, new_ticket_number);
            pstmt2.setString(2, id);
            pstmt2.executeUpdate();
            model2.addRow(new Object[]{id, new_ticket_number});

//                        tableSearch.setModel(model);
//                        tableSearch.repaint();
//                        tableSearch.revalidate();
//                        tableSearch.isShowing();
            con.close();
            return model2;
        } else {
            JOptionPane.showMessageDialog(new JOptionPane(),
                    "Invalid reservation!",
                    "Error",
                    JOptionPane.ERROR_MESSAGE);
            con.close();
            return null;
        }
    }

    public BoolData HandleValidateLogin(LoginInfo loginInfo) throws IOException {
        boolean isValid = ValidateLogin(loginInfo.username, loginInfo.password);
        BoolData boolData = new BoolData(isValid);
        if (isValid && !activeUsers.contains(loginInfo.username))
            activeUsers.add(loginInfo.username);
        System.out.println("Validating login for user: " + loginInfo.username + " with password: " + loginInfo.password + " -> " + isValid);
        return boolData;
    }

    public boolean ValidateLogin(String username, String password) {
        return employee_repository.user_validation(username, password);
    }
}
