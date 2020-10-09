/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p04;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author bcs2
 */
public class P04 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Thread t1, t2;
        t1 = new SleepThread();
        t2 = new SleepThread();
        t1.start();
        t2.start();
    }
    
}


class SleepThread extends Thread {

    @Override
    public void run() {
        for (int i = 0; i < 10; i++) {
            try {
                System.out.println(getName() + " i: " + (i+1));
                Thread.sleep(1000);
            } catch (InterruptedException ex) {
                Logger.getLogger(SleepThread.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }
    
}