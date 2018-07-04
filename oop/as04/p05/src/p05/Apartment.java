/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p05;

import java.util.ArrayList;

/**
 *
 * @author bcs2
 */
public class Apartment {
    
    final private static int MAX_RESIDENTS = 10;
    
    private int size;
    private String address;
    private ArrayList<String> residents;
    private int resident_count;

    public Apartment(int size, String address) {
        this.size = size;
        this.address = address;
        resident_count = 0;
        residents = new ArrayList<>(MAX_RESIDENTS);
    }

    public int getSize() {
        return size;
    }

    public String getAddress() {
        return address;
    }
    
    public int getResidentCount() {
        return resident_count;
    }
    
    public void addResident(String name) {
        if (resident_count < MAX_RESIDENTS) {
            residents.add(name);
            resident_count++;
        }
    }
    
    public String getResidentName(int i) {
        if (i >= 0 && i < resident_count) {
            return residents.get(i);
        }
        return null;
    }
    
    public void removeResident(int i) {
        if (i >= 0 && i < resident_count) {
            residents.remove(i);
            resident_count--;
        }
    }

    @Override
    public String toString() {
        String str = "Address: " + address + " | size: " + size + " | residents:";
        str = residents.stream().map((p) -> " , " + p).reduce(str, String::concat);
        return str;
    }
    
}
