package domain;

import java.io.Serializable;
import java.util.Vector;

public class GetReservationTable implements Serializable {
    public Vector<Vector> dataVector;
    public String id_trip;
    public String name;
    public String phone_number;
    public int no_tickets;

    public GetReservationTable(Vector<Vector> dataVector, String id_trip, String name, String phone_number, int no_tickets) {
        this.dataVector = dataVector;
        this.id_trip = id_trip;
        this.name = name;
        this.phone_number = phone_number;
        this.no_tickets = no_tickets;
    }

    public GetReservationTable(Vector<Vector> dataVector){
        this.dataVector = dataVector;
    }

    public GetReservationTable() {
    }
}
