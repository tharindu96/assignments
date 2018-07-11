/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package t01;

import java.util.Scanner;

/**
 *
 * @author bcs2
 */
public class T01 {
    
    public static int mod6(int n) {
        return n % 6;
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        System.out.print("Enter a Number: ");
        Scanner input = new Scanner(System.in);
        
        int n = input.nextInt();
        
        n = mod6(n);
        
        System.out.format("Mod 6: %d\n", n);
    }
    
}
