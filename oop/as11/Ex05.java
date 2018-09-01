import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Ex05 extends JFrame implements WindowListener {

    public Ex05() {
        this.addWindowListener(this);
        this.setSize(400, 400);
        this.setVisible(true);
    }

    @Override
    public void windowActivated(WindowEvent e) {
        System.out.println("activated");
    }

    @Override
    public void windowClosed(WindowEvent e) {
        System.out.println("closed");
    }

    @Override
    public void windowClosing(WindowEvent e) {
        System.out.println("closing");
    }

    @Override
    public void windowDeactivated(WindowEvent e) {
        System.out.println("deactivated");
    }

    @Override
    public void windowDeiconified(WindowEvent e) {
        System.out.println("deiconified");
    }

    @Override
    public void windowIconified(WindowEvent e) {
        System.out.println("iconified");
    }

    @Override
    public void windowOpened(WindowEvent e) {
        System.out.println("opened");
    }

    public static void main(String[] args) {
        new Ex05();
    }
}