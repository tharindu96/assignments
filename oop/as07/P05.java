class P05 {
    public static void main(String[] args) {
    	try {
    		long a = Long.parseLong(args[0]);
    		long b = Long.parseLong(args[1]);
    		System.out.println("Total: " + (a + b));
    	} catch (NumberFormatException e) {
			System.out.println("Must be a number");
    	} catch (ArrayIndexOutOfBoundsException e) {
    		System.out.println("Must provide 2 numbers");
    	}
    }
}
