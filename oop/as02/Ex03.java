import java.lang.System;
import java.lang.String;
import java.lang.Math;
import java.util.Scanner;

public class Ex03 {

    static final int TYPE_SQUARE = 0;
    static final int TYPE_CIRCLE = 1;
    static final int TYPE_RECTAN = 2;
    static final int TYPE_CYLIND = 3;

    static Scanner scanner;
    
    public static void main(String[] args) {

        scanner = new Scanner(System.in);

        int type = getIntUserInput(""+
        "Square: 0 [default]\n"+
        "Circle: 1\nRectangle: 2\n"+
        "Cylinder (Volume): 3\n"+
        "Select a type to calculate the area or volume: ", scanner);

        float a, b, ret;

        switch (type) {
            case Ex03.TYPE_SQUARE:
                a = getFloatUserInput("Enter length: ", scanner);
                ret = a * a;
                System.out.println("Area of Square: " + ret);
            break;
            case Ex03.TYPE_CIRCLE:
                a = getFloatUserInput("Enter radius: ", scanner);
                ret = (float)Math.PI * (a * a);
                System.out.println("Area of Circle: " + ret);
            break;
            case Ex03.TYPE_RECTAN:
                a = getFloatUserInput("Enter length: ", scanner);
                b = getFloatUserInput("Enter breadth: ", scanner);
                ret = a * b;
                System.out.println("Area of Rectangle: " + ret);
            break;
            case Ex03.TYPE_CYLIND:
                a = getFloatUserInput("Enter radius: ", scanner);
                b = getFloatUserInput("Enter height: ", scanner);
                ret = 2.f * (float)Math.PI * a * b;
                System.out.println("Volume of Cylinder: " + ret);     
            break;
            default:
        }

        scanner.close();
    }

    public static int getIntUserInput(String prompt, Scanner scanner) {
        System.out.printf(prompt);
        int ret = 0;
        try {
            while (scanner.hasNext()){
                if (scanner.hasNextInt()){
                    ret = scanner.nextInt();
                    break;
                } else {
                    scanner.next();
                }
            }
        } catch (Exception e) {
            System.out.println("Invalid Integer using 0!");
        }
        return ret;
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