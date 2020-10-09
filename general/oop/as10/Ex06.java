import java.awt.*;
import javax.swing.*;

class Ex06 {
    public static void main(String[] args) {

        JFrame frame = new JFrame();
        frame.setSize(500, 400);
        frame.setVisible(true);

        BorderLayout bl = new BorderLayout();

        JPanel panel = new JPanel();
        panel.setLayout(bl);

        frame.add(panel);

        JButton btnStart = new JButton("Start");

        panel.add(btnStart, BorderLayout.NORTH);
        
        JButton btnEnd = new JButton("End");

        panel.add(btnEnd, BorderLayout.SOUTH);

        // LEFT PANEL

        JPanel lpanel = new JPanel();
        BoxLayout boxl = new BoxLayout(lpanel, BoxLayout.Y_AXIS);
        lpanel.setLayout(boxl);

        JLabel lblLang = new JLabel("Select Language");

        lpanel.add(lblLang);

        JRadioButton rbtnJava = new JRadioButton("Java");
        JRadioButton rbtnC = new JRadioButton("C");
        JRadioButton rbtnCPP = new JRadioButton("C++");
        JRadioButton rbtnPython = new JRadioButton("Python");
        JRadioButton rbtnPHP = new JRadioButton("PHP");
        
        lpanel.add(rbtnJava);
        lpanel.add(rbtnC);
        lpanel.add(rbtnCPP);
        lpanel.add(rbtnPython);
        lpanel.add(rbtnPHP);

        panel.add(lpanel, BorderLayout.WEST);

        // END LEFT PANEL

        // RIGHT PANEL

        JPanel rpanel = new JPanel();

        panel.add(rpanel, BorderLayout.EAST);

        JLabel lblCountry = new JLabel("Select Country");

        rpanel.add(lblCountry);

        // END RIGHT PANEL

        // CENTER PANEL

        JLabel lblWelcome = new JLabel("Welcome", SwingConstants.CENTER);
        lblWelcome.setBackground(Color.yellow);
        lblWelcome.setForeground(Color.blue);
        lblWelcome.setPreferredSize(new Dimension(400, 400));

        panel.add(lblWelcome, BorderLayout.CENTER);

        // END CENTER PANEL

    }
}