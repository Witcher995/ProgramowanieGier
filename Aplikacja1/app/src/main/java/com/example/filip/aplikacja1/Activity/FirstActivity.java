package com.example.filip.aplikacja1.Activity;

import android.app.Activity;
import android.opengl.GLSurfaceView;
import android.os.Bundle;

import com.example.filip.aplikacja1.R;
import com.example.filip.aplikacja1.Renderer.TriangleRenderer;


/**
 * Created by Filip on 10.10.2017.
 */




public class FirstActivity extends Activity {
    GLSurfaceView view;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        // Get the view from new_activity.xml
        setContentView(R.layout.activity_first);
        view = new GLSurfaceView(this);
        view.setRenderer(new TriangleRenderer());
        setContentView(view);






    }
}


