import java.util.Scanner;

class Ex04 {

    public static int[][] GetMatrix(Scanner reader, int R, int C) {
        int[][] M = new int[R][C];

        for (int r = 0; r < R; r++) {
            for (int c = 0; c < C; c++) {
                System.out.print("Enter ("+ (c+1) + "," + (r+1) + "): ");
                int n = reader.nextInt();
                M[r][c] = n;
            }
        }

        return M;
    }

    public static void PrintMatrix(int[][] M) {
        int R = M.length;
        int C = M[0].length;

        for (int r = 0; r < R; r++) {
            for (int c = 0; c < C; c++) {
                System.out.print(M[r][c] + "\t");
            }
            System.out.println();
        }
    }

    public static int[][] AddMatrix(int[][] M1, int[][] M2) {
        int R = M1.length;
        int C = M1[0].length;

        int[][] MR = new int[R][C];

        for (int r = 0; r < R; r++) {
            for (int c = 0; c < C; c++) {
                MR[r][c] = M1[r][c] + M2[r][c];   
            }
        }

        return MR;
    }

    public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);

        System.out.print("Enter the size of the matrix:\nRows: ");
        int R = reader.nextInt();
        System.out.print("Columns: ");
        int C = reader.nextInt();

        int[][] M1 = GetMatrix(reader, R, C);
        int[][] M2 = GetMatrix(reader, R, C);

        int[][] MR = AddMatrix(M1, M2);

        PrintMatrix(M1);
        System.out.print("\n\t+\n\n");
        PrintMatrix(M2);
        System.out.print("\n\t=\n\n");
        PrintMatrix(MR);

        reader.close();
    }
}
