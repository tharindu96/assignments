import java.lang.System;
import java.lang.String;
import java.lang.Math;
import java.util.Scanner;

public class MultipleFinder {
    public static void main(String[] args) {
        int i;
        int limit = 110;

        String ret;
        for (i = 1; i <= limit; i++) {
            ret = i+" ";
            if (i % 3 == 0) ret += "Three";
            if (i % 5 == 0) ret += "Five";
            if (i % 7 == 0) ret += "Seven";
            ret += "\n";
            System.out.print(ret);
        }
    }
}