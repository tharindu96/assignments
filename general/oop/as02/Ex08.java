import java.lang.System;
import java.lang.String;
import java.lang.Math;
import java.util.Scanner;

public class Ex08 {
    public static void main(String[] args) {
        int a, b, c, temp;
        a = 7;
        b = 2;
        c = 6;

        System.out.println("a="+a + " b="+b + " c="+c);

        if (a > b) {
            temp = a;
            a = b;
            b = temp;
        }

        if (a > c) {
            temp = a;
            a = c;
            c = temp;
        }

        if (b > c) {
            temp = b;
            b = c;
            c = temp;
        }

        System.out.println("a="+a + " b="+b + " c="+c);
    }
}