package org.hse.diplom;
import android.content.Context;
import android.provider.ContactsContract;
import android.util.Log;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;

import java.util.List;
public class Repository {
    private HomelessDao dao;

    public Repository() {
    }

    // Метод для получения всех типов документов
    public LiveData<List<DocumentTypeEntity>> getAllDocumentTypes() {
        return dao.getAllDocumentTypes();
    }
}