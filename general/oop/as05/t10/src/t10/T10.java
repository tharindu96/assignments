/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package t10;

import java.util.Scanner;

/**
 *
 * @author bcs2
 */
public class T10 {
    
    private static double distance(double x1, double y1, double x2, double y2) {
        return Math.pow((x1 - x2), 2) + Math.pow((y1 - y2), 2);
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        double x1, x2, y1, y2;
        
        System.out.print("Enter X1: ");
        x1 = s.nextDouble();
        
        System.out.print("Enter Y1: ");
        y1 = s.nextDouble();
        
        System.out.print("Enter X2: ");
        x2 = s.nextDouble();
        
        System.out.print("Enter Y2: ");
        y2 = s.nextDouble();
        
        double d = distance(x1, y1, x2, y2);
        
        System.out.println("Distance: " + d);
        
        s.close();
    }
    
}
