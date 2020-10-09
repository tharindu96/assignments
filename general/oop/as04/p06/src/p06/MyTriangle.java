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
public class MyTriangle {
    
    private MyPoint v1, v2, v3;

    public MyTriangle(int x1, int y1, int x2, int y2, int x3, int y3) {
        v1 = new MyPoint(x1, y1);
        v2 = new MyPoint(x2, y2);
        v3 = new MyPoint(x3, y3);
    }
    
    public MyTriangle(MyPoint v1, MyPoint v2, MyPoint v3) {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
    }

    @Override
    public String toString() {
        return String.format("Triangle @ (%d, %d), (%d, %d), (%d, %d)\n",
                v1.getX(), v1.getY(),
                v2.getX(), v2.getY(),
                v3.getX(), v3.getY());
    }
    
    public double getPerimeter() {
        return v1.distance(v2) + v2.distance(v3) + v3.distance(v1);
    }
    
    public void printType() {
        double s1 = v1.distance(v2);
        double s2 = v2.distance(v3);
        double s3 = v3.distance(v1);
        
        if (s1 == s2 && s2 == s3) {
            System.out.println("Equilateral");
        } else if (s1 == s2 || s2 == s3 || s1 == s3) {
            System.out.println("Isosceles");
        } else {
            System.out.println("Scalene");
        }
    }
}
