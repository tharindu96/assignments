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
public class Discount {
    
    private static final double serviceDiscountPremium = 0.2;
    private static final double serviceDiscountGold = 0.15;
    private static final double serviceDiscountSilver = 0.1;
    
    public static double getServiceDiscountRate(Customer.Membership membership) {
        switch (membership) {
            case NONE:
                return 0;
            case SILVER:
                return serviceDiscountSilver;
            case GOLD:
                return serviceDiscountGold;
            case PREMIUM:
                return serviceDiscountPremium;
            default:
                return 0;
        }
    }
    
}
