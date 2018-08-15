import java.awt.GridLayout;

import javax.swing.*;

class Ex05 {
    public static void main(String[] args) {

        JFrame frame = new JFrame();
        frame.setSize(500, 200);
        
        JLabel lblUsername = new JLabel("Username");
        JLabel lblPassword = new JLabel("Password");

        JTextField txtUsername = new JTextField(10);
        JPasswordField txtPassword = new JPasswordField(10);

        JButton btnLogin = new JButton("Login");
        JButton btnCancel = new JButton("Cancel");

        JPanel panel = new JPanel();
        frame.add(panel);

        GridLayout layout = new GridLayout(3, 2);
        panel.setLayout(layout);

        panel.add(lblUsername);
        panel.add(txtUsername);

        panel.add(lblPassword);
        panel.add(txtPassword);

        panel.add(btnLogin);
        panel.add(btnCancel);


        frame.setVisible(true);

    }
}