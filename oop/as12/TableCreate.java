import java.sql.*;

public class TableCreate {

    static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";
    static final String DB_URL = "jdbc:mysql://localhost/student_mgt?useSSL=false";

    static final String USER = "test";
    static final String PASS = "testpwd";


    public static void main(String[] args) {
        Connection conn = null;

        try {
            Class.forName("com.mysql.jdbc.Driver");
            System.out.println("Connectiong to the database...");
            conn = DriverManager.getConnection(DB_URL, USER,  PASS);
            createTable(conn);
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        } catch (SQLException e) {
            e.printStackTrace();
        }

    }

    private static void createTable(Connection conn) throws SQLException {
        System.out.println("Creating the table...");
        Statement stmt = conn.createStatement();

        String sql = "CREATE TABLE student_info( " +
        "Index_No varchar(6) PRIMARY KEY, " +
        "Name varchar(20), " + 
        "Age int, " +
        "Home_Town varchar(35) " +
        ")";
        stmt.executeUpdate(sql);

        System.out.println("Successfully created the table!");
    }

}