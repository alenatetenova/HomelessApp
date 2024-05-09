package org.hse.diplom;

import androidx.room.Entity;
import androidx.room.PrimaryKey;

@Entity(tableName = "ReferenceInfo")
public class ReferenceInfoEntity {
    @PrimaryKey
    private String id;
    private String charityCenterInfo;
    private String actionsInfo;
}