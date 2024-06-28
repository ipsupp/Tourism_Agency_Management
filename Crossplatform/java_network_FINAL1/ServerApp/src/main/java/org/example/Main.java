package org.example;

import repository.*;
import service.Service;
import service.SocketController;

import java.io.FileInputStream;
import java.io.IOException;
import java.util.Properties;

public class Main {
    public static void main(String[] args) {
        Properties props = new Properties();
        try{
            props.load(new FileInputStream("db.config"));
        }catch(IOException e){
            e.printStackTrace();
        }
        Properties serverProps = new Properties();
        try{
            props.load(new FileInputStream("app.properties"));
        }catch(IOException e){
            e.printStackTrace();
        }
        AgencyRepo ags = new AgencyRepo(props);
        EmployeeRepo emps = new EmployeeRepo(props);
        TCompanyRepo comps = new TCompanyRepo(props);
        TripRepo trips = new TripRepo(props);
        ReservationRepo ress = new ReservationRepo(props);
        Service serv = new Service(ags,emps,comps,trips,ress);
        SocketController socketController = new SocketController(serv,serverProps);
        socketController.listenForClients();
        //serv.start();
    }
}