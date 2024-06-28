package repository;
import domain.Trip;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import repository.interfaces.ITripRepo;
import utils.jdbcUtils;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.Properties;

public class TripRepo implements ITripRepo{
    private jdbcUtils dbUtils;
    private static final Logger logger= LogManager.getLogger();


    public TripRepo(Properties props) {
        logger.info("Initializing TripDBRepository with properties: {} ",props);
        dbUtils=new jdbcUtils(props);
    }

    public int ticketsPerTripId(String id) throws SQLException {
        logger.traceEntry();
        Connection connection = dbUtils.getConnection();
        String command = "select * from Trip where id=?";
        PreparedStatement statement = connection.prepareStatement(command);
        statement.setString(1, id);
        try (ResultSet result = statement.executeQuery()) {
            if(result.next()) {
                String id_trip = result.getString("id");
                int available_tickets = result.getInt("available_tickets");
                if (Objects.equals(id, id_trip)) {
                    return available_tickets;
                }
            }
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
        return 0;
    }

   //
    public void updateTicketsTripId(int new_nr_tickets, String id) {
        Connection connection = dbUtils.getConnection();
        try{
            String command = "update Trip" +
                    " set available_tickets=? where id=?";
            PreparedStatement statement = connection.prepareStatement(command);
            statement.setInt(1, new_nr_tickets);
            statement.setString(2, id);
            statement.executeUpdate();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
        logger.traceExit();
    }

    @Override
    public List<Trip> find_by_location_time(String loc, int min, int max) {
        logger.traceEntry();
        Connection connection = dbUtils.getConnection();
        List<Trip> ts = new ArrayList<>();
        try {
            String command = "select * from Trip where location=?";
            PreparedStatement statement = connection.prepareStatement(command);
            statement.setString(1,loc);
            ResultSet result = statement.executeQuery();

            while (result.next()) {
                int dep_h = result.getInt("departure_time");
                String id = result.getString("id");
                String id_agency = result.getString("id_agency");
                String id_company = result.getString("id_company");
                float ticket_price = result.getFloat("ticket_price");
                int available_tickets = result.getInt("available_tickets");
                Trip t = new Trip(id, id_agency, id_company, loc, dep_h, ticket_price, available_tickets);

                if (Objects.equals(result.getString("location"), loc) & dep_h >= min & dep_h <=max)
                {
                    ts.add(t);
                }

            }

        } catch (SQLException e) {
            logger.error(e);
            throw new RuntimeException("Error: FindAll");
        }

        logger.traceExit();
        return ts;
    }

    @Override
    public List<Trip> findAll() {
        logger.traceEntry();
        Connection connection = dbUtils.getConnection();
        List<Trip> ts = new ArrayList<>();
        try {
            String command = "select * from Trip";
            PreparedStatement statement = connection.prepareStatement(command);
            try(ResultSet result = statement.executeQuery()){

                while (result.next()) {
                    int dep_h = result.getInt("departure_time");
                    String id = result.getString("id");
                    String id_agency = result.getString("id_agency");
                    String id_company = result.getString("id_company");
                    String loc = result.getString("location");
                    float ticket_price = result.getFloat("ticket_price");
                    int available_tickets = result.getInt("available_tickets");
                    Trip t = new Trip(id, id_agency, id_company, loc, dep_h,  ticket_price, available_tickets);
                    ts.add(t);
                }
            }
        } catch (SQLException e) {
            logger.error(e);
            throw new RuntimeException("Error: FindAll");
        }

        logger.traceExit();
        return ts;
    }

    @Override
    public void add(Trip elem) {
        logger.traceEntry("saving task{}", elem);
        Connection connection = dbUtils.getConnection();
        try(PreparedStatement preStmt = connection.prepareStatement("insert into " +
                "Trip(id, id_agency, id_company, location, departure_time,ticket_price," +
                "available_tickets) values (?,?,?,?,?,?,?)")) {
            preStmt.setString(1,elem.getId());
            // aici le las asa
            preStmt.setString(2,elem.getAgency_id());
            preStmt.setString(3, elem.getCompany_id());
            preStmt.setString(4,elem.getLocation());
            preStmt.setInt(5, elem.getDeparture_time());
            preStmt.setFloat(6,elem.getTicket_price());
            preStmt.setInt(7,elem.getAvailable_tickets());
            int result = preStmt.executeUpdate();
            logger.trace("Saved {} instances", result);
        } catch (SQLException e) {
            logger.error(e);
            throw new RuntimeException(e);
        }
        logger.traceExit();
    }

    @Override
    public Trip getTripById(String id) {
        logger.traceEntry();
        Connection connection = dbUtils.getConnection();
        try {
            String command = "select * from Trip where id=?";
            PreparedStatement statement = connection.prepareStatement(command);
            try(ResultSet result = statement.executeQuery()){
                statement.setString(1,id);
                while (result.next()) {
                    int dep_h = result.getInt("departure_time_hour");
                    String location = result.getString("location");
                    String id_agency = result.getString("id_agency");
                    String id_company = result.getString("id_company");
                    float ticket_price = result.getFloat("ticket_price");
                    int available_tickets = result.getInt("available_tickets");
                    Trip t = new Trip(id, id_agency, id_company, location, dep_h, ticket_price, available_tickets);
                    return t;

                }
            }
        } catch (SQLException e) {
            logger.error(e);
            throw new RuntimeException("Error: FindAll");
        }

        logger.traceExit();
        return null;
    }

    @Override
    public void update(String integer,int x) {
        Connection connection = dbUtils.getConnection();
        try{
            String command = "update Trip" +
                    " set available_tickets where id=?";
            PreparedStatement statement = connection.prepareStatement(command);
            statement.setInt(1, x );
            statement.setString(2, integer);
            statement.executeUpdate();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
        logger.traceExit();
    }

    @Override
    public void delete(String id) {
        Connection connection = dbUtils.getConnection();
        try (PreparedStatement statement = connection.prepareStatement("delete from Trip where id = ?")) {
            statement.setString(1, id);
            statement.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
        logger.traceExit();
    }
}
