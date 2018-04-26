import java.lang.System;
import java.lang.String;
import java.lang.Math;
import java.util.Scanner;

public class SumAndAverage {
    public static void main(String[] args) {
        int i;
        int limit = 100;
        int total = 0;
        float avg;

        for (i = 0; i < limit; i++) {
            total += i+1;
        }

        avg = (float)total / limit;

        System.out.println("The sum is " + total);
        System.out.println("The average is " + avg);
    }
}