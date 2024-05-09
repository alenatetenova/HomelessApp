package org.hse.diplom;

import android.app.Application;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.LiveData;
import androidx.lifecycle.ViewModel;

import org.hse.diplom.DocumentTypeEntity;
import org.hse.diplom.HelpPointEntity;
import org.hse.diplom.HomelessEntity;
import org.hse.diplom.HomelessMessageEntity;
import org.hse.diplom.HomelessStatusEntity;
import org.hse.diplom.MessageProcessingStatusEntity;
import org.hse.diplom.NeedTypeEntity;
import org.hse.diplom.ReferenceInfoEntity;
import org.hse.diplom.Repository;

import java.util.List;

public class MyViewModel extends ViewModel {
    private Repository repository;

    public MyViewModel() {
        repository = new Repository(); // Создание экземпляра репозитория
    }

    // Метод для получения всех типов документов
    public LiveData<List<DocumentTypeEntity>> getAllDocumentTypes() {
        return repository.getAllDocumentTypes();
    }
}