import java.util.Scanner;

class ScannerEx {
    public static void main(String[] args) {
    	Scanner in = new Scanner(System.in);
    	
    	while(true) {
			try {
				System.out.print("Please enter number: ");
				String str=in.next();
				int a=Integer.parseInt(str);
				break;
			} catch(NumberFormatException e) {
				e.printStackTrace();
			}
		}
    }
}
