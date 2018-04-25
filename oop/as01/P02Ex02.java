import java.lang.System;
import java.lang.String;
import java.lang.Math;

public class P02Ex02 {
    public static void main(String[] args) {
        float W = 5.4f;
        float H = 3.2f;

        float rec = W * H;
        float tri = 0.5f * W * H;


        System.out.printf("Area of Rectangle: %.3f\nArea of Triangle: %.3f\n", rec, tri);

    }
}