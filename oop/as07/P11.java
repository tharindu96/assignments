import java.io.*;
import java.util.*;

class P11 {
    public static void main(String[] args) {
    	int[] attended_lectures = {25, 28, 15, 27, 20};
    	AttendanceVerifier av = new AttendanceVerifier();
    	for(int i:attended_lectures) {
    		// try {
    			System.out.format("Percentage: %.2f\n", av.getAttendancePercentage(i, 30));
    		/*} catch (AttendanceException e) {
    			System.out.println(e.getMessage());
    		}*/
    	}
    }
    
    static class AttendanceException extends RuntimeException {
    	private double attendance_percentage;
    	
    	public AttendanceException(double percentage) {
    		super(String.format("Not an enough attendance percentage: %.2f", percentage));
    		this.attendance_percentage = percentage;
    	}
    	
    	public double getAttendancePercentage() {
    		return attendance_percentage;
    	}
    }
    
    static class AttendanceVerifier {
    	public double getAttendancePercentage(int attended, int total) {
    		double p = ((double)attended / total) * 100.0;
    		if (p < 80) {
    			throw new AttendanceException(p);
    		}
    		return p;
    	}
    }
    
}
