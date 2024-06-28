package domain;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class ChatLogs implements Serializable {
    public List<ChatMessage> chatMessages = new ArrayList<ChatMessage>();
    public ChatLogs() {}
    public ChatLogs(List<ChatMessage> messages){
        this.chatMessages = messages;
    }
    public void addLog(ChatMessage message)
    {
        chatMessages.add(message);
    }
}
