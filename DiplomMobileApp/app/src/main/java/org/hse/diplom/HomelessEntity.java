package org.hse.diplom;

import androidx.room.Entity;
import androidx.room.PrimaryKey;
import androidx.room.ForeignKey;

@Entity(tableName = "Homeless",
        foreignKeys = {
                @ForeignKey(entity = DocumentTypeEntity.class, parentColumns = "id", childColumns = "documentTypeId"),
                @ForeignKey(entity = HomelessStatusEntity.class, parentColumns = "id", childColumns = "homelessStatusId")
        })
public class HomelessEntity {
    @PrimaryKey
    private String id;
    private String name;
    private String surname;
    private String patronymic;
    private String birthDate;
    private String description;
    private String documentTypeId;
    private String documentNumber;
    private String otherDocument;

}