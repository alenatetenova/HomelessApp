package org.hse.diplom;

import android.content.Context;

import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;
import androidx.room.TypeConverters;

@Database(entities = { DocumentTypeEntity.class,HomelessEntity.class, HomelessMessageEntity.class,
        MessageProcessingStatusEntity.class, ReferenceInfoEntity.class, HomelessStatusEntity.class, HelpPointEntity.class, NeedTypeEntity.class}, version = 1, exportSchema = false)
@TypeConverters({Conventers.class})
public abstract class DatabaseHelper extends RoomDatabase {
    public static DatabaseHelper instance;
    public static final String DATABASE_NAME = "postgres4";
    private static final Object LOCK = new Object();

    public static DatabaseHelper getInstance(Context context) {
        if (instance == null) {
            synchronized (LOCK) {
                if (instance == null) {
                    instance = Room.databaseBuilder(context.getApplicationContext(),
                                    DatabaseHelper.class, DATABASE_NAME)
                            .build();
                }
            }
        }

        return instance;
    }
}
