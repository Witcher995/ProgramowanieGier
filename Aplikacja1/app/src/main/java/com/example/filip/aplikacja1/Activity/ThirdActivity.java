package com.example.filip.aplikacja1.Activity;

import android.app.Activity;
import android.opengl.GLSurfaceView;
import android.os.Bundle;

import com.example.filip.aplikacja1.Renderer.Rotate.RotateCubeRenderer;
import com.example.filip.aplikacja1.R;

/**
 * Created by Filip on 10.10.2017.
 */

public class ThirdActivity extends Activity {
    GLSurfaceView view;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        // Get the view from new_activity.xml
        setContentView(R.layout.activity_third);
        view = new GLSurfaceView(this);
        view.setRenderer(new RotateCubeRenderer());
        setContentView(view);
    }
}


