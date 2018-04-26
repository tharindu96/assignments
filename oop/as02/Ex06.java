import java.lang.System;
import java.lang.String;
import java.lang.Math;
import java.util.Scanner;

public class Ex06 {
    public static void main(String[] args) {
        int i;
        int limit = 100;
        int total = 0;
        float avg;

        i = 0;
        while (i < limit) {
            total += i+1;
            i++;
        }
        avg = (float)total / limit;

        System.out.println("The sum is " + total);
        System.out.println("The average is " + avg);
    }
}