import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.*;

class Ex02 extends Canvas {

    private static int WINDOW_WIDTH = 640;
    private static int WINDOW_HEIGHT = 480;

    private int WIDTH = 75;
    private int HEIGHT = 25;
    private Color COLOR = Color.RED;

    public void paint(Graphics g) {
        super.paint(g);

        int x = 50;
        int y = 60;

        g.setColor(COLOR);
        g.fillRect(x, y, WIDTH, HEIGHT);
    }

    public void change() {
        if (COLOR == Color.GREEN) return;
        HEIGHT *= 2;
        WIDTH *= 2;
        COLOR = Color.GREEN;
        repaint();
    }

    public static void main(String[] args) {
        Ex02 ex = new Ex02();

        JFrame frame = new JFrame("Ex01");
        frame.setSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        frame.setVisible(true);
        
        JPanel pnlMain = new JPanel();
        pnlMain.setLayout(new BorderLayout());
        frame.add(pnlMain);
        
        pnlMain.add(ex, BorderLayout.CENTER);

        JButton btnChange = new JButton("Change");
        pnlMain.add(btnChange, BorderLayout.SOUTH);
        btnChange.addActionListener(new ActionListener(){
            @Override
            public void actionPerformed(ActionEvent e) {
                ex.change();
            }
        });
    }

}