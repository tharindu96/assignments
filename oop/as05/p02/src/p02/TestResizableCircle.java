/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p02;

/**
 *
 * @author bcs2
 */
public class TestResizableCircle {
    
    public static void run() {
        ResizableCircle rc = new ResizableCircle(5);
        System.out.println("Circle: " + rc.toString());
        rc.resize(-10);
        System.out.println("Resized: " + rc.toString());
    }
    
}
