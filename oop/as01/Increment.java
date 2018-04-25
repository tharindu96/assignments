public class Increment {
    public static void main(String[] args) {
        int num1 = 1;
        int num2 = 1;
        int num3, num4;
        num3 = ++num1;
        num4 = num2++;

        System.out.println("num1=" + num1);
        System.out.println("num2=" + num2);
        System.out.println("num3=" + num3);
        System.out.println("num4=" + num4);
    }
}