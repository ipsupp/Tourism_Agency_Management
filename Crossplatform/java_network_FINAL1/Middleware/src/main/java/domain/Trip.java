package domain;


import java.io.Serializable;

public class Trip implements Serializable {
    public String id;
    public String id_agency;
    public String id_company;
    public String location;
    public int departure_time;
    public double price;
    public int available_seats;
    public Trip() {
    }

    public Trip(String trip_id, String id_agency, String id_company, String location, int departure_time_hour, double ticket_price, int available_seats) {
        this.id = trip_id;
        this.id_agency = id_agency;
        this.id_company = id_company;
        this.location = location;
        this.departure_time = departure_time_hour;
        this.price= ticket_price;
        this.available_seats= available_seats;
    }


    public String getId_agency() {
        return id_agency;
    }

    public void setId_agency(String id_agency) {
        this.id_agency = id_agency;
    }

    public String getId_company() {
        return id_company;
    }

    public void setId_company(String id_company) {
        this.id_company = id_company;
    }

    public int getDeparture_time() {
        return departure_time;
    }

    public void setDeparture_time(int departure_time_hour) {
        this.departure_time = departure_time_hour;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getAgency_id() {
        return id_agency;
    }

    public void setAgency_id(String id) {
        this.id_agency = id;
    }

    public String getCompany_id() {
        return id_company;
    }

    public void setCompany_id(String id) {
        this.id_company = id;
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }


    public double getTicket_price() {
        return price;
    }

    public void setTicket_price(float ticket_price) {
        this.price= ticket_price;
    }

    public int getAvailable_tickets() {
        return available_seats;
    }

    public void setAvailable_seats(int available_seats) {
        this.available_seats = available_seats;
    }

    @Override
    public String toString() {
        return id + " " + location + " " +id_agency + " " + id_company + " " +
                departure_time  + " " + price+ " " +
                available_seats + '\n';
    }
}