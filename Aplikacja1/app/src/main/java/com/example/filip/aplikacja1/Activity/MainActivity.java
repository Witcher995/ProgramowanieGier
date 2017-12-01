package com.example.filip.aplikacja1.Activity;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import com.example.filip.aplikacja1.R;

public class MainActivity extends AppCompatActivity {

    public void obslugaPrzycisku1(View v) {


        Intent intent = new Intent(MainActivity.this, FirstActivity.class);
        startActivity(intent);


    }

    public void obslugaPrzycisku2(View v) {
        Intent intent = new Intent(MainActivity.this, SecondActivity.class);
        startActivity(intent);


    }

    public void obslugaPrzycisku3(View v) {
        Intent intent = new Intent(MainActivity.this, ThirdActivity.class);
        startActivity(intent);


    }

    public void obslugaPrzycisku4(View v) {
        Intent intent = new Intent(MainActivity.this, FourthActivity.class);
        startActivity(intent);


    }

    public void obslugaPrzycisku5(View v) {
        Intent intent = new Intent(MainActivity.this, FifthActivity.class);
        startActivity(intent);


    }




    Button b1;
    Button b2;
    Button b3;
    Button b4;
    Button b5;






        @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        b1 = (Button) findViewById(R.id.button1);
        b2 = (Button) findViewById(R.id.button2);
        b3 = (Button) findViewById(R.id.button3);
        b4 = (Button) findViewById(R.id.button4);
        b5 = (Button) findViewById(R.id.button5);

    }
}
