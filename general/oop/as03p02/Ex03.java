import java.util.*;

class Ex03 {

    public static void printIntArr(int[] arr) {
        for(int i = 0; i < arr.length; i++) {
            System.out.print(arr[i]);
            if (i < arr.length - 1) {
                System.out.print(", ");
            }
        }
        System.out.println();
    }

    public static void main(String[] args) {

        int[] IntArr = new int[] {
            1, 2, 5, 5, 6, 6, 7, 2
        };

        Arrays.sort(IntArr);

        ArrayList<Integer> arr = new ArrayList<>();

        for (int i = 0; i+1 < IntArr.length; i++) {
            if (IntArr[i] == IntArr[i+1]) {
                arr.add(IntArr[i]);
                while (IntArr[i] == IntArr[i+1] && (i + 1) < IntArr.length) {
                    i++;
                }
            }
        }

        int[] dupArr = new int[arr.size()];

        for (int i = 0; i < arr.size(); i++) {
            dupArr[i] = arr.get(i);
        }

        System.out.print("Duplicates: ");
        printIntArr(dupArr);
    }
}
