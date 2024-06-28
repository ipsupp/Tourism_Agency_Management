package domain;

import java.io.Serializable;

public class GetReservationTable implements Serializable {
    //public Vector<Vector> dataVector;
    public String id;
    public String name;
    public String phone_number;
    public int number_tickets;

    public GetReservationTable( String id_trip, String name, String phone_number, int no_tickets) {
        this.id = id_trip;
        this.name = name;
        this.phone_number = phone_number;
        this.number_tickets = no_tickets;
    }

//    public GetReservationTable(Vector<Vector> dataVector){
//        this.dataVector = dataVector;
//    }

    public GetReservationTable() {
    }
}
