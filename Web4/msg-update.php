<?php
require("msg-edit.php");

//設定日期格式
date_default_timezone_set("Asia/Taipei");
$date=date("Y-m-d H:i:s");

session_start();
$id = $_SESSION['idd'];


$SaveNewMsg = mysqli_query($con, " UPDATE ask SET question='$_POST[msg]', time='$date' WHERE ID=\"".$id."\"");

//檢査
if(!$SaveNewMsg){
    echo "更新失敗";
}else{
    echo "更新成功";
}


//新增完畢轉回留言板
header('refresh:0; url= Q&A.php');
?>