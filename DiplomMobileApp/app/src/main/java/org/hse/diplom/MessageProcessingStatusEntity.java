package org.hse.diplom;

import androidx.room.Entity;
import androidx.room.PrimaryKey;

@Entity(tableName = "MessageProcessingStatus")
public class MessageProcessingStatusEntity {
    @PrimaryKey
    private String id;
    private String processingStatus;

}