package domain;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.io.Serializable;
import java.util.Vector;

public class GetTripsTable implements Serializable {
    public Vector<Vector> dataVector;
    public GetTripsTable(Vector<Vector> dataVector){
        this.dataVector = dataVector;
    }

    public GetTripsTable() {
    }
}
