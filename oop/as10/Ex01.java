import java.awt.*;

class Ex01 {
    public static void main(String[] args) {
        FrameFirst ff = new FrameFirst();
    }
}

class FrameFirst {
    FrameFirst() {
        Frame frame = new Frame("Welcome");
        frame.setSize(400, 400);

        Panel panelFirst = new Panel();
        frame.add(panelFirst);

        panelFirst.add(new Button("OK"));
        panelFirst.add(new Button("Cancel"));

        frame.setVisible(true);
    }
}