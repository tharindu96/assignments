import java.io.*;

class NestedExceptionTest {
    public static void main(String[] args) {
    	try {
    		try {
    			int a = Integer.parseInt("63");
    			int b = a / 0;
    		} catch (ArithmeticException e) {
    			System.out.println("caught inside");
    			e.printStackTrace();
    		}
    	} catch (NumberFormatException e) {
    		System.out.println("caught outside");
    		e.printStackTrace();
    	}
    }
}
