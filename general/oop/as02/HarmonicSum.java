import java.lang.System;
import java.lang.String;
import java.lang.Math;
import java.util.Scanner;

public class HarmonicSum {
    public static void main(String[] args) {
        int i;
        int n = 50000;
        double sum = 0;

        for (i = 0; i < n; i++) {
            sum += 1 / (double)(i+1);
        }

        System.out.println("Sum: " + sum);
    }
}