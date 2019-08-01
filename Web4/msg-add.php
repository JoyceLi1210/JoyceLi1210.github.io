<?php
require("Q&A.php");

//設定日期格式
date_default_timezone_set("Asia/Taipei");
$date=date("Y-m-d H:i:s");

$SaveNewMsg=mysqli_query($con,"INSERT INTO ask(username, question, time) 
VALUES('$_SESSION[username]','$_POST[msg]','$date')");

//檢査
//if(!$SaveNewMsg){
//    echo "留言失敗";
//}else{
//    echo "留言成功";
//}

//新增完畢轉回留言板
header('refresh:0;url =Q&A.php');
?>
