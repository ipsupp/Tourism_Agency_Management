package domain;

import java.io.Serializable;

public class BoolData implements Serializable{
    public boolean status;
    public BoolData(boolean status){
        this.status = status;
    }

    public BoolData() {
    }
}
