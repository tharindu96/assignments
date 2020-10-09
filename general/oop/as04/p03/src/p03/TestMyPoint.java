/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p03;

/**
 *
 * @author bcs2
 */
public class TestMyPoint {
    
    public static void runTests() {
        MyPoint p1 = new MyPoint(4, 8);
        MyPoint p2 = new MyPoint(4, -8);
        System.out.format("Distance: %.2f\n", p1.distance(p2));
    }
    
}
