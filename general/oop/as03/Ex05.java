class Ex05 {
    public static void main(String[] args) {
        int[] A = {
            12, 34, 45, 12
        };
        int[] B = {
            34, 23, 61, 10
        };

        int[] R = new int[A.length];

        for (int i = 0; i < A.length; i++) {
            R[i] = A[i] + B[i];
        }

        for (int i = 0; i < R.length; i++) {
            System.out.print(R[i]);
            if (i < R.length - 1) {
                System.out.print(", ");
            }
        }
        System.out.print("\n");
    }
}
