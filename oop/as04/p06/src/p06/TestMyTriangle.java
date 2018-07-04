/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p06;

/**
 *
 * @author bcs2
 */
public class TestMyTriangle {
    
    public static void runTests() {
        
        MyTriangle t = new MyTriangle(-5, -5, -5, 5, 0, 23);
        
        System.out.format("Perimeter: %f\n", t.getPerimeter());
        t.printType();
        
    }
    
}
