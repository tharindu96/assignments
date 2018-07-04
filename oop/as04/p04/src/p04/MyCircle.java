/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p04;

/**
 *
 * @author bcs2
 */
public class MyCircle {
    private MyPoint center;
    private int radius;

    public MyCircle(int x, int y, int radius) {
        this.center = new MyPoint(x, y);
        this.radius = radius;
    }

    public MyCircle(MyPoint center, int radius) {
        this.center = center;
        this.radius = radius;
    }

    @Override
    public String toString() {
        return String.format("Circle @ (%d, %d) radius=%d\n", center.getX(), center.getY(), radius);
    }
    
    public double getArea() {
        return Math.PI * radius * radius;
    }

    public int getRadius() {
        return radius;
    }

    public void setRadius(int radius) {
        this.radius = radius;
    }

    public MyPoint getCenter() {
        return center;
    }

    public void setCenter(MyPoint center) {
        this.center = center;
    }
    
    public int getCenterX() {
        return center.getX();
    }
    
    public int getCenterY() {
        return center.getY();
    }
    
    public void setCenterXY(int x, int y) {
        center.setXY(x, y);
    }
}
