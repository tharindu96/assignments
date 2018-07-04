/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package p07;

/**
 *
 * @author bcs2
 */
public class MyTime {
    
    private int hour = 0;
    private int minute = 0;
    private int second = 0;

    public MyTime(int hour, int minute, int second) {
        setTime(hour, minute, second);
    }
    
    private void addTime(int hours, int minutes, int seconds) {
        hour += hours;
        minute += minutes;
        second += seconds;
        
        if (second < 0) {
            minutes = second / 60 - 1;
            second = 60 + second;
            minute += minutes;
        }
        
        if (minute < 0) {
            hours = minute / 60 - 1;
            minute = 60 + minute;
            hour += hours;
        }
        
        if (hour < 0) {
            hour = hour % 24;
            hour = 24 + hour;
        }
        
        int rem = second / 60;
        second %= 60;
        
        minute += rem;
        rem = minute / 60;
        minute %= 60;
        
        hour += rem;
        hour %= 24;
    }
    
    public final void setTime(int hour, int minute, int second) {
        setHour(hour);
        setMinute(minute);
        setSecond(second);
    }

    public int getHour() {
        return hour;
    }

    public int getMinute() {
        return minute;
    }

    public int getSecond() {
        return second;
    }

    public void setHour(int hour) {
        if (0 <= hour && hour <= 24)
            this.hour = hour;
        else {
            System.err.println("Invalid Hour");
            System.exit(1);
        }
    }

    public void setMinute(int minute) {
        if (0 <= minute && minute < 60)
            this.minute = minute;
        else {
            System.err.println("Invalid Minute");
            System.exit(1);
        }
    }

    public void setSecond(int second) {
        if (0 <= second && second < 60)
            this.second = second;
        else {
            System.err.println("Invalid Second");
            System.exit(1);
        }
    }

    @Override
    public String toString() {
        String str = "";
        if (hour < 10)
            str += "0";
        str += Integer.toString(hour) + ":";
        if (minute < 10)
            str += "0";
        str += Integer.toString(minute) + ":";
        if (second < 10)
            str += "0";
        str += Integer.toString(second);
        return str;
    }
    
    public MyTime nextSecond() {
        addTime(0, 0, 1);
        return this;
    }
    
    public MyTime nextMinute() {
        addTime(0, 1, 0);
        return this;
    }
    
    public MyTime nextHour() {
        addTime(1, 0, 0);
        return this;
    }
    
    public MyTime previousSecond() {
        addTime(0, 0, -1);
        return this;
    }
    
    public MyTime previousMinute() {
        addTime(0, -1, 0);
        return this;
    }
    
    public MyTime previousHour() {
        addTime(-1, 0, 0);
        return this;
    }
    
}
