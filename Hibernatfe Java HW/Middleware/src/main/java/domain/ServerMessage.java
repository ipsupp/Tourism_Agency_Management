package domain;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.google.gson.Gson;


import javax.management.ObjectInstance;
import java.io.Serializable;
import java.lang.reflect.Type;

public class ServerMessage implements Serializable {

    public String body;
    public String type;
    public ServerMessage() {
        type = null;
        body = null;
    }

    public ServerMessage(Object e)  {
        type = String.valueOf(e.getClass());
        Gson gson = new Gson();
        body = gson.toJson(e);
    }
}
