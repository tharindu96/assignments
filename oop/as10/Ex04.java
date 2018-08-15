import java.awt.*;

class Ex04 {
    public static void main(String[] args) {
        new CheckBoxDemo();
    }
}

class CheckBoxDemo {
    CheckBoxDemo() {
        Frame frm = new Frame("CheckBox Setting");

        Panel aPanel = new Panel();

        frm.add(aPanel);

        Label food_pre = new Label("Programming Languages:");

        CheckboxGroup grp = new CheckboxGroup();

        Checkbox chk_java = new Checkbox("Java", grp, false);
        Checkbox chk_c = new Checkbox("C", grp, false);
        Checkbox chk_c_plus = new Checkbox("C++", grp, false);
        Checkbox chk_python = new Checkbox("Python", grp, true);
        Checkbox chk_php = new Checkbox("PHP", grp, false);

        aPanel.add(food_pre);

        aPanel.add(chk_java);
        aPanel.add(chk_c);
        aPanel.add(chk_c_plus);
        aPanel.add(chk_python);
        aPanel.add(chk_php);

        frm.setSize(500, 400);
        frm.setVisible(true);
                
    }
}