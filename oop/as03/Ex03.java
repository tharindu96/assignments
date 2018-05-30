class Ex03 {
    public static void main(String[] args) {
        int[] arr = {
            23, 6, 47, 35, 2, 14
        };

        for (int i = 1; i < arr.length; i++) {
            if (arr[i] % 2 == 1) {
                System.out.print(arr[i] + ", ");
            }
        }
    }
}
