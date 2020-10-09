/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p01;

import java.util.ArrayList;
import java.util.HashMap;

/**
 *
 * @author bcs2
 */
public class Student extends Person {
    
    private int numCourses = 0;
    private ArrayList<String> courses = new ArrayList<>();
    private ArrayList<Integer> grades = new ArrayList<>();

    public Student(String name, String address) {
        super(name, address);
    }
    
    public void addCourseGrade(String course, int grade) {
        courses.add(course);
        grades.add(grade);
        numCourses += 1;
    }
    
    public void printGrades() {
        for (int i = 0; i < numCourses; i++) {
            System.out.println(courses.get(i) + ": " + grades.get(i));
        }
    }
    
    public double getAverageGrade() {
        double avg = 0;
        for (int i : grades) {
            avg += i;
        }
        avg /= numCourses;
        return avg;
    }

    @Override
    public String toString() {
        return "Student: " + super.toString();
    }
    
    
}
