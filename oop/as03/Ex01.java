class Ex01 {
    public static void main(String[] args) {
        int[] arr = {
            23, 6, 47, 35, 2, 14
        };

        int avg = 0;

        for (int i = 0; i < arr.length; i++) {
            avg += arr[i];
        }

        avg /= arr.length;

        System.out.println("Average: " + avg);
    }
}
