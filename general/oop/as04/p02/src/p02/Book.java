/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p02;

import java.util.ArrayList;
import java.util.Arrays;

/**
 *
 * @author bcs2
 */
public class Book {
    
    private String name;
    private ArrayList<Author> authors;
    private double price;
    private int qtyInStock;

    public Book(String name, double price, Author... authors) {
        this.name = name;
        this.authors = new ArrayList<>();
        this.authors.addAll(Arrays.asList(authors));
        this.price = price;
    }

    public Book(String name, double price, int qtyInStock, Author... authors) {
        this.name = name;
        this.price = price;
        this.qtyInStock = qtyInStock;
        this.authors = new ArrayList<>();
        this.authors.addAll(Arrays.asList(authors));
    }

    public String getName() {
        return name;
    }

    public ArrayList<Author> getAuthors() {
        return authors;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public int getQtyInStock() {
        return qtyInStock;
    }

    public void setQtyInStock(int qtyInStock) {
        this.qtyInStock = qtyInStock;
    }

    @Override
    public String toString() {
        String str = this.name + " by";
        for (Author a : this.authors) {
            str += ", " + a.toString();
        }
        return str;
    }
    
}
