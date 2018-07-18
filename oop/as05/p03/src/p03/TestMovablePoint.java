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
public class TestMovablePoint {
    
    public static void run() {
        MovablePoint p = new MovablePoint(0, 0);
        System.out.println(p);
        p.moveDown();
        System.out.println(p);
        p.moveLeft();
        System.out.println(p);
        p.moveUp();
        System.out.println(p);
        p.moveRight();
        System.out.println(p);
    }
    
}
