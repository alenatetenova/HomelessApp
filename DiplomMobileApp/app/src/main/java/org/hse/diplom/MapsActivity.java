package org.hse.diplom;

import androidx.fragment.app.FragmentActivity;
import androidx.navigation.NavController;
import androidx.navigation.fragment.NavHostFragment;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import androidx.appcompat.app.AppCompatActivity;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.fragment.NavHostFragment;
import androidx.navigation.ui.NavigationUI;


import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.yandex.mapkit.MapKitFactory;

import org.hse.diplom.databinding.ActivityMapsBinding;

public class MapsActivity extends FragmentActivity {

    private ActivityMapsBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        binding = ActivityMapsBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        MapKitFactory.setApiKey("eb6c59c5-1cb5-4d28-ae88-3911534cbe1e");



        // SharedPreferences prefs = getPreferences(MODE_PRIVATE);
        // Получаем NavHostFragment
        NavHostFragment navHostFragment = (NavHostFragment) getSupportFragmentManager().findFragmentById(R.id.container);
        // Получаем NavController
        NavController navController = navHostFragment.getNavController();
        // Находим BottomNavigationView
        BottomNavigationView bottomNavigationView = findViewById(R.id.bottom_navigation);
        // Связываем BottomNavigationView с NavController
        NavigationUI.setupWithNavController(bottomNavigationView, navController);


    }
}