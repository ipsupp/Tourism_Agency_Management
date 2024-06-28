package entities;

import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;

import java.io.Serializable;

@Entity
@Table(name = "Employee")
public class EmployeeEntity implements Serializable {
    @Id
    private String id; // direct id
    private String id_agency;
    private String login_user;
    private String login_pswd;
    public EmployeeEntity(String employee_id, String id_agency, String login_user, String login_pswd) {

        this.id = employee_id;
        this.id_agency = id_agency;
        this.login_user = login_user;
        this.login_pswd = login_pswd;
    }

    public EmployeeEntity() {

    }

    public String getId_agency() {
        return id_agency;
    }

    public void setId_agency(String id_agency) {
        this.id_agency = id_agency;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getLogin_user() {
        return login_user;
    }

    public void setLogin_user(String login_user) {
        this.login_user = login_user;
    }

    public String getLogin_pswd() {
        return login_pswd;
    }

    public void setLogin_pswd(String login_pswd) {
        this.login_pswd = login_pswd;
    }

    @Override
    public String toString() {
        return  id + " " + login_user + " " + id_agency + '\n';
    }
}
