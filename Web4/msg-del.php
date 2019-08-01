<?php
error_reporting(0);

require("Q&A.php");
$username = $_SESSION['username']  ;


//判斷是本人才能刪除
//抓取GET表單的刪除ID


$re = mysqli_query($con,"SELECT username FROM ask WHERE ID='$_GET[id]'") or die("can't connect".mysqli_error());



if($row = mysqli_fetch_array($re)){
    if($row[username] == $username){     
        $reslut = mysqli_query($con,"DELETE FROM ask WHERE ID='$_GET[id]'");
        $reslut = mysqli_query($con,"DELETE FROM reply WHERE reply_id='$_GET[id]'");
        
        echo "<script>alert('成功刪除')</script>";
    }
    else
        echo "<script>alert('非本人,無法刪除')</script>";
}


header("refresh:0;url=Q&A.php");
?>