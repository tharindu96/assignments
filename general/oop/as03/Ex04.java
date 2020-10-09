class Ex04 {

    public static int[] sort(int[] arr) {

        // insertion sort

        int k, tmp;
        int i, j;
        for (i = 1; i < arr.length; i++) {
            k = arr[i];
            for (j = i - 1; j >= 0; j--) {
                if (arr[j] < k) {
                    break;
                }
                tmp = arr[j];
                arr[j] = arr[j+1];
                arr[j+1] = tmp;
            }
            arr[j+1] = k;
        }

        return arr;
    }

    public static void main(String[] args) {
        int[] arr = {
            23, 45, 12, 56, 22
        };

        arr = sort(arr);

        for (int i = 0; i < arr.length; i++) {
            System.out.print(arr[i]);
            if (i < arr.length - 1) {
                System.out.print(", ");
            }
        }
        System.out.print("\n");
    }
}
