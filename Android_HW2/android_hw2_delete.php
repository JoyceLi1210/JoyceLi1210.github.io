<?php
    //取得資料庫資訊
    $server="localhost";
    $db_username="root";
    $db_password="";
    $db = "android";

    $con = mysqli_connect($server,$db_username,$db_password,$db);

    if(!$con){
        die("can't connect".mysqli_error());      
    }
    else{
        $id=$_POST["id"]; 
        $q="DELETE FROM hw2 WHERE id=\"".$id."\"";
        
        $reslut=mysqli_query($con,$q);
 
        //寫入失敗
        if(!$reslut){  
            die('Error: ' . mysqli_error());
        }
        else{
            echo "成功刪除";          
        }
        mysqli_close($con);
        
    }

    
     
?>