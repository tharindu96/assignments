import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.*;

class Ex04 {

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

        JFrame frame = new JFrame("Ex04");
        frame.setSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        frame.setVisible(true);

        JPanel pnlMain = new JPanel(new FlowLayout(FlowLayout.LEFT));

        frame.add(pnlMain);

        JLabel lblMain = new JLabel("Message Here", SwingConstants.CENTER);
        lblMain.setBackground(Color.BLACK);
        lblMain.setForeground(Color.WHITE);
        lblMain.setOpaque(true);
        lblMain.setPreferredSize(new Dimension(300, 200));
        pnlMain.add(lblMain);


        lblMain.addMouseListener(new MyMouseListener(lblMain));


    }

    static class MyMouseListener implements MouseListener {

        private JLabel lblMain;

        public MyMouseListener(JLabel lbl) {
            lblMain = lbl;
        }

        @Override
        public void mouseClicked(MouseEvent e) {
            lblMain.setText("Clicked!");
        }

        @Override
        public void mouseEntered(MouseEvent e) {
            lblMain.setText("Entered!");
        }

        @Override
        public void mouseExited(MouseEvent e) {
            lblMain.setText("Exited!");
        }

        @Override
        public void mousePressed(MouseEvent e) {
            lblMain.setText("Pressed!");
        }

        @Override
        public void mouseReleased(MouseEvent e) {
            lblMain.setText("Released!");
        }
    }

}