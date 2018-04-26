import java.lang.System;
import java.lang.String;

import java.util.Scanner;

public class Ex02 {
    
    public static void main(String[] args) {
        int n = getUserInput();
        String pattern = "";
        for (int i = 0; i < n; i++) {
            pattern += getPatternLine(i+1, n-i, '*');
        }
        System.out.print(pattern);
    }

    public static int getUserInput() {
        Scanner scanner = new Scanner(System.in);
        System.out.printf("Enter an Integer: ");
        int ret = 0;
        try {
            ret = scanner.nextInt();
        } catch (Exception e) {
            System.out.println("Please enter a valid integer!");
        }
        scanner.close();
        return ret;
    }

    public static String getPatternLine(int count, int start, char character) {
        int i;
        String ret = "";
        for (i = 0; i < start; i++) {
            ret += " ";
        }
        for (i = 0; i < count; i++) {
            ret += character;
            if (i < count - 1)
                ret += " ";
        }
        ret += "\n";
        return ret;
    }
}