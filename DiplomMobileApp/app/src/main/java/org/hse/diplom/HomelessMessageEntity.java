package org.hse.diplom;

import androidx.room.Entity;
import androidx.room.PrimaryKey;
import androidx.room.ForeignKey;


@Entity(tableName = "HomelessMessages",
        foreignKeys = {
                @ForeignKey(entity = HomelessStatusEntity.class, parentColumns = "id", childColumns = "homelessStatusId"),
                @ForeignKey(entity = DocumentTypeEntity.class, parentColumns = "id", childColumns = "documentTypeId"),
                @ForeignKey(entity = NeedTypeEntity.class, parentColumns = "id", childColumns = "needTypeId"),
                @ForeignKey(entity = MessageProcessingStatusEntity.class, parentColumns = "id", childColumns = "messageStatusId")
        })
public class HomelessMessageEntity {
    @PrimaryKey
    private String id;
    private String address;
    private String dateTime;
    private double homelessLocationX;
    private double homelessLocationY;
    private String homelessStatusId;
    private String messageStatusId;
    private String homelessSurname;
    private String homelessName;
    private String homelessPatronymic;
    private String homelessBirthDate;
    private String homelessDescription;
    private String documentTypeId;
    private String documentNumber;
    private String otherDocument;
    private String otherNeed;
    private String needTypeId;

    // Добавьте геттеры и сеттеры по необходимости
}