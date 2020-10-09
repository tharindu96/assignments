/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package t08;

import java.util.Scanner;

/**
 *
 * @author bcs2
 */
public class T08 {
    
    private static int total = 0;
    
    private static int calculateCharges(int hours) {
        int charge = 200;
        int rem = Integer.max(0, hours - 3);
        charge += 50 * rem;
        charge = Integer.min(1000, charge);
        return charge;
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        
//        System.out.print("Enter the number of customers: ");
//        int n = s.nextInt();
//        int i = n;
//        while (i > 0) {
//            System.out.format("Parking hours of Customer %d: ", n - i + 1);
//            int h = s.nextInt();
//            total += calculateCharges(h);
//            i--;
//        }

        int h;

        while (true) {
            System.out.print("Enter number of hours (a negative to quit): ");
            h = s.nextInt();
            if (h < 0) break;
            h = calculateCharges(h);
            total += h;
            System.out.format("Current charge: Rs.%d.00, Total receipts: Rs.%d.00\n", h, total);
            
        }
        
        System.out.println("Total: " + total);
        
        s.close();
    }
    
}
