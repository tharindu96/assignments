import java.util.*;

class Ex05 {

    public static int[] GetArray(Scanner reader, int L) {
        int[] arr = new int[L];

        for (int l = 0; l < L; l++) {
            System.out.print("Enter ("+ (l+1) + "): ");
            int n = reader.nextInt();
            arr[l] = n;
        }

        return arr;
    }

    public static void PrintArray(int[] arr) {
        int L = arr.length;

        for (int l = 0; l < L; l++) {
            System.out.print(arr[l]);
            if (l + 1 < L) {
                System.out.print(", ");
            }
        }
        System.out.println();
    }

    public static boolean CheckArrays(int[] arr1, int[] arr2) {
        int L = arr1.length;

        boolean same = true;

        for (int l = 0; l < L; l++) {
            if (arr1[l] != arr2[l]) {
                same = false;
                break;
            }
        }

        return same;
    }

    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);

        System.out.print("Enter the size of the arrays:\nSize(int): ");
        int L = reader.nextInt();

        int[] arr1 = GetArray(reader, L);
        int[] arr2 = GetArray(reader, L);

        Arrays.sort(arr1);
        Arrays.sort(arr2);


        if (CheckArrays(arr1, arr2)) {
            System.out.println("They are the same!");
        } else {
            System.out.println("Not same!");
        }


        reader.close();
    }
}
