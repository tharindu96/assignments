import java.util.Scanner;

class Ex07 {
    public static void main(String[] args) {
        int[][] M = new int[4][3];

        int R = M.length;
        int C = M[0].length;

        Scanner reader = new Scanner(System.in);

        boolean found = false;

        for (int r = 0; r < R; r++) {
            for (int c = 0; c < C; c++) {
                System.out.print("Enter ("+ (c+1) + "," + (r+1) + "): ");
                int n = reader.nextInt();
                M[r][c] = n;
                if (n == 6) {
                    found = true;
                }
            }
        }

        if (found) {
            System.out.println("Found");
        } else {
            System.out.println("Not Found");
        }

        reader.close();
    }
}
