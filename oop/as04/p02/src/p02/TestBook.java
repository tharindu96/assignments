/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p02;

/**
 *
 * @author bcs2
 */
public class TestBook {
    
    final private static String A_NAME = "author";
    final private static String A_EMAIL = "author@xyz.com";
    final private static char A_GENDER = 'f';
    
    final private static String A2_NAME = "buthor";
    final private static String A2_EMAIL = "buthor@xyz.com";
    final private static char A2_GENDER = 'm';
    
    final private static String B_NAME = "book";
    final private static double B_PRICE = 299.99;
    final private static int B_QTY = 2;
    
    public static void runTests() {
        Author a1 = new Author(A_NAME, A_EMAIL, A_GENDER);
        Author a2 = new Author(A2_NAME, A2_EMAIL, A2_GENDER);
        Book b = new Book(B_NAME, B_PRICE, B_QTY, a1, a2);
        
        System.out.println(b.toString());
    }
    
}
