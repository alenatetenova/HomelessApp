package org.hse.diplom;

import androidx.room.Entity;
import androidx.room.PrimaryKey;

@Entity(tableName = "HelpPoints")
public class HelpPointEntity {
    @PrimaryKey
    private String id;
    private double pointLocationX;
    private double pointLocationY;
    private String workingHours;
    private String pointName;
    private String address;
    private String pointDescription;

}