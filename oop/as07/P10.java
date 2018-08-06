import java.io.*;
import java.util.*;

class P10 {
    public static void main(String[] args) {
    	try {
    		throw new MyNameException("Tharindu");
    	} catch (MyNameException e) {
    		System.out.println(e.getMessage());
    		e.printStackTrace();
    	}
    }
    
    static class MyNameException extends Exception {
    	private String name;
    	
    	public MyNameException(String name) {
    		super("Invalid Name: " + name);
    		this.name = name;
    	}
    	
    	public String getName() {
    		return name;
    	}
    }
    
}
