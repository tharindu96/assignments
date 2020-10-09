import java.awt.*;

class Ex03 {
    public static void main(String[] args) {
        new ListDemo();
    }
}

class ListDemo {
    ListDemo() {
        Frame frm = new Frame("Types of Lists");

        Panel aPanel = new Panel();

        frm.add(aPanel);

        Label country = new Label("Country");

        List country_list = new List();
        country_list.add("Sri Lanka");
        country_list.add("India");
        country_list.add("England");
        country_list.add("Australia");

        Label sport = new Label("sport");

        Choice aSport = new Choice();
        aSport.add("Cricket");
        aSport.add("Football");
        aSport.add("Chess");
        aSport.add("Swimming");

        aPanel.add(country);
        aPanel.add(country_list);

        aPanel.add(sport);
        aPanel.add(aSport);

        frm.setSize(400, 200);
        frm.setVisible(true);
                
    }
}