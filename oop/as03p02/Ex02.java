class Ex02 {

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
            1789, 2035, 1899, 1456, 2013, 1458, 
            2458, 1254, 1472, 2365,  1456, 2165, 1457, 2456
        };

        int[] RevArry = new int[IntArr.length];

        for (int i = 0; i < IntArr.length; i++) {
            RevArry[IntArr.length - i - 1] = IntArr[i];
        }

        printIntArr(IntArr);
        printIntArr(RevArry);
    }
}
