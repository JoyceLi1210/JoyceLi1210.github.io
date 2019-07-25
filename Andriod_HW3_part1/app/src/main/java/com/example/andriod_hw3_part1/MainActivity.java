package com.example.andriod_hw3_part1;

import androidx.appcompat.app.AppCompatActivity;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private ListView mListView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mListView = (ListView) findViewById(R.id.list);
        mListView.setAdapter(new MyAdapter());

    }
    private class MyAdapter extends BaseAdapter {

        ////有多少列
        @Override
        public int getCount() {
            return 4;
        }

        //取得某一列的內容
        @Override
        public Object getItem(int position) {
            return null;
        }

        //取得某一列的 id
        @Override
        public long getItemId(int position) {
            return 0;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            View v = convertView;
            Holder holder;
            if(v == null){
                v = LayoutInflater.from(getApplicationContext()).inflate(R.layout.adapter, null);
                holder = new Holder();
                holder.image = (ImageView) v.findViewById(R.id.image);
                holder.text = (TextView) v.findViewById(R.id.text);
                holder.text2 = (TextView) v.findViewById(R.id.text2);
                holder.text3 = (TextView) v.findViewById(R.id.text3);
                holder.text4 = (TextView) v.findViewById(R.id.text4);

                v.setTag(holder);
            } else{
                holder = (Holder) v.getTag();
            }
            switch(position) {
                case 0:
                    holder.image.setImageResource(R.drawable.father);
                    holder.text.setText("Father");
                    holder.text2.setText("Name : \n\r      Flower_father \n\r      立花仁（花爸）");
                    holder.text3.setText("Height : 165 cm");
                    holder.text4.setText("Weight : 78 kg");
                    break;

                case 1:
                    holder.image.setImageResource(R.drawable.monther);
                    holder.text.setText("Monther");
                    holder.text2.setText("Name : \n\r      Flower_monther \n\r      立花翠（花媽）");
                    holder.text3.setText("Height : 160 cm");
                    holder.text4.setText("Weight : 75 kg");
                    break;

                case 2:
                    holder.image.setImageResource(R.drawable.brother);
                    holder.text.setText("Brother");
                    holder.text2.setText("Name : \n\r      Grapefruit \n\r      立花柚彥（花柚子）");
                    holder.text3.setText("Height : 151 cm");
                    holder.text4.setText("Weight : 50 kg");
                    break;

                case 3:
                    holder.image.setImageResource(R.drawable.sister);
                    holder.text.setText("Sister");
                    holder.text2.setText("Name :\n\r     Orange \n\r     立花蜜柑（花橘子）");
                    holder.text3.setText("Height : 155 cm");
                    holder.text4.setText("Weight : 60 kg");
                    break;


            }
            return v;
        }
        class Holder{
            ImageView image;
            TextView text;
            TextView text2;
            TextView text3;
            TextView text4;
        }
    }

}
