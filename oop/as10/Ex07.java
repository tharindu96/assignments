import java.awt.*;
import javax.swing.*;

class Ex07 extends JPanel {

    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        setBackground(Color.BLACK);

        g.setColor(Color.YELLOW);
        g.drawLine(30, 40, 100, 200);
        g.drawOval(150, 180, 10, 10);
        g.drawRect(200, 210, 20, 30);

        g.setColor(Color.RED);
        g.fillOval(300, 310, 30, 50);
        g.fillRect(400, 350, 60, 50);

        g.setColor(Color.WHITE);
        g.setFont(new Font("Monospaced", Font.PLAIN, 12));
        g.drawString("Testing Custom Drawing...", 10, 20);
    }

    public static void main(String[] args) {
        JFrame jFrame = new JFrame("First Graphics Test");
        Ex07 ex = new Ex07();
        jFrame.add(ex);
        jFrame.setSize(640, 480);
        jFrame.setVisible(true);
    }
}