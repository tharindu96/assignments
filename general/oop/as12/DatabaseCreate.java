import java.sql.*;

public class DatabaseCreate {

    static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";
    static final String DB_URL = "jdbc:mysql://localhost/?useSSL=false";

    static final String USER = "test";
    static final String PASS = "testpwd";


    public static void main(String[] args) {
        Connection conn = null;

        try {
            Class.forName("com.mysql.jdbc.Driver");
            System.out.println("Connectiong to the database...");
            conn = DriverManager.getConnection(DB_URL, USER,  PASS);
            createDatabase(conn);
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        } catch (SQLException e) {
            e.printStackTrace();
        }

    }

    private static void createDatabase(Connection conn) throws SQLException {
        System.out.println("Creating a database...");
        Statement stmt = conn.createStatement();

        String sql = "CREATE DATABASE student_mgt";
        stmt.executeUpdate(sql);

        System.out.println("Successfully created the database!");
    }

}