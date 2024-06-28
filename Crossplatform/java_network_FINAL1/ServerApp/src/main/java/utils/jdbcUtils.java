package utils;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Properties;

public class jdbcUtils {
    private Properties jdbcProps;

    private static final Logger logger = LogManager.getLogger();

    public jdbcUtils(Properties props) {
        jdbcProps = props;

    }

    // private Connection instance = null;
    private Connection instance;


    private Connection getNewConnection() throws SQLException {
        logger.traceEntry();

        String url = jdbcProps.getProperty("jdbc.url");
        String user = jdbcProps.getProperty("jdbc.user");
        String pass = jdbcProps.getProperty("jdbc.pass");
        logger.info("trying to connect to database ... {}", url);
        logger.info("user: {}", user);
        logger.info("pass: {}", pass);
        Connection con;
        if (user != null && pass != null) {
            con = DriverManager.getConnection(url, user, pass);
        } else {
            con = DriverManager.getConnection(url);
        }
        return con;
    }

    public Connection getConnection() {

        Connection con = null;

        try {
            //con = DriverManager.getConnection("jdbc:sqlite:C:/Users/Ioana/IdeaProjects/mpp-java-lab/db.config", "root", "");

            Class.forName("org.sqlite.JDBC");
            con = DriverManager.getConnection("jdbc:sqlite:C:/Users/popov/Downloads/XPlatform/XPlatform/java_network_FINAL1/identifier.sqlite", "root", "");

        } catch (Exception ex) {
            System.out.print(ex.getMessage());

        }
        return con;

//        logger.traceEntry();
//        try {
//            if (instance == null || instance.isClosed())
//                instance = getNewConnection();
//
//        } catch (SQLException e) {
//            logger.error(e);
//            System.out.println("Error DB " + e);
//        }
//        logger.traceExit(instance);
//        return instance;
    }
}
