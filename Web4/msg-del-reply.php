<?php
error_reporting(0);

require("msg-reply.php");
$username = $_SESSION['username'] ;
$id = $_GET[id];
echo $id;
//判斷是本人才能刪除
//抓取GET表單的刪除ID


$re = mysqli_query($con,"SELECT username FROM reply WHERE ID=\"".$id."\"") or die("can't connect".mysqli_error());



if($row = mysqli_fetch_array($re)){
    if($row[username] == $username){     
        $reslut = mysqli_query($con,"DELETE FROM reply WHERE ID=\"".$id."\"");

        echo "<script>alert('成功刪除')</script>";
    }
    else
        echo "<script>alert('非本人')</script>";
}


header("refresh:0;url=Q&A.php");;
?>