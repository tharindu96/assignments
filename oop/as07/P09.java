import java.io.*;
import java.util.*;

class P09 {
    public static void main(String[] args) {
    	int port = getUserInputs();
    	try {
    		String s = getPort(port);
    		System.out.println("Service: " + s);
    	} catch (InputMismatchException e) {
    		System.out.println("Must enter an integer");
    	} catch (IOException e) {
    		System.out.println(e.getMessage());
    	}
    }
    
    public static int getUserInputs() {
    	Scanner in = new Scanner(System.in);
    	System.out.print("Enter port number: ");
    	int p = in.nextInt();
    	in.close();
    	return p;
    }
    
    public static String getPort(int port) throws IOException {
    	switch (port) {
    		case 20:
    			return "FTP";
    		case 22:
    			return "SSH";
    		case 25:
    			return "SMTP";
    		case 53:
    			return "DNS";
    		case 80:
    			return "HTTP";
    		case 161:
    			return "SNMP";
    		default:
    			throw new IOException("Invalid Port");
    	}
    }
    
}
