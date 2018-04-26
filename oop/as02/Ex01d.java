import java.lang.System;
import java.lang.String;

public class Ex01d {
    
    public static void main(String[] args) {
        String pattern = "";
        for (int i = 0; i < 5; i++) {
            pattern += getPatternLine(i+1, 2*(5-i-1), '*');
            if (i+1 < 5) pattern += "\n";
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