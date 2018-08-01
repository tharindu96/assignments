/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p01;

/**
 *
 * @author bcs2
 */
public class P01 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ThreadExtended t1 = new ThreadExtended();
        ThreadRunnable run = new ThreadRunnable();
        Thread t2 = new Thread(run);
        t1.start();
        t2.start();
    }
    
}

class ThreadExtended extends Thread {

    @Override
    public void run() {
        System.out.println("I am from ThreadExtended");
    }
    
}

class ThreadRunnable implements Runnable {

    @Override
    public void run() {
        System.out.println("I am from ThreadRunnable");
    }
    
}