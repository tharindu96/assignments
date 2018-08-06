/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p07;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author bcs2
 */
public class P07 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ThreadY target = new ThreadY();
        ThreadX source = new ThreadX(target);
        
//        target.start();
//        source.start();
        
        target.start();
        
        try {
            target.join();
        } catch (InterruptedException ex) {
            ex.printStackTrace();
        }
        
        source.start();
    }
    
}


class ThreadX extends Thread {
    
    Thread next;

    public ThreadX(Thread t) {
        next = t;
    }

    @Override
    public void run() {
        if (next.isAlive()) {
            System.out.println("Thread still alive");
        } else {
            System.out.println("Thread is not alive");
        }
    }
    
}

class ThreadY extends Thread {

    @Override
    public void run() {
        try {
            Thread.sleep(1000);
        } catch (InterruptedException ex) {
            ex.printStackTrace();
        }
    }
    
}