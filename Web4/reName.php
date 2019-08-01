<?php  
        session_start();
        $new_name = $_POST["new_name"]; 
        $old_name = $_POST["old_name"];


        if(file_exists("./uploadfile/" .$new_name)){ 
           echo "已有相同檔名" ;
        }
        else{
           if(rename( "./uploadfile/"."$old_name", "./uploadfile/"."$new_name")){ 
               echo "成功將 $old_name 改名為 $new_name </br>" ;
               echo "3秒後返回原頁" ;
               //2秒跳頁
               header("refresh:3;url=choose.php");
           }
        }

        

?>