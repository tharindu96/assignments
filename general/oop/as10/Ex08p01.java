import java.awt.*;
import javax.swing.*;

class Ex08p01 extends JPanel {

    private static Color colors[] = new Color[] {
        Color.RED,
        Color.GREEN,
        Color.BLUE,
        Color.YELLOW,
        Color.CYAN,
        Color.MAGENTA,
        Color.ORANGE,
        Color.PINK
    };

    private static int WINDOW_WIDTH = 640;
    private static int WINDOW_HEIGHT = 480;

    private static int RADIUS = 50;

    private void drawCircle(Graphics g, int x, int y, int radius, Color color) {
        g.setColor(color);
        g.fillOval(x - radius, y - radius, radius * 2, radius * 2);
    }

    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        setBackground(Color.BLACK);

        int startx = RADIUS;
        int starty = RADIUS;

        int dx = RADIUS;
        int dy = RADIUS;

        for (int i = 0; i < colors.length; i++) {
            drawCircle(g, startx, starty, RADIUS, colors[i]);
            drawCircle(g, startx, (RADIUS * (colors.length + 1)) - starty, RADIUS, colors[i]);

            startx += dx;
            starty += dy;
        }


    }

    public static void main(String[] args) {
        JFrame jFrame = new JFrame("First Graphics Test");
        Ex08p01 ex = new Ex08p01();
        jFrame.add(ex);
        jFrame.setSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        jFrame.setVisible(true);
    }
}