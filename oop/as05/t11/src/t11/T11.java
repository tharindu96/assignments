/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package t11;

import java.util.Scanner;

/**
 *
 * @author bcs2
 */
public class T11 {
    
    private static double circleArea(double r) {
        return Math.PI * r * r;
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        double a;
        Scanner s = new Scanner(System.in);
        while (true) {
            System.out.print("Enter the radius (negative to quit): ");
            a = s.nextDouble();
            if (a < 0) {
                break;
            }
            System.out.println("Area is " + circleArea(a));
        }
        s.close();
    }
    
}
