/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package t04;

import java.util.Scanner;

/**
 *
 * @author bcs2
 */
public class T04 {
    
    private static double halve(double n) {
        return n / 2;
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        System.out.print("Enter a number: ");
        Scanner s = new Scanner(System.in);
        
        double f = s.nextDouble();
        f = halve(f);
        
        System.out.println(f);
        
        s.close();
    }
    
}
