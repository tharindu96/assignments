class Ex12 {

    public static void PowerOf2Triangle(int num) {
        int i, j;
        for (i = 0; i < num; i++) {
            for (j = 0; j < (num-i-1); j++) {
                System.out.print("    ");
            }
            for (j = 0; j <= 2*i; j++) {
                System.out.format("%4.0f", Math.pow(2, i - Math.abs(i-j)));
            }
            System.out.print("\n");
        }
    }

    public static void main(String[] args) {

        PowerOf2Triangle(8);
    }
}
