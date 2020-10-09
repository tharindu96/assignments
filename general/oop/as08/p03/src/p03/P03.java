/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p03;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author bcs2
 */
public class P03 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        int[] class_A={23,45,12,67,34};
        int[] class_B={50,34,12,90,123,19};
        int[] class_C={45,34,78,99,22,55,66,77,90};
        long time;
        
        try {
            System.out.println("Multi-Threaded:");
            
            ArraySumThread tA, tB, tC;
            
            tA = new ArraySumThread("class_A");
            tB = new ArraySumThread("class_B");
            tC = new ArraySumThread("class_C");
            
            tA.setArray(class_A);
            tB.setArray(class_B);
            tC.setArray(class_C);
            
            time = System.nanoTime();
            tA.start();
            tB.start();
            tC.start();
            
            tA.join();
            tB.join();
            tC.join();
            
            time = System.nanoTime() - time;
            System.out.println(time);
        
        } catch (InterruptedException ex) {
            Logger.getLogger(P03.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        System.out.println("Single-Threaded:");
        time = System.nanoTime();
        
        int t = 0;
        for (int i = 0; i < class_A.length; i++) {
            t += class_A[i];
        }
        System.out.println("class_A total: " + t);
        
        t = 0;
        for (int i = 0; i < class_B.length; i++) {
            t += class_B[i];
        }
        System.out.println("class_B total: " + t);
        
        t = 0;
        for (int i = 0; i < class_C.length; i++) {
            t += class_C[i];
        }
        System.out.println("class_C total: " + t);
        
        time = System.nanoTime() - time;
        System.out.println(time);
        
//        try {
//            time = System.nanoTime();
//            ArraySumThread tA, tB, tC;
//            tA = new ArraySumThread("class_A");
//            tB = new ArraySumThread("class_B");
//            tC = new ArraySumThread("class_C");
//            tA.setArray(class_A);
//            tB.setArray(class_B);
//            tC.setArray(class_C);
//            tA.start();
//            tA.join();
//            tB.start();
//            tB.join();
//            tC.start();
//            tC.join();
//            time = System.nanoTime() - time;
//            System.out.println(time);
//        } catch (InterruptedException ex) {
//            Logger.getLogger(P03.class.getName()).log(Level.SEVERE, null, ex);
//        }
        
    }
    
}

class ArraySumThread extends Thread {
    
    private int[] mArray;

    public ArraySumThread(String name) {
        super(name);
    }

    public void setArray(int[] array) {
        mArray = array;
    }

    @Override
    public void run() {
        int t = 0;
        for (int i = 0; i < mArray.length; i++) {
            t += mArray[i];
        }
        System.out.println(getName() + " total: " + t);
    }
    
}