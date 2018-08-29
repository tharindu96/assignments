import java.awt.*;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

import javax.swing.*;

public class Ex06 {

    private static int WINDOW_WIDTH = 640;
    private static int WINDOW_HEIGHT = 480;

    public static void main(String[] args) {
        JFrame frame = new JFrame("Ex06");
        frame.setSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        frame.setVisible(true);

        JPanel pnlMain = new JPanel(new BorderLayout());
        frame.add(pnlMain);

        JTextField txtMain = new JTextField();
        pnlMain.add(txtMain, BorderLayout.NORTH);

        JLabel lblMain = new JLabel("");
        pnlMain.add(lblMain, BorderLayout.SOUTH);

        txtMain.addKeyListener(new KeyAdapter() {
            @Override
            public void keyPressed(KeyEvent e) {
                if (e.getKeyCode() == KeyEvent.VK_ENTER) {
                    lblMain.setText(txtMain.getText());
                    txtMain.setText("");
                }
            }
        });
    }

}