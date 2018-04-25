import java.lang.System;
import java.lang.String;
import java.lang.Math;

public class P02Ex01 {
    public static void main(String[] args) {
        double r = 2.4 * 0.01; // converting to meters
        double PI = 3.14159;

        double area = PI * r * r;

        System.out.println("Radius: " + r + " m");
        System.out.println("Area: " + area + " m^2");

        r = 2*r;
        area = PI * r * r;

        System.out.println("New Radius: " + r + " m");
        System.out.println("New Area: " + area + " m^2");

        double perimeter = 2 * PI * r;

        System.out.println("Perimeter: " + perimeter + " m");

    }
}