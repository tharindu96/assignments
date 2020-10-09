import java.util.Scanner;

class Ex01 {
    public static void main(String[] args) {
        int[] arr = new int[10];

        Scanner reader = new Scanner(System.in);

        for (int i = 0; i < arr.length; i++) {
            System.out.print("Enter ("+ (i+1) + "): ");
            int n = reader.nextInt();
            arr[i] = n;
        }

        System.out.print("Enter Number to find: ");
        int f = reader.nextInt();

        reader.close();

        for (int i = 0; i < arr.length; i++) {
            if (f == arr[i]) {
                System.out.println("Found! index: " + i);
                return;
            }
        }

        System.out.println("Not Found!");
    }
}
