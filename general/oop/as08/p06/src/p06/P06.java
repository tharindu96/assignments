/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p06;

import java.util.Scanner;

/**
 *
 * @author bcs2
 */
public class P06 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        double x, y, z, p;
        Scanner s = new Scanner(System.in);
        System.out.print("Enter x in degress: ");
        x = s.nextDouble();
        System.out.print("Enter y in degress: ");
        y = s.nextDouble();
        System.out.print("Enter z in degress: ");
        z = s.nextDouble();
        s.close();
        
        CalcThread ts, tc, tt;
        ts = new SinCalcThread(x);
        tc = new CosCalcThread(y);
        tt = new TanCalcThread(z);
        
        ts.setPriority(Thread.MIN_PRIORITY);
        tt.setPriority(Thread.MAX_PRIORITY);
        
        ts.start();
        tc.start();
        tt.start();
        
        try {
            ts.join();
            tc.join();
            tt.join();
        } catch (InterruptedException e) {
            System.err.println(e.getMessage());
        }
        
        p = ts.getResult() + tc.getResult() + tt.getResult();
        
        System.out.println("p: " + p);
        
    }
    
}

abstract class CalcThread extends Thread {
    
    private double result;
    
    abstract protected double getValue(double in);

    public double getResult() {
        return result;
    }

    public CalcThread(String name, double in) {
        super(name);
        result = in;
    }

    @Override
    public void run() {
        System.out.println(getName() + ": started");
        result = getValue(result);
        System.out.println(getName() + ": result(" + result + ")");
        System.out.println(getName() + ": ended");
    }
    
}

class SinCalcThread extends CalcThread {

    public SinCalcThread(double in) {
        super("Sine Thread", in);
    }

    @Override
    protected double getValue(double in) {
        return Math.sin(Math.toRadians(in));
    }
}

class CosCalcThread extends CalcThread {

    public CosCalcThread(double in) {
        super("Cosine Thread", in);
    }

    @Override
    protected double getValue(double in) {
        return Math.cos(Math.toRadians(in));
    }
}

class TanCalcThread extends CalcThread {

    public TanCalcThread(double in) {
        super("Tangent Thread", in);
    }

    @Override
    protected double getValue(double in) {
        return Math.tan(Math.toRadians(in));
    }
}