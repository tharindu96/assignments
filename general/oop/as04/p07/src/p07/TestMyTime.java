/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p07;

/**
 *
 * @author bcs2
 */
public class TestMyTime {
    
    public static void runTests() {
        
        MyTime t = new MyTime(0, 0, 0);
        
        t = t.nextMinute();
        
        System.out.println(t.toString());
        
    }
    
}
