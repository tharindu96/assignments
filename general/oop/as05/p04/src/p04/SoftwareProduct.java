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
public class SoftwareProduct extends Product {
    private String operatingSystem;
    private String company;
    private String version;

    public SoftwareProduct(String code, 
            String name, 
            double price, 
            int stock,
            String operatingSystem,
            String company,
            String version) {
        super(code, name, price, stock, ProductType.SOFTWARE);
        this.operatingSystem = operatingSystem;
        this.company = company;
        this.version = version;
    }

    public void setOperatingSystem(String operatingSystem) {
        this.operatingSystem = operatingSystem;
    }

    public String getOperatingSystem() {
        return operatingSystem;
    }

    public String getCompany() {
        return company;
    }

    public void setCompany(String company) {
        this.company = company;
    }

    public String getVersion() {
        return version;
    }

    public void setVersion(String version) {
        this.version = version;
    }
    
}
