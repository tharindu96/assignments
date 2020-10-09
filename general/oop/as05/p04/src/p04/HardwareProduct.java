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
public class HardwareProduct extends Product {
    
    private String hType;
    private String brand;
    
    public HardwareProduct(String code, 
            String name, 
            double price, 
            int stock,
            String type,
            String brand) {
        super(code, name, price, stock, ProductType.HARDWARE);
        hType = type;
        this.brand = brand;
    }

    public String getHType() {
        return hType;
    }

    public void setHType(String hType) {
        this.hType = hType;
    }

    public String getBrand() {
        return brand;
    }

    public void setBrand(String brand) {
        this.brand = brand;
    }
    
    
    
}
