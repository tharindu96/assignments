/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p05;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author bcs2
 */
public class P05 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        int sampleSize = 20;
        int start = 1;
        int end = 100;
        
        int threadCount = (end - start + 1) / sampleSize;
        
        SeriesCalculator[] threads = new SeriesCalculator[threadCount];
        for (int i = 0; i < threadCount; i++) {
            threads[i] = new SeriesCalculator(start + sampleSize * i, start + sampleSize * (i+1) - 1);
            threads[i].start();
        }
        
        int total = 0;
        for (SeriesCalculator thread : threads) {
            try {
                thread.join();
                total += thread.getSummation();
            } catch (InterruptedException ex) {
                Logger.getLogger(P05.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        
        System.out.println("Total: " + total);
        
    }
    
}

class SeriesCalculator extends Thread {
    private int start;
    private int end;
    private int sum_return;

    public SeriesCalculator(int start, int end) {
        this.start = start;
        this.end = end;
    }

    public int getSummation() {
        return sum_return;
    }

    @Override
    public void run() {
        int sum = 0;
        for (int i = start; i <= end; i++) {
            sum += i;
        }
        sum_return = sum;
    }
    
}