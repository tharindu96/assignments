import java.io.*;

class ReadData {
    public static void main(String[] args) {
    	try {
    		RandomAccessFile raf = new RandomAccessFile("MyFile.txt", "r");
    		byte[] arr = new byte[1000];
    		raf.readFully(arr, 0, 10);
			System.out.println(new String(arr));
			raf.close();
    	} catch (FileNotFoundException e) {
			System.out.println("File not found");
			e.printStackTrace();
    	} catch (IOException e) {
    		System.out.println("IO Error");
    		e.printStackTrace();
    	}
    }
}
