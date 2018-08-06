import java.io.*;
import java.util.*;

class ThrowableDemo {

	public void Exception1() throws MyOwnException {
		try {
			Exception2();
		} catch (ArithmeticException e) {
			MyOwnException at = new MyOwnException("From MyOwnException");
			at.initCause(e);
			throw at;
		}
	}
	
	public void Exception2() throws ArithmeticException {
		throw new ArithmeticException();
	}

    public static void main(String[] args) {
    	try {
    		ThrowableDemo td = new ThrowableDemo();
    		td.Exception1();
    	} catch (MyOwnException ex) {
    		System.out.println(ex.getCause());
    	}
    }
    
    static class MyOwnException extends Exception {
    	
    	public MyOwnException(String message) {
    		super(message);
    	}
    }
}
