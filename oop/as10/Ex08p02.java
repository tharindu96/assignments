import java.awt.*;
import javax.swing.*;

class Ex08p02 extends JPanel {

    private static int WINDOW_WIDTH = 640;
    private static int WINDOW_HEIGHT = 480;

    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        setBackground(Color.BLACK);

        int width = 10;
        int height = 10;

        g.setColor(Color.RED);

        int y = 0;

        for (int i = 0; i < 21; i++) {
            g.fill3DRect(0, y, width, height, true);
            width += 10;
            y += height;
        }


    }

    public static void main(String[] args) {
        JFrame jFrame = new JFrame("First Graphics Test");
        Ex08p02 ex = new Ex08p02();
        jFrame.add(ex);
        jFrame.setSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        jFrame.setVisible(true);
    }
}