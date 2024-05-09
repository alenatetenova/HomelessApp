package org.hse.diplom;

import static androidx.fragment.app.FragmentManager.TAG;

import android.content.pm.PackageManager;

import android.location.LocationRequest;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.coordinatorlayout.widget.CoordinatorLayout;
import androidx.core.app.ActivityCompat;
import androidx.fragment.app.Fragment;

import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.tasks.CancellationToken;
import com.google.android.gms.tasks.CancellationTokenSource;
import com.google.android.gms.tasks.OnTokenCanceledListener;
import com.yandex.mapkit.Animation;
import com.yandex.mapkit.MapKitFactory;
import com.yandex.mapkit.geometry.Circle;
import com.yandex.mapkit.geometry.Point;
import com.yandex.mapkit.location.FilteringMode;
import com.yandex.mapkit.location.LocationListener;
import com.yandex.mapkit.location.LocationManager;
import com.yandex.mapkit.location.LocationStatus;
import com.yandex.mapkit.location.Location;
import com.yandex.mapkit.map.CameraPosition;

import org.hse.diplom.databinding.MainFragmentBinding;


public class MainFragment extends Fragment {

    private MainFragmentBinding binding;
    private FusedLocationProviderClient fusedLocationClient;
    private static final int MY_PERMISSIONS_REQUEST_LOCATION = 99;
    private static final int MY_PERMISSIONS_REQUEST_BACKGROUND_LOCATION = 66;

    public double loc1x = 58.9999;
    public double loc1y = 58.9999;
    public double loc2x = 58.9999;
    public double loc2y = 58.9999;

    private CoordinatorLayout rootCoordinatorLayout;
    private LocationManager locationManager;
    private LocationListener myLocationListener;
    private Point myLocation;

    private static final double DESIRED_ACCURACY = 0;
    private static final long MINIMAL_TIME = 1000;
    private static final double MINIMAL_DISTANCE = 1;
    private static final boolean USE_IN_BACKGROUND = false;

    public MainFragment() {
        // Required empty public constructor
    }


    public static MainFragment newInstance(String param1, String param2) {
        MainFragment fragment = new MainFragment();
        Bundle args = new Bundle();
        fragment.setArguments(args);
        return fragment;
    }


    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        if (ActivityCompat.checkSelfPermission(requireContext(), android.Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(requireContext(), android.Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            checkLocationPermission();
            return;
        }
        if (myLocation != null) {
            moveCamera(myLocation, 18);
            binding.mapview.getMapWindow().getMap().getMapObjects().addCircle(new Circle(myLocation, 4.0f));

        }

        locationManager = MapKitFactory.getInstance().createLocationManager();
        Log.d("locStatucUpd", "я под локман");

        locationManager.subscribeForLocationUpdates(0,0, 0, true, FilteringMode.OFF, new LocationListener() {
            @Override
            public void onLocationUpdated(@NonNull Location location) {
                Log.d("TagCheck", "LocationUpdated " + location.getPosition().getLongitude());
                Log.d("TagCheck", "LocationUpdated " + location.getPosition().getLatitude());
                if (myLocation == null) {
                    moveCamera(location.getPosition(), 18);
                    binding.mapview.getMapWindow().getMap().getMapObjects().addCircle(new Circle(location.getPosition(), 4.0f));

                }
                myLocation = location.getPosition(); //this user point
            }


            @Override
            public void onLocationStatusUpdated(@NonNull LocationStatus locationStatus) {
            }
        });

    }

    private void checkLocationPermission() {
        ActivityCompat.requestPermissions(
                requireActivity(),
                new String[]{
                        android.Manifest.permission.ACCESS_FINE_LOCATION,
                        android.Manifest.permission.ACCESS_COARSE_LOCATION
                },
                1
        );
    }


    @Override
    public void onStart() {
        super.onStart();
        binding.mapview.onStart();
        MapKitFactory.getInstance().onStart();
        subscribeToLocationUpdate();

    }

    private void subscribeToLocationUpdate() {
        if (locationManager != null && myLocationListener != null) {
            Log.d("locStatucUpd", "я  субскр");
            locationManager.subscribeForLocationUpdates(DESIRED_ACCURACY, MINIMAL_TIME, MINIMAL_DISTANCE, USE_IN_BACKGROUND, FilteringMode.OFF, myLocationListener);
        }
    }

    private void moveCamera(Point point, float zoom) {
        binding.mapview.getMapWindow().getMap().move(
                new CameraPosition(point, zoom, 0.0f, 0.0f),
                new Animation(Animation.Type.SMOOTH, 1),
                null);
    }

    @Override
    public void onStop() {
        super.onStop();
        binding.mapview.onStop();
        MapKitFactory.getInstance().onStop();
        if (locationManager != null)
            locationManager.unsubscribe(myLocationListener);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        MapKitFactory.initialize(requireContext());
        binding = MainFragmentBinding.inflate(getLayoutInflater());
        return binding.getRoot();
    }
}
