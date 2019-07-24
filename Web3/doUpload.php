<?php
       
    if ($_FILES['my_file']['error'] === UPLOAD_ERR_OK){

        session_start();
        $UserName = $_SESSION['username'];

        $FileName = $_FILES['my_file']['name'];            
        $Size = ($_FILES['my_file']['size']/1024);
        $UploadTime = date('Y-m-d H:i:s');
        $Tmp_Name = $_FILES['my_file']['tmp_name']; //暫存檔案名稱


        if (file_exists("./uploadfile/" . $FileName)){
            echo "<script>alert('檔案已存在。')</script>";
        } 

        else if($Size >= 30){   
            echo "<script>alert('檔案太大,建議壓縮後上傳。')</script>";
        }

        else{
            move_uploaded_file($Tmp_Name,"./uploadfile/".$FileName);
            echo "<script>alert('成功新增一條記錄')</script>";
        }   
        header("refresh:0;url=choose.php");
    } 
    else {
        echo '錯誤代碼：' . $_FILES['my_file']['error'] . '<br/>';
    }       

    mysqli_close($con);   //關閉資料庫
?>