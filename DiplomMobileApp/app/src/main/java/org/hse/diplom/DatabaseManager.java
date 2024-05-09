package org.hse.diplom;

import org.hse.diplom.DocumentTypeEntity;
import org.hse.diplom.HomelessMessageEntity;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.List;

public class DatabaseManager {
    private static final String URL = "jdbc:postgresqlgsss://localhost:5432hhh/postgres455";
    private static final String USER = "postgres";
    private static final String PASSWORD = "0506";

    public List<DocumentTypeEntity> getAllDocumentTypes() {
        List<DocumentTypeEntity> documentTypes = new ArrayList<>();
        try (Connection connection = DriverManager.getConnection(URL, USER, PASSWORD)) {
            String sql = "SELECT * FROM DocumentTypes";
            try (PreparedStatement statement = connection.prepareStatement(sql)) {
                try (ResultSet resultSet = statement.executeQuery()) {
                    while (resultSet.next()) {
                        DocumentTypeEntity documentType = new DocumentTypeEntity();
                        documentType.setId(resultSet.getString("Id"));
                        documentType.setName(resultSet.getString("DocumentType"));
                        documentTypes.add(documentType);
                    }
                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return documentTypes;
    }

    /*
    public void insertHomelessMessage(HomelessMessageEntity homelessMessage) {
        try (Connection connection = DriverManager.getConnection(URL, USER, PASSWORD)) {
            String sql = "INSERT INTO HomelessMessages (Adress, DateTime, HomelessLocationX, HomelessLocationY, HomelessStatusId, " +
                    "MessageStatusId, HomelessSurname, HomelessName, HomelessPatronymic, HomelessBirthDate, HomelessDescription, " +
                    "DocumentTypeId, DocumentNumber, OtherDocument, OtherNeed, NeedTypeId) " +
                    "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            try (PreparedStatement statement = connection.prepareStatement(sql)) {
                statement.setString(1, homelessMessage.getAddress());
                statement.setTimestamp(2, Timestamp.valueOf(homelessMessage.getDateTime()));
                // Установка других значений для вставки
                statement.executeUpdate();
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

     */
}