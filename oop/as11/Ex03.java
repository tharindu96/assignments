import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.*;

class Ex03 {

    private static int WINDOW_WIDTH = 640;
    private static int WINDOW_HEIGHT = 480;

    public static String getMessage(int i) {
        if (i == 1) {
            return "Object Oriented Programming";
        } else if (i == 2) {
            return "Data Structures and Algorithms";
        }
        return "";
    }

    public static void main(String[] args) {

        JFrame frame = new JFrame("Ex03");
        frame.setSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        frame.setVisible(true);

        JPanel pnlMain = new JPanel(new BorderLayout());

        frame.add(pnlMain);

        JLabel lblMain = new JLabel("Message Here", SwingConstants.CENTER);
        pnlMain.add(lblMain, BorderLayout.CENTER);

        JPanel pnlButtons = new JPanel();
        pnlMain.add(pnlButtons, BorderLayout.SOUTH);

        JButton btnShowMsg1 = new JButton("Show Message 1");
        JButton btnShowMsg2 = new JButton("Show Message 2");

        pnlButtons.add(btnShowMsg1);
        pnlButtons.add(btnShowMsg2);

        ActionListener listener = new ActionListener(){
        
            @Override
            public void actionPerformed(ActionEvent e) {
                String cmd = e.getActionCommand();
                if (cmd == "Show1") {
                    lblMain.setText(getMessage(1));
                } else if (cmd == "Show2") {
                    lblMain.setText(getMessage(2));
                }
            }
        };

        btnShowMsg1.setActionCommand("Show1");
        btnShowMsg2.setActionCommand("Show2");

        btnShowMsg1.addActionListener(listener);
        btnShowMsg2.addActionListener(listener);

    }

}