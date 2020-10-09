/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package t09;

import java.util.Random;
import java.util.Scanner;

/**
 *
 * @author bcs2
 */
public class T09 {
    
    private static Random random;
    
    private static int getRandom() {
        return Math.abs(random.nextInt() % 10);
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        random = new Random();
        int a, b, answer = 0;
        Scanner s = new Scanner(System.in);
        
        while(answer != -1) {
            a = getRandom();
            b = getRandom();
            System.out.format("How much is %d times %d?\n", a, b);
            while(answer != -1) {
                System.out.format("Enter your answer (-1 to exit): ");
                answer = s.nextInt();
                if (answer == -1) {
                    break;
                }
                if (answer == a * b) {
                    System.out.println("Very Good!");
                    break;
                } else {
                    System.out.println("No. Please try again.");
                }
            }
        }
        
        s.close();
    }
    
}
