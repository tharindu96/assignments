import java.lang.System;
import java.lang.String;
import java.lang.Math;
import java.util.Scanner;

public class Ex07 {
    public static void main(String[] args) {
        int i;
        int limit = 100;
        int total = 0;
        float avg;

        i = 0;
        do {
            total += i+1;
            i++;   
        } while(i < limit);
        avg = (float)total / limit;

        System.out.println("The sum is " + total);
        System.out.println("The average is " + avg);
    }
}