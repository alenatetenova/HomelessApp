package org.hse.diplom;

import androidx.room.Entity;
import androidx.room.PrimaryKey;

@Entity(tableName = "NeedTypes")
public class NeedTypeEntity {
    @PrimaryKey
    private String id;
    private String needType;

}