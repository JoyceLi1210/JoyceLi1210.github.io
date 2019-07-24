package com.example.androidstudio_hw1;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;
import java.text.NumberFormat;

public class count_BMI_BMR extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_count__bmi__bmr);

        TextView text_name = (TextView)findViewById(R.id.text_name);
        TextView text_height = (TextView)findViewById(R.id.text_height);
        TextView text_weight = (TextView)findViewById(R.id.text_weight);
        TextView text_gender = (TextView)findViewById(R.id.text_gender);
        TextView text_age = (TextView)findViewById(R.id.text_age);
        TextView text_bmi = (TextView)findViewById(R.id.text_bmi);
        TextView text_bmr = (TextView)findViewById(R.id.text_bmr);

        // 取得輸入值
        Bundle bundle = getIntent().getExtras();

        // 顯示輸入值
        text_name.setText (bundle.getString("text_name") );
        text_gender.setText (bundle.getString("text_gender") );

        String a = bundle.getString("text_age" );
        text_age.setText (a);
        String h = bundle.getString("text_height");
        text_height.setText (h);
        String w = bundle.getString("text_weight");
        text_weight.setText (w );

        // 取得 身高, 體重, 年齡 數值計算
        float fh = Float.parseFloat(h);
        float fw = Float.parseFloat(w);
        float fa = Float.parseFloat(a);

        NumberFormat nf = NumberFormat.getInstance();   // 數字格式
        nf.setMaximumFractionDigits(2);  // 限制小數第二位

        text_bmi.setText(  nf.format( fw/(fh*fh/10000)  )  );

        if(  bundle.getString("text_gender").equals("Boy") ){
            text_bmr.setText(  nf.format(  66+(13.7*fw)+(5*fh)-(6.8*fa) ) );
        }
        else if (bundle.getString("text_gender").equals("Girl") ){
            text_bmr.setText(  nf.format(  655+(9.6*fw)+(1.8*fh)-(4.7*fa) ) );
        }
    }
}
