class Ex11 {

    public static int getMaxMinGap(int[] arr) {
        int max = arr[0];
        int min = arr[0];

        for (int i = 1; i < arr.length; i++) {
            max = (max < arr[i]) ? arr[i] : max;
            min = (min > arr[i]) ? arr[i] : min;
        }

        return max - min;
    }

    public static void main(String[] args) {
        System.out.println(getMaxMinGap(new int[] {34,2, 13,124, 1231, 213,3 , 32}));
    }
}
