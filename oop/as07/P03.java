import java.io.*;
import java.util.*;

class P03 {
    public static void main(String[] args) {
    	int x1, x2, y1, y2;
    	int m;
    	Scanner s = new Scanner(System.in);
    	
    	System.out.print("Enter x1: ");
    	x1 = s.nextInt();
    	
    	System.out.print("Enter y1: ");
    	y1 = s.nextInt();
    	
    	System.out.print("Enter x2: ");
    	x2 = s.nextInt();
    	
    	System.out.print("Enter y2: ");
    	y2 = s.nextInt();
    	
    	s.close();
    	
    	try {
    		m = (y2 - y1) / (x2 - x1);
    		System.out.println("Gradient: " + m);
    	} catch (ArithmeticException e) {
    		System.out.println("Gradient: Infinite");
    	}
    }
}
