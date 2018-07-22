/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p01;

import java.util.Date;

/**
 *
 * @author bcs2
 */
public class Visit {
    
    private Customer customer;
    private Date date;
    private double serviceExpense = 0;

    public Visit(String name, Customer.Membership membership, Date date) {
        customer = new Customer(name);
        customer.setMembership(membership);
        this.date = date;
    }

    public double getServiceExpense() {
        return serviceExpense;
    }

    public void setServiceExpense(double serviceExpense) {
        this.serviceExpense = serviceExpense;
    }
    
    public double getTotalExpense() {
        return this.serviceExpense - (Discount.getServiceDiscountRate(customer.getMembership()) * this.serviceExpense);
    }
    
}
