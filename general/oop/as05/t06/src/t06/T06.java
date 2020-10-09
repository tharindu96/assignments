/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package t06;

import java.util.Scanner;

/**
 *
 * @author bcs2
 */
public class T06 {
    
    private static double area(double length) {
        return length * length;
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        
        System.out.print("Enter length of the side of the square: ");
        double l = s.nextDouble();
        
        double a = area(l);
        
        System.out.println("Area: " + a);
        
        s.close();
    }
    
}
