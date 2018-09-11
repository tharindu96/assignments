import java.sql.*;

public class P01 {

    static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";
    static final String DB_URL = "jdbc:mysql://localhost/test?useSSL=false";

    static final String USER = "test";
    static final String PASS = "testpwd";

    public static void main(String[] args) {
        Connection conn = null;

        try {
            Class.forName("com.mysql.jdbc.Driver");
            System.out.println("Connectiong to the database...");
            conn = DriverManager.getConnection(DB_URL, USER,  PASS);
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        } catch (SQLException e) {
            e.printStackTrace();
        }

    }


}