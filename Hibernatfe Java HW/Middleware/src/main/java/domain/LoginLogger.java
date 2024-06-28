package domain;

import java.io.Serializable;

public class LoginLogger implements Serializable {
    public String onlineUser;
    public LoginLogger(String onlineUser){
        this.onlineUser = onlineUser;
    }
    public LoginLogger(){
        this.onlineUser = null;
    }
}
