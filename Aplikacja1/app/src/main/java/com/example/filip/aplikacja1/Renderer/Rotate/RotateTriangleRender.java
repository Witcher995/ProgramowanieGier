package com.example.filip.aplikacja1.Renderer.Rotate;

import com.example.filip.aplikacja1.Renderer.TriangleRenderer;
import com.example.filip.aplikacja1.Shapes.Triangle;
import javax.microedition.khronos.opengles.GL10;
import javax.microedition.khronos.opengles.GL11;

/**
 * Created by Adam Przedlacki on 11.10.2017.
 */

public class RotateTriangleRender extends TriangleRenderer {
    @Override public void onDrawFrame(GL10 gl) {
        gl.glClear(GL11.GL_COLOR_BUFFER_BIT | GL11.GL_DEPTH_BUFFER_BIT);
        gl.glMatrixMode(GL11.GL_MODELVIEW);

        gl.glRotatef(-1, 1.0f, 1.0f, 1.0f);  //

        gl.glEnableClientState(GL11.GL_VERTEX_ARRAY);
        gl.glEnableClientState(GL11.GL_COLOR_ARRAY);
        getTriangle().draw(gl);

        gl.glDisableClientState(GL11.GL_VERTEX_ARRAY);
        gl.glDisableClientState(GL11.GL_COLOR_ARRAY);
    }

}