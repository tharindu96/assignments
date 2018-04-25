import java.lang.System;
import java.lang.String;
import java.lang.Math;

public class P02Ex03 {
    public static void main(String[] args) {
        int num1 = 20, num2 = 40;
        int tmp;

        System.out.printf("num1: %d\nnum2: %d\n\n", num1, num2);

        tmp = num1;
        num1 = num2;
        num2 = tmp;

        System.out.printf("num1: %d\nnum2: %d\n", num1, num2);
    }
}