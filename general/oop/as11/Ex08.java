import java.applet.Applet;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Ex08 extends Applet {
    @Override
    public void init() {
        super.init();

        Label lblNum = new Label("Number");
        TextField txtNum = new TextField();
        Button btnCheck = new Button("Check");
        txtNum.setPreferredSize(new Dimension(50, 20));

        Label lblStatus = new Label("status");

        add(lblNum);
        add(txtNum);
        add(btnCheck);
        add(lblStatus);

        btnCheck.addActionListener(new ActionListener(){
        
            @Override
            public void actionPerformed(ActionEvent arg0) {
                int x;
                try {
                    x = Integer.parseInt(txtNum.getText());
                } catch (Exception e) {
                    lblStatus.setText("Invalid Number");
                    return;
                }
                if (isPrime(x)) {
                    lblStatus.setText("IS PRIME");
                } else {
                    lblStatus.setText("NOT PRIME");
                }
            }
        });
    }

    private boolean isPrime(int x) {

        if (x < 2) return false;
        if (x == 2) return true;
        if (x % 2 == 0) return false;

        int i = 3;
        for (; i * i < x; i += 2) {
            if (x % i == 0) {
                return false;
            }
        } 

        return true;
    }

    @Override
    public void start() {
        super.start();
    }

    @Override
    public void stop() {
        super.stop();
    }

    @Override
    public void destroy() {
        super.destroy();
    }
}