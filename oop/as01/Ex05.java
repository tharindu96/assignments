import java.lang.System;
import java.lang.String;
import java.lang.Math;

public class Ex05 {
    public static void main(String[] args) {
        double rCu = 1.78E-8;
        double rSi = 2300;

        // int len = 1; not needed to find the area
        double diameter = 0.001;

        double current = 25;

        double area = Math.PI * Math.pow(diameter/2, 2);

        double RCu = rCu * (current / area);
        double RSi = rSi * (current / area);

        System.out.println("Resistance of Cu: " + RCu);
        System.out.println("Resistance of Si: " + RSi);
    }
}