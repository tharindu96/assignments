import java.awt.*;
import javax.swing.*;

class Ex01 extends Canvas {

    private static int WINDOW_WIDTH = 640;
    private static int WINDOW_HEIGHT = 480;

    private static int RADIUS = 75;

    private void drawCircle(Graphics g, int x, int y, int radius, Color color) {
        g.setColor(color);
        g.fillOval(x - radius, y - radius, radius*2, radius*2);
    }

    public void paint(Graphics g) {
        super.paint(g);
        setBackground(Color.WHITE);

        int centerx = WINDOW_WIDTH / 2;
        int centery = WINDOW_HEIGHT / 2;

        int dx = 10 * (RADIUS / 16);
        int dy = 10 * (RADIUS / 16);

        int x0 = centerx - dx;
        int y0 = centery - dy;
        drawCircle(g, x0, y0, RADIUS, Color.RED);

        int x1 = centerx + dx;
        int y1 = centery - dy;
        drawCircle(g, x1, y1, RADIUS, Color.GREEN);

        int x2 = centerx;
        int y2 = centery + dy;
        drawCircle(g, x2, y2, RADIUS, Color.BLUE);
    }

    public static void main(String[] args) {
        Ex01 ex = new Ex01();

        JFrame frame = new JFrame("Ex01");
        frame.add(ex);
        frame.setSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        frame.setVisible(true);
    }

}