package repository;
import domain.Employee;
import entities.EmployeeEntity;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.hibernate.Hibernate;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.query.Query;
import repository.interfaces.IEmployeeRepo;
import utils.HibernateUtil;
import utils.jdbcUtils;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.Properties;

public class EmployeeRepo implements IEmployeeRepo{

    private final jdbcUtils dbUtils;
    private static final Logger logger= LogManager.getLogger();


    public EmployeeRepo(Properties props) {
        logger.info("Initializing EmployeeDBRepository with properties: {} ",props);
        dbUtils=new jdbcUtils(props);
    }

    public boolean user_validation(String login_user, String login_pswd){
        SessionFactory sf = HibernateUtil.getSessionFactory();
        Session session = sf.openSession();
        session.beginTransaction();
        String hql = "SELECT e.id FROM EmployeeEntity e " +
                "WHERE e.login_user = :employee_user AND e.login_pswd = :employee_pswd";
        Query query = session.createQuery(hql);
        query.setParameter("employee_user",login_user);
        query.setParameter("employee_pswd",login_pswd);
        List results = query.list();
        session.close();
        if(!results.isEmpty()) return true;
        return false;
    }

    @Override
    public List<Employee> findAll() {
        SessionFactory sf = HibernateUtil.getSessionFactory();
        Session session = sf.openSession();
        session.beginTransaction();
        String hql = "FROM EmployeeEntity";
        Query query = session.createQuery(hql);
        List results = query.list();
        session.close();
        return results;
    }

    @Override
    public void add(Employee elem) {
        SessionFactory sf = HibernateUtil.getSessionFactory();
        Session session = sf.openSession();
        session.beginTransaction();
        String hql = "INSERT INTO EmployeeEntity(id,id_agency,login_user,login_pswd)"+
                "SELECT :id, id_agency, :login_user,:login_pswd";
        Query query = session.createQuery(hql);
        query.setParameter("id",elem.getId());
        query.setParameter("id_agency",elem.getId_agency());
        query.setParameter("login_user",elem.getLogin_user());
        query.setParameter("login_pswd",elem.getLogin_pswd());
        session.getTransaction().commit();
        session.close();
    }

    @Override
    public void update(String s, int x) {

    }

    public void update(String integer, Employee elem) {
        Connection connection = dbUtils.getConnection();
        try{
            //nu folosim
            String command = "update Employee set login_pswd=? where id=?";
            PreparedStatement statement = connection.prepareStatement(command);
            statement.setString(1,elem.getLogin_pswd());
            statement.setString(2, integer);
            statement.executeUpdate();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
        logger.traceExit();
    }

    @Override
    public void delete(String id) {
        //nu folosim
        Connection connection = dbUtils.getConnection();
        try (PreparedStatement statement = connection.prepareStatement("delete from Employee where id = ?")) {
            statement.setString(1, id);
            statement.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
        logger.traceExit();
    }

}
