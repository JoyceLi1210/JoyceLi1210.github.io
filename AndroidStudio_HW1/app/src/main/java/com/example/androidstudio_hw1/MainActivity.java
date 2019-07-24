package com.example.androidstudio_hw1;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.view.View;
import android.widget.Button;
import android.os.Bundle;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.os.Bundle;

public class MainActivity extends AppCompatActivity {

    private TextView text_name;
    private TextView text_height;
    private TextView text_weight;
    private TextView text_age;

    boolean boy_state = false;
    boolean girl_state = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        // 取得輸入值
        text_name = findViewById(R.id.name);
        text_height = findViewById(R.id.height);
        text_weight = findViewById(R.id.weight);
        text_age = findViewById(R.id.age);


        final RadioButton boy = (RadioButton)findViewById(R.id.boy);
        final RadioButton girl = (RadioButton)findViewById(R.id.girl);


        RadioGroup rg =(RadioGroup)findViewById(R.id.gender);

        rg.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(RadioGroup group, int checkedId) {
                if(checkedId == boy.getId()){
                    boy_state = true;
                    girl_state = false;
                }
                else if(checkedId == girl.getId()){
                    girl_state = true;
                    boy_state =false;
                }
            }
        });


        Button countPageBtn = (Button)findViewById(R.id.go_click);

        countPageBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this , count_BMI_BMR.class);  // 換頁
                Bundle bundle = new Bundle();  // 傳值

                bundle.putString("text_name", text_name.getText().toString());
                bundle.putString("text_height", text_height.getText().toString());
                bundle.putString("text_weight", text_weight.getText().toString());
                bundle.putString("text_age", text_age.getText().toString());

                if(boy_state == true)
                    bundle.putString("text_gender", boy.getText().toString());
                else if(girl_state == true)
                    bundle.putString("text_gender", girl.getText().toString());

                intent.putExtras(bundle);
                startActivity(intent);

            }
        });
    }
}
