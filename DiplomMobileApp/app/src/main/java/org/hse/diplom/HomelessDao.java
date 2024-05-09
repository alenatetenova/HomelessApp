package org.hse.diplom;

import androidx.lifecycle.LiveData;
import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;
import java.util.List;

@Dao
public interface HomelessDao {
    @Query("SELECT * FROM HelpPoints")
    List<HelpPointEntity> getAllHelpPoints();

    @Query("SELECT * FROM NeedTypes")
    List<NeedTypeEntity> getAllNeedTypes();

    @Query("SELECT * FROM MessageProcessingStatus")
    List<MessageProcessingStatusEntity> getAllMessageProcessingStatuses();

    @Query("SELECT * FROM ReferenceInfo")
    List<ReferenceInfoEntity> getAllReferenceInfos();

    @Query("SELECT * FROM DocumentTypes")
    LiveData<List<DocumentTypeEntity>> getAllDocumentTypes();

    @Query("SELECT * FROM Homeless")
    List<HomelessEntity> getAllHomeless();

    @Query("SELECT * FROM HomelessStatuses")
    List<HomelessStatusEntity> getAllHomelessStatuses();

    @Query("SELECT * FROM HomelessMessages")
    List<HomelessMessageEntity> getAllHomelessMessages();

    @Insert
    void insertHomeless(HomelessEntity homeless);

    @Insert
    void insertHomelessMessage(HomelessMessageEntity homelessMessage);
}