import java.lang.System;
import java.lang.String;
import java.lang.Math;
import java.util.Scanner;

public class Ex12 {

    static Scanner scanner;

    public static void main(String[] args) {

        scanner = new Scanner(System.in);

        float points = getFloatUserInput("Enter the points received: ", scanner);

        if (points <= 120) {
            String ret = "grade: ";
            if (points >= 105) {
                ret += "1.0";
            } else if (points >= 100) {
                ret += "1.3";
            } else if (points >= 95) {
                ret += "1.7";
            } else if (points >= 90) {
                ret += "2.0";
            } else if (points >= 85) {
                ret += "2.3";
            } else if (points >= 80) {
                ret += "2.7";
            } else if (points >= 75) {
                ret += "3.0";
            } else if (points >= 70) {
                ret += "3.3";
            } else if (points >= 65) {
                ret += "3.7";
            } else if (points >= 60) {
                ret += "4.0";
            } else if (points >= 50) {
                ret += "4.7";
            } else {
                ret += "5.0";
            }
            System.out.println(ret);
        } else {
            System.out.println("Points should be less than 120!\n");
        }

        scanner.close();

    }

    public static float getFloatUserInput(String prompt, Scanner scanner) {
        System.out.printf(prompt);
        float ret = 0.f;
        try {
            while (scanner.hasNext()){
                if (scanner.hasNextFloat()){
                    ret = scanner.nextFloat();
                    break;
                } else {
                    scanner.next();
                }
            }
        } catch (Exception e) {
            System.out.println("Invalid Integer using 0.0!");
        }
        return ret;
    }
}