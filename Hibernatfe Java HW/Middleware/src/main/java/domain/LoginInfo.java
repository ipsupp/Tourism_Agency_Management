package domain;

import jdk.jfr.Experimental;

import java.io.Serializable;

public class LoginInfo implements Serializable {

    public String username;
    public String password;
    public LoginInfo(String username, String password){
        this.username = username;
        this.password = password;
    }

    public LoginInfo() {}
}
