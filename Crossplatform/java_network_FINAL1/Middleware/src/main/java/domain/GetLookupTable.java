package domain;

import java.io.Serializable;
import java.util.Vector;

public class GetLookupTable implements Serializable {
    public String location;
    public int time_start;
    public int time_end;

    public GetLookupTable( String location, int time_start, int time_end) {
        this.location = location;
        this.time_start = time_start;
        this.time_end = time_end;
    }

    public GetLookupTable() {
    }
}
