package domain;

import java.io.Serializable;
import java.util.Vector;

public class GetLookupTable implements Serializable {
    public Vector<Vector> dataVector;
    public String location;
    public int time_start;
    public int time_end;
    public GetLookupTable(Vector<Vector> dataVector){
        this.dataVector = dataVector;
    }

    public GetLookupTable(Vector<Vector> dataVector, String location, int time_start, int time_end) {
        this.dataVector = dataVector;
        this.location = location;
        this.time_start = time_start;
        this.time_end = time_end;
    }

    public GetLookupTable() {
    }
}
