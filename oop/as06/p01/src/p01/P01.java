/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p01;

import java.util.Date;
import java.util.GregorianCalendar;

/**
 *
 * @author bcs2
 */
public class P01 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        Date d = new GregorianCalendar(2014, 5, 31).getTime();
        
        Visit v = new Visit("Jane", Customer.Membership.PREMIUM, d);
        v.setServiceExpense(15000);
        
        System.out.println("Total Charge: " + v.getTotalExpense());
        
    }
    
}
