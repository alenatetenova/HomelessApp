package org.hse.diplom;

import androidx.room.Entity;
import androidx.room.PrimaryKey;

@Entity(tableName = "HomelessStatuses")
public class HomelessStatusEntity {
    @PrimaryKey
    private String id;
    private String state;

}