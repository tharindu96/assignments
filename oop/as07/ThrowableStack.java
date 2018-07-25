import java.io.*;
import java.util.*;

public class ThrowableStack {

	public static void function1() throws Exception {
		throw new Exception("this is thrown from function1()");
	}
	
	public static void function2() throws Throwable {
		try {
			function1();
		} catch (Exception e) {
			System.out.println("Inside function2()");
			e.printStackTrace();
			// throw e.fillInStackTrace();
		}
	}

    public static void main(String[] args) throws Throwable {
    	try {
    		function2();
    	} catch (Exception e) {
    		System.out.println("Caught Inside Main: ");
    		e.printStackTrace();
    	}
    }
}
