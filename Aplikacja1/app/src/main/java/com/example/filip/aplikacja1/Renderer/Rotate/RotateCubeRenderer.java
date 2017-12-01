package com.example.filip.aplikacja1.Renderer.Rotate;

import android.opengl.GLSurfaceView;

import com.example.filip.aplikacja1.Shapes.Cube;

import javax.microedition.khronos.egl.EGLConfig;
import javax.microedition.khronos.opengles.GL10;

/**
 * Created by Filip on 12.10.2017.
 */

public class RotateCubeRenderer implements GLSurfaceView.Renderer  {

    private Cube cube;

    public RotateCubeRenderer() {

        cube = new Cube();
    }



    Cube getCube(){
        return cube;
    }

    @Override
    public void onDrawFrame(GL10 gl) {

        gl.glClear(GL10.GL_COLOR_BUFFER_BIT | GL10.GL_DEPTH_BUFFER_BIT);
       // gl.glLoadIdentity();


        //gl.glTranslatef(-1.0f,0.0f,0.0f);
        gl.glRotatef(-1, 1.0f, 1.0f, 1.0f);
        gl.glRotatef(1, 0.0f, 0.0f, 1.0f);
        cube.draw(gl);

      //  gl.glLoadIdentity();





    }

    @Override
    public void onSurfaceChanged(GL10 gl, int width, int height) {

        gl.glViewport(0, 0, width, height);

    }

    @Override
    public void onSurfaceCreated(GL10 gl, EGLConfig config) {
        gl.glClearDepthf(1.0f);
        gl.glDepthFunc(GL10.GL_LEQUAL);
gl.glEnable(GL10.GL_DEPTH_TEST);
        gl.glDepthFunc(GL10.GL_LESS);
        gl.glHint(GL10.GL_PERSPECTIVE_CORRECTION_HINT,
                GL10.GL_NICEST);

        gl.glClear(GL10.GL_COLOR_BUFFER_BIT | GL10.GL_DEPTH_BUFFER_BIT);
        gl.glClearColor(0, 0, 0, 0);




    }

}
