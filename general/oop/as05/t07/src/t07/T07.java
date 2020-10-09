/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package t07;

import java.util.Scanner;

/**
 *
 * @author bcs2
 */
public class T07 {
    
    private static double minimum3(double a, double b, double c) {
        double m = a;
        if (m > b) m = b;
        if (m > c) m = c;
        return m;
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        System.out.print("Enter 3 numbers: ");
        double a, b, c;
        a = s.nextDouble();
        b = s.nextDouble();
        c = s.nextDouble();
        
        double m = minimum3(a, b, c);
        
        System.out.println("MIN: " + m);
        
        s.close();
    }
    
}
