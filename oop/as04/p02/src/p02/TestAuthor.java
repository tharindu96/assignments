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
public class TestAuthor {
    
    final private static String NAME = "testName";
    final private static String EMAIL = "test@test.com";
    final private static char GENDER = 'm';
    final private static String EMAIL2 = "xxx@xxx.com";

    public static void runTests() {
        Author author = new Author(NAME, EMAIL, GENDER);
        if (!author.getName().equals(NAME)) {
            System.err.format("ERROR: %s does not match %s\n", author.getName(), NAME);
            return;
        }
        if (!author.getEmail().equals(EMAIL)) {
            System.err.format("ERROR: %s does not match %s\n", author.getEmail(), EMAIL);
            return;
        }
        if (author.getGender() != GENDER) {
            System.err.format("ERROR: %c does not match %c\n", author.getGender(), GENDER);
            return;
        }
        
        author.setEmail(EMAIL2);
        
        if (!author.getEmail().equals(EMAIL2)) {
            System.err.format("ERROR: %s does not match %s\n", author.getEmail(), EMAIL2);
            return;
        }
        
        System.out.println("INFO: TestAuthor passed!");
    }
}
