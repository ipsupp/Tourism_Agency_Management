package domain;

import java.io.Serializable;

public class ChatMessage implements Serializable {
    public String message;
    public String sender;
    public ChatMessage(String message, String sender){
        this.message = message;
        this.sender = sender;
    }
    public ChatMessage(){
        this.message = null;
        this.sender = null;
    }
}
