package org.hse.diplom;

import android.os.Bundle;

import androidx.lifecycle.ViewModelProvider;
import androidx.room.Dao;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

import org.hse.diplom.databinding.MessageFragmentBinding;

import java.util.ArrayList;
import java.util.List;

public class MessageFragment extends Fragment {

    private MessageFragmentBinding binding;
    private MyViewModel myViewModel;

    public MessageFragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = MessageFragmentBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        // Инициализация ViewModel
        myViewModel = new ViewModelProvider(this).get(MyViewModel.class);

        // Получение списка документов из ViewModel
        myViewModel.getAllDocumentTypes().observe(getViewLifecycleOwner(), documentTypes -> {
            if (documentTypes != null) {
                // Создание списка строк из списка документов
                List<String> documentTypeNames = new ArrayList<>();
                for (DocumentTypeEntity documentType : documentTypes) {
                    documentTypeNames.add(documentType.getName());
                }
                // Создание ArrayAdapter и привязка к AutoCompleteTextView
                ArrayAdapter<String> adapter = new ArrayAdapter<>(requireContext(), android.R.layout.simple_dropdown_item_1line, documentTypeNames);
                binding.documentTypeAutoCompleteTextView.setAdapter(adapter);
            }
        });
    }
}