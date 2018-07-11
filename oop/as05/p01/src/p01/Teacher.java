/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p01;

import java.util.ArrayList;

/**
 *
 * @author bcs2
 */
public class Teacher extends Person {
    
    private int numCourses = 0;
    private ArrayList<String> courses = new ArrayList<>();
    
    Teacher(String name, String address) {
        super(name, address);
    }

    @Override
    public String toString() {
        return "Teacher: " + super.toString();
    }
    
    public boolean addCourse(String course) {
        if (courses.contains(course)) {
            return false;
        }
        courses.add(course);
        numCourses += 1;
        return true;
    }
    
    public boolean removeCourse(String course) {
        if (!courses.contains(course)) {
            return false;
        }
        courses.remove(course);
        return true;
    }
    
}
