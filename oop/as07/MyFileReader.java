import java.io.*;

class MyFileReader {
    public static void main(String[] args) {
    	String line;
    	try {
			BufferedReader br = new BufferedReader(new FileReader("ExceptionCheck.txt"));
			
			while ((line = br.readLine()) != null) {
				System.out.println(line);
			}
    	} catch (IOException e) {
    		System.out.println(e.getMessage());
    	}
    }
}
