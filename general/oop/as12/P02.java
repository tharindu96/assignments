import java.sql.*;

public class P02 {

    static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";
    static final String DB_URL = "jdbc:mysql://localhost/student_mgt?useSSL=false";

    static final String USER = "test";
    static final String PASS = "testpwd";

    private static Connection conn = null;

    public static void main(String[] args) {
        
        try {
            Class.forName("com.mysql.jdbc.Driver");
            System.out.println("Connectiong to the database...");
            conn = DriverManager.getConnection(DB_URL, USER,  PASS);

            conn.setAutoCommit(true);

            insertStudent("SC4444", "Lasith", 22, "Panadura");
            insertStudent("SC1111", "Madushan", 28, "Kalutara");

            deleteStudent("SC4444");
            deleteStudent("SC1111");

            conn.setAutoCommit(false);

            insertStudent("SC4444", "Lasith", 22, "Panadura");
            insertStudent("SC1111", "Madushan", 28, "Kalutara");

            deleteStudent("SC4444");
            deleteStudent("SC1111");

            conn.commit();

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

    public static void deleteStudent(String index) throws SQLException {
        String sql = "DELETE FROM student_info WHERE Index_No = ?";
        PreparedStatement pstmt = conn.prepareStatement(sql);
        pstmt.setString(1, index);
        pstmt.executeUpdate();
    }

}