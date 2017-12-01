package com.example.filip.aplikacja1.Shapes;

/**
 * Created by Filip on 11.10.2017.
 */


import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.nio.FloatBuffer;

import javax.microedition.khronos.opengles.GL10;
import javax.microedition.khronos.opengles.GL11;

public class Triangle {

    private FloatBuffer mFVertexBuffer; //bufor przechowujący współrzędne wierzchołków
    private FloatBuffer mColorBuffer;

    public Triangle() {


        float triangleCoords[] = {
                // X, Y, Z
                -0.5f, -0.29f, 0,
                0.5f, -0.29f, 0,
                0.0f, 0.42f, 0,


        };

/*



        float vertices[] = {
                -0.05f, -0.029f, -1.0f,
                0.05f, -0.029f, -1.0f,
                0f, 0.058f, -1.0f};
*/


        float colors[] = {
                1, 0, 0, 1,
                0, 1, 0, 1,
                0, 0, 1, 1
        };

        // inicjalizujemy bufor wierzchołków (ilość wsp. * rozmiar typu float)
        ByteBuffer vbb = ByteBuffer.allocateDirect(triangleCoords.length * 4);
        vbb.order(ByteOrder.nativeOrder());// użyj naturalnego porządku bajtów
        mFVertexBuffer = vbb.asFloatBuffer(); // utwórz z ByteBuffer FloatBuffer
        mFVertexBuffer.put(triangleCoords);  // dodaj współrzędne do bufora
        mFVertexBuffer.position(0);  // ustaw pozycję początkową

        mColorBuffer = makeFloatBuffer(colors);
    }

    public void draw(GL10 gl) {
        gl.glVertexPointer(3, GL11.GL_FLOAT, 0, mFVertexBuffer);
        gl.glColorPointer(4, GL11.GL_FLOAT, 0, mColorBuffer);
        //  gl.glDrawElements(GL11.GL_TRIANGLES, 3, GL11.GL_UNSIGNED_BYTE, mIndexBuffer);
        gl.glDrawArrays(GL10.GL_TRIANGLES, 0, 3);

    }

    private static FloatBuffer makeFloatBuffer(float[] arr) {
        ByteBuffer bb = ByteBuffer.allocateDirect(arr.length * 4);
        bb.order(ByteOrder.nativeOrder());
        FloatBuffer fb = bb.asFloatBuffer();
        fb.put(arr);
        fb.position(0);
        return fb;
    }
}