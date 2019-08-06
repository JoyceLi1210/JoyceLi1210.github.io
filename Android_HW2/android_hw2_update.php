<?php

    //取得資料庫資訊
    $server="localhost";
    $db_username="root";
    $db_password="";
    $db = "android";
    

    //連結資料庫 
    $con = mysqli_connect($server,$db_username,$db_password,$db);

    if(!$con){
        die("can't connect".mysqli_error());      
    }
    else{  //isset($_POST["Register"])
        
        //post取得網頁表單資訊
        $name=$_POST["name"];     
        $height=$_POST["height"];
        $weight=$_POST["weight"];
        $gender=$_POST["gender"];
        $age=$_POST["age"];
        $bmi=$_POST["bmi"];
        $bmr=$_POST["bmr"];
        
        $id=$_POST["id"];
          
    
   
        $q="update hw2 set name=\"".$name."\", height=\"".$height."\", weight=\"".$weight."\", gender=\"".$gender."\", age=\"".$age."\", bmi=\"".$bmi."\", bmr=\"".$bmr."\"  where id=\"".$id."\"";
        $reslut=mysqli_query($con,$q);
 
        //寫入失敗
        if(!$reslut){  
            die('Error: ' . mysqli_error());
            echo $q;
        }
        else{
            echo "成功寫入";          
        }
        mysqli_close($con);
    }
?>