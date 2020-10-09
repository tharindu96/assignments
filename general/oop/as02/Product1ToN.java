import java.lang.System;
import java.lang.String;
import java.lang.Math;
import java.util.Scanner;

public class Product1ToN {
    public static void main(String[] args) {
        int i;
        int total = 1;

        for (i = 1; i <= 10; i++) {
            total *= i;
        }

        System.out.println("Product: " + total);
    }
}