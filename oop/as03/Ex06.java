class Ex06 {
    public static void main(String[] args) {
        int[][] M = {
            {1, 3, 4},
            {6, 9, 2},
            {-6, 8, 0},
            {5, 3, -2}
        };

        int R = M.length;
        int C = M[0].length;

        for (int r = 0; r < R; r++) {
            for (int c = 0; c < C; c++) {
                System.out.print(M[r][c]);
                if (c < C - 1) {
                    System.out.print(", ");
                }
            }
            System.out.print("\n");
        }
    }
}
