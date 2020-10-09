/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p01;

/**
 *
 * @author bcs2
 */
public class Customer {
    
    private String name;
    private Membership membership;
    
    public enum Membership {
        PREMIUM, GOLD, SILVER, NONE
    }

    public Customer(String name) {
        this.name = name;
        this.membership = Membership.NONE;
    }

    public String getName() {
        return name;
    }

    public boolean isMember() {
        return membership != Membership.NONE;
    }

    public void setMembership(Membership membership) {
        this.membership = membership;
    }

    public Membership getMembership() {
        return membership;
    }
    
}
