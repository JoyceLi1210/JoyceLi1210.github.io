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
        $result=mysqli_query($con,"SELECT * FROM hw2 WHERE id =\"".$id."\"");
        while($row = $result->fetch_assoc()){
            $tmp[]=$row;
        }
        echo json_encode($tmp);
        mysqli_close($con);
        
    }

    
     
?>