/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package t03;

import java.util.Scanner;

/**
 *
 * @author bcs2
 */
public class T03 {
    
    private static boolean divisible(int a, int b) {
        return (a % b == 0);
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner inp = new Scanner(System.in);
        
        System.out.print("Enter 2 numbers: ");
        int a = inp.nextInt();
        int b = inp.nextInt();
        
        boolean f = divisible(a, b);
        
        System.out.format("%d is divisible by %d: %b\n", a, b, f);
        
        inp.close();
    }
    
}
