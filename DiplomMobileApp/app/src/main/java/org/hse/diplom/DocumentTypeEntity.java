package org.hse.diplom;

import androidx.annotation.NonNull;
import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.Index;
import androidx.room.PrimaryKey;
@Entity(tableName = "DocumentTypes")
public class DocumentTypeEntity {
    @PrimaryKey
    private String id;
    private String documentType;


    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getName() {
        return documentType;
    }

    public void setName(String name) {
        this.documentType = name;
    }
}