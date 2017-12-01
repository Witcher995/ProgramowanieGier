package com.example.filip.aplikacja1.Renderer;

/**
 * Created by Filip on 11.10.2017.
 */


import javax.microedition.khronos.egl.EGLConfig;
import javax.microedition.khronos.opengles.GL10;
import javax.microedition.khronos.opengles.GL11;

import android.opengl.GLSurfaceView;

import com.example.filip.aplikacja1.Shapes.Triangle;

public class TriangleRenderer implements GLSurfaceView.Renderer {

    private Triangle triangle;

    public TriangleRenderer() {
        triangle = new Triangle();
    }

    public Triangle getTriangle(){
        return triangle;
    }

    @Override
    public void onDrawFrame(GL10 gl) {

        gl.glClear(GL11.GL_COLOR_BUFFER_BIT | GL11.GL_DEPTH_BUFFER_BIT);

        gl.glMatrixMode(GL11.GL_MODELVIEW);
    //    gl.glLoadIdentity();

        gl.glEnableClientState(GL11.GL_VERTEX_ARRAY);
        gl.glEnableClientState(GL11.GL_COLOR_ARRAY);

        triangle.draw(gl);


        gl.glDisableClientState(GL11.GL_VERTEX_ARRAY);
        gl.glDisableClientState(GL11.GL_COLOR_ARRAY);


    }

    @Override
    public void onSurfaceChanged(GL10 gl, int width, int height) {

        gl.glViewport(0, 0, width, height);

    }

    @Override
    public void onSurfaceCreated(GL10 gl, EGLConfig config) {

        gl.glClearColor(0, 0, 0, 0);




    }

}