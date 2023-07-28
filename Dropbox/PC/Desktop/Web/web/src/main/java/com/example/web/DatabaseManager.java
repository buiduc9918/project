package com.example.web;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DatabaseManager {
    public static void main(String[] args) {
        // Database credentials
        String jdbcUrl = "jdbc:postgresql://localhost:5432/mydatabase";
        String username = "myuser";
        String password = "secret";

        // Load the PostgreSQL JDBC driver
        try {
            Class.forName("org.postgresql.Driver");
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
            return;
        }

        // Establish the connection
        try {
            Connection connection = DriverManager.getConnection(jdbcUrl, username, password);

            // Perform database operations here

            connection.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
