/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p04;

/**
 *
 * @author bcs2
 */
public class BookProduct extends Product {
    
    private String authorName;
    private String publisher;
    private int year;

    public BookProduct(String code, 
            String name, 
            double price, 
            int stock,
            String authorName,
            String publisher,
            int year) {
        super(code, name, price, stock, ProductType.BOOK);
        this.authorName = authorName;
        this.publisher = publisher;
        this.year = year;
    }

    public String getAuthorName() {
        return authorName;
    }

    public void setAuthorName(String authorName) {
        this.authorName = authorName;
    }

    public String getPublisher() {
        return publisher;
    }

    public void setPublisher(String publisher) {
        this.publisher = publisher;
    }

    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        this.year = year;
    }
    
}
