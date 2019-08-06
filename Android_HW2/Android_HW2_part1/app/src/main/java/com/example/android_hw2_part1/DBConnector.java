package com.example.android_hw2_part1;

import android.net.Uri;
import android.util.Log;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;

public class DBConnector {

    // 抓資料
    public static String executeQuery(String query_string) {
        String result = "";
        HttpURLConnection urlConnection=null;
        InputStream is =null;
        try {
            URL url=new URL("http://192.168.1.152/android_hw2_getinfo.php");      //php的位置
            urlConnection=(HttpURLConnection) url.openConnection();  //對資料庫打開連結
            urlConnection.setRequestMethod("POST");
            urlConnection.connect();//接通資料庫
            is = urlConnection.getInputStream();//從database 開啟 stream

            BufferedReader bufReader = new BufferedReader(new InputStreamReader(is, "utf-8"), 8);
            StringBuilder builder = new StringBuilder();
            String line = null;
            while((line = bufReader.readLine()) != null) {
                builder.append(line + "\n");
            }
            is.close();
            result = builder.toString();
        } catch(Exception e) {
            Log.e("log_tag", e.toString());
        }

        return result;
    }

    // 寫進資料庫
    public static String executeUpdate(String name, String height, String weight, String age, String gender, String bmi, String bmr){
        String result = "";
        HttpURLConnection urlConnection=null;
        InputStream is =null;
        OutputStream os =null;
        try {
            URL url=new URL("http://192.168.1.152/android_hw2.php");      //php的位置
            urlConnection=(HttpURLConnection) url.openConnection();  //對資料庫打開連結
            urlConnection.setRequestMethod("POST");
            urlConnection.setDoInput(true); //允許輸入
            urlConnection.setDoOutput(true); //允許輸出

            Uri.Builder build = new Uri.Builder()
                    .appendQueryParameter("name",name)
                    .appendQueryParameter("height",height)
                    .appendQueryParameter("weight",weight)
                    .appendQueryParameter("age",age)
                    .appendQueryParameter("gender",gender)
                    .appendQueryParameter("bmi",bmi)
                    .appendQueryParameter("bmr",bmr);

            String query = build.build().getEncodedQuery();

            os = urlConnection.getOutputStream();
            BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(os,"UTF-8"));

            writer.write(query);
            writer.flush();
            writer.close();

            int respose = urlConnection.getResponseCode();
            if(respose == HttpURLConnection.HTTP_OK){
                BufferedReader br = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()), 8);
            }
            else
                result = "ERROR";

        }catch(Exception e) {
            Log.e("log_tag", e.toString());
        }
        return result;
    }

    //刪除資料
    public static String delete(String id){

        String result = "";
        HttpURLConnection urlConnection=null;
        InputStream is =null;
        OutputStream os =null;
        try {
            URL url=new URL("http://192.168.1.152/android_hw2_delete.php");      //php的位置
            urlConnection=(HttpURLConnection) url.openConnection();  //對資料庫打開連結
            urlConnection.setRequestMethod("POST");
            urlConnection.setDoInput(true); //允許輸入
            urlConnection.setDoOutput(true); //允許輸出

            Uri.Builder build = new Uri.Builder().appendQueryParameter("id",id);
            String query = build.build().getEncodedQuery();

            os = urlConnection.getOutputStream();
            BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(os,"UTF-8"));

            writer.write(query);
            writer.flush();
            writer.close();

            int respose = urlConnection.getResponseCode();
            if(respose == HttpURLConnection.HTTP_OK){
                BufferedReader br = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()), 8);
            }
            else
                result = "ERROR";

        }
        catch(Exception e) {
            Log.e("log_tag", e.toString());
        }
        return result;

    }


    // 抓特定資料
    public static String select(String id) {
        String result = "";
        HttpURLConnection urlConnection=null;
        InputStream is =null;
        OutputStream os =null;
        try {
            URL url=new URL("http://192.168.1.152/android_hw2_select.php");      //php的位置
            urlConnection=(HttpURLConnection) url.openConnection();  //對資料庫打開連結
            urlConnection.setRequestMethod("POST");

            urlConnection.setDoInput(true); //允許輸入
            urlConnection.setDoOutput(true); //允許輸出

            Uri.Builder build = new Uri.Builder().appendQueryParameter("id",id);
            String query = build.build().getEncodedQuery();

            os = urlConnection.getOutputStream();
            BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(os,"UTF-8"));

            writer.write(query);
            writer.flush();
            writer.close();

            int respose = urlConnection.getResponseCode();
            if(respose == HttpURLConnection.HTTP_OK){
                BufferedReader br = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()), 8);
            }

            urlConnection.connect();//接通資料庫
            is = urlConnection.getInputStream();//從database 開啟 stream

            BufferedReader bufReader = new BufferedReader(new InputStreamReader(is, "utf-8"), 8);
            StringBuilder builder = new StringBuilder();
            String line = null;
            while((line = bufReader.readLine()) != null) {
                builder.append(line + "\n");
            }
            is.close();
            result = builder.toString();

        } catch(Exception e) {
            Log.e("log_tag", e.toString());
        }
        return result;
    }

    // 更新資料庫
    public static String Update(String name, String height, String weight, String age, String gender, String bmi, String bmr,String id){
        String result = "";
        HttpURLConnection urlConnection=null;
        InputStream is =null;
        OutputStream os =null;
        try {
            URL url=new URL("http://192.168.1.152/android_hw2_update.php");      //php的位置
            urlConnection=(HttpURLConnection) url.openConnection();  //對資料庫打開連結
            urlConnection.setRequestMethod("POST");
            urlConnection.setDoInput(true); //允許輸入
            urlConnection.setDoOutput(true); //允許輸出

            Uri.Builder build = new Uri.Builder()
                    .appendQueryParameter("name",name)
                    .appendQueryParameter("height",height)
                    .appendQueryParameter("weight",weight)
                    .appendQueryParameter("age",age)
                    .appendQueryParameter("gender",gender)
                    .appendQueryParameter("bmi",bmi)
                    .appendQueryParameter("bmr",bmr)
                    .appendQueryParameter("id",id);

            String query = build.build().getEncodedQuery();

            os = urlConnection.getOutputStream();
            BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(os,"UTF-8"));

            writer.write(query);
            writer.flush();
            writer.close();

            int respose = urlConnection.getResponseCode();
            if(respose == HttpURLConnection.HTTP_OK){
                BufferedReader br = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()), 8);
            }
            else
                result = "ERROR";

        }catch(Exception e) {
            Log.e("log_tag", e.toString());
        }
        return result;
    }
}
