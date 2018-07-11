/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package t02;

import java.util.Random;

/**
 *
 * @author bcs2
 */
public class T02 {
    
    private static Random random;
    
    private static int getResult() {
        return random.nextInt() % 2;
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        random = new Random();
        
        int head = 0, tail = 0;
        
        for (int i = 0; i < 10; i++) {
            if (getResult() == 0) {
                head++;
            } else {
                tail++;
            }
        }
        
        System.out.format("Tails \t Heads\n%5d \t %5d\n", tail, head);
    }
    
}
