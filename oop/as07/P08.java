import java.io.*;

class P08 {
    public static void main(String[] args) {
    	try {
    		functionTest();
    	} catch (ArrayIndexOutOfBoundsException e) {
    		System.out.println("Array must be less than or equal to 10");
    	}
    }
    
    public static void functionTest() {
    	int[] arr = {51, 2, 214, 23, 12, 32, 23, 324, 32, 23, 32, 12};
    	int t = arrSum(arr);
    	System.out.println("Total: " + t);
    }
    
    public static int arrSum(int[] arr) {
    	if (arr.length > 10) {
    		throw new ArrayIndexOutOfBoundsException();
    	}
    	int total = 0;
    	for (int i = 0; i < arr.length; i++) {
    		total += arr[i];
    	}
    	return total;
    }
}
