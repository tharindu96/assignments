import java.lang.System;
import java.lang.String;
import java.lang.Math;

public class PrintPatterns {
    public static void main(String[] args) {
        int i;
        String pattern = "";
        for (i = 0; i < 8; i++) {
            pattern += getPatternLine(i+1, 0, '#');
        }
        System.out.print(pattern);
        System.out.println();

        pattern = "";
        for (i = 0; i < 8; i++) {
            pattern += getPatternLine(8-i, 0, '#');
        }
        System.out.print(pattern);
        System.out.println();
        
        pattern = "";
        for (i = 0; i < 8; i++) {
            pattern += getPatternLine(8-i, 2*i, '#');
        }
        System.out.print(pattern);
        System.out.println();
        
        pattern = "";
        for (i = 0; i < 8; i++) {
            pattern += getPatternLine(i+1, 2*(8-i-1), '#');
        }
        System.out.print(pattern);
        System.out.println();

        pattern = "";
        for (i = 0; i < 8; i++) {
            pattern += getPatternLine(i+1, 8-i-1, '#');
        }
        System.out.print(pattern);
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