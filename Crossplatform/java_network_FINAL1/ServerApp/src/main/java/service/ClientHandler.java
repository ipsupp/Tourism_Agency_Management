//package service;
//
//import java.io.BufferedReader;
//import java.io.IOException;
//import java.io.InputStreamReader;
//import java.io.PrintWriter;
//import java.net.Socket;
//
//class ClientHandler extends Thread {
//    private Socket clientSocket;
//    public static int number = 1;
//
//    public ClientHandler(Socket socket) {
//        this.clientSocket = socket;
//    }
//
//    public void run() {
//        try {
//            BufferedReader in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
//            PrintWriter out = new PrintWriter(clientSocket.getOutputStream(), true);
//            out.println("Hello " + number++);
//            in.close();
//            out.close();
//            clientSocket.close();
//        } catch (IOException e) {
//            e.printStackTrace();
//        }
//    }
//}
