import java.sql.*;

public class InsertStudents {

    static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";
    static final String DB_URL = "jdbc:mysql://localhost/student_mgt?useSSL=false";

    static final String USER = "test";
    static final String PASS = "testpwd";

    private static Connection conn = null;

// SC5678 Michael 28 Colombo
// SC8674 Ann 33 Colombo
// SC9873 Suresh 21 Kelaniya
// SC7634 Kamal 23 Matara

    public static void main(String[] args) {
        
        try {
            Class.forName("com.mysql.jdbc.Driver");
            System.out.println("Connectiong to the database...");
            conn = DriverManager.getConnection(DB_URL, USER,  PASS);

            insertStudent("SC7745", "John", 23, "Kottawa");
            insertStudent("SC5678", "Michael", 28, "Colombo");
            insertStudent("SC8674", "Ann", 33, "Colombo");
            insertStudent("SC9873", "Suresh", 21, "Kelaniya");
            insertStudent("SC7634", "Kamal", 23, "Matara");

        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        } catch (SQLException e) {
            e.printStackTrace();
        }

    }

    public static void insertStudent(String index, String name, int age, String hometown) throws SQLException {

        String sql = "INSERT INTO student_info VALUES (?, ?, ?, ?)";

        PreparedStatement pstmt = conn.prepareStatement(sql);
        pstmt.setString(1, index);
        pstmt.setString(2, name);
        pstmt.setInt(3, age);
        pstmt.setString(4, hometown);

        pstmt.executeUpdate();
    }

}