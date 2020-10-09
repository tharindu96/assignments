class Ex02 {
    public static void main(String[] args) {
        int[] arr = {
            23, 6, 47, 35, 2, 14
        };

        int highest = arr[0];

        for (int i = 1; i < arr.length; i++) {
            highest = (highest < arr[i]) ? arr[i] : highest;
        }

        System.out.println("Highest: " + highest);
    }
}
