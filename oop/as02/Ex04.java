import java.lang.System;
import java.lang.String;
import java.lang.Math;
import java.util.Scanner;

public class Ex04 {

    static Scanner scanner;
    
    public static void main(String[] args) {

        scanner = new Scanner(System.in);

        float temp = getFloatUserInput("Enter temperature in Celsius: ", scanner);

        String message;

        if (temp > 30.f) {
            message = "Hot";           
        } else if (temp > 20.f) {
            message = "Warm";
        } else if (temp > 10.f) {
            message = "Fine";
        } else {
            message = "Cold";
        }

        System.out.println(message);

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