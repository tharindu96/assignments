import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.*;

public class Ex07 {

    private static int WINDOW_WIDTH = 640;
    private static int WINDOW_HEIGHT = 480;

    public static void main(String[] args) {
        JFrame frame = new JFrame();
        frame.setSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        
        JLabel lblNum1 = new JLabel("Number 1");
        JLabel lblNum2 = new JLabel("Number 2");
        JLabel lblAns  = new JLabel("Answer");

        JTextField txtNum1 = new JTextField();
        JTextField txtNum2 = new JTextField();
        JTextField txtAns  = new JTextField();

        JButton btnAdd = new JButton("Add");
        JButton btnClear = new JButton("Clear");

        JPanel panel = new JPanel();
        frame.add(panel);

        GridLayout layout = new GridLayout(4, 2);
        panel.setLayout(layout);

        panel.add(lblNum1);
        panel.add(txtNum1);

        panel.add(lblNum2);
        panel.add(txtNum2);

        panel.add(lblAns);
        panel.add(txtAns);

        panel.add(btnAdd);
        panel.add(btnClear);

        btnAdd.addActionListener(new ActionListener(){
        
            @Override
            public void actionPerformed(ActionEvent e) {
                float n1 = 0;
                float n2 = 0;
                try {
                    n1 = Float.parseFloat(txtNum1.getText());
                    n2 = Float.parseFloat(txtNum2.getText());
                } catch (Exception ex) {
                    System.err.println("Enter a valid number!");
                }
                float ans = n1 + n2;
                txtAns.setText(Float.toString(ans));
            }
        });

        btnClear.addActionListener(new ActionListener(){
        
            @Override
            public void actionPerformed(ActionEvent e) {
                txtNum1.setText("");
                txtNum2.setText("");
                txtAns.setText("");
            }
        });

        frame.setVisible(true);
    }
}