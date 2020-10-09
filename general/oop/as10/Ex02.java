import java.awt.*;

class Ex02 {
    public static void main(String[] args) {
        Frame frame = new Frame("Welcome");
        frame.setSize(400, 400);

        Panel panelFirst = new Panel();
        frame.add(panelFirst);

        Label lblName = new Label("Name");
        Label lblAge = new Label("Age");
        Label lblPassword = new Label("Password");

        TextField txtName = new TextField("", 40);
        TextField txtAge = new TextField("", 41);
        TextField txtPassword = new TextField("", 35);
        txtPassword.setEchoChar('*');

        panelFirst.add(lblName);
        panelFirst.add(txtName);

        panelFirst.add(lblAge);
        panelFirst.add(txtAge);

        panelFirst.add(lblPassword);
        panelFirst.add(txtPassword);

        frame.setVisible(true);
    }
}