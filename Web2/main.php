<?php

    //取得資料庫資訊
    $server="localhost";
    $db_username="root";
    $db_password="";
    $db = "try1";

    

    //連結資料庫 
    $con = mysqli_connect($server,$db_username,$db_password,$db);

    if(!$con){
        die("can't connect".mysqli_error());      
    }
    else if(isset($_POST["Register"])){
        
        //post取得網頁表單資訊
        session_start();
        $username=$_POST['username'];
        $password=$_POST['password'];
        $email=$_POST['email'];
        $gender=$_POST['gender'];
        $color=$_POST['color'];

        
        if($username == ""){
            echo "<script>alert('please enter your name')</script>";
            exit();	
        }
        else if($password == ""){
            echo "<script>alert('please enter your password')</script>";
            exit();	
        }
        else if($email == ""){
            echo "<script>alert('please enter your E-mail')</script>";
            exit();	
        }
        else if($gender == ""){
            echo "<script>alert('please enter your gender')</script>";
            exit();	
        }
        else if($color == ""){
            echo "<script>alert('please enter your favorite color')</script>";
            exit();	
        }
        else{
            $q="insert into infor(username,password,email,gender,color) values ('$username','$password','$email','$gender','$color')";
            $reslut=mysqli_query($con,$q);//執行sql
        }
        
        if(!$reslut){
            die('Error: ' . mysqli_error());//如果sql執行失敗輸出錯誤
        }
        else{
            echo "註冊成功";
            $_SESSION['username'] = $username;

            mysqli_close($con); //關閉資料庫
            header("refresh:0;url=show.php");
        }
        
    }
    else if(isset($_POST["Login"])){
        session_start();
        $username=$_POST['username'];
        $password=$_POST['password'];
        
        if ($username && $password){//如果都不為空
            //檢測資料庫是否有對應的username和password的sql
            $sql = "select * from infor where username = '$username' and password='$password'";
            $result = mysqli_query($con,$sql);
            $rows=mysqli_num_rows($result);//返回一個數值
            if($rows){  //0 false 1 true
                //成功跳轉至show.html頁面
                header("refresh:0;url=show.php");
                exit();
            }
            else{
                echo "原因可能如下.<br>1.使用者名稱或密碼錯誤.<br>2.尚未註冊";
            }
        }
        else{
            echo "尚未輸入使用者名稱或密碼";
        }
    }

    
     mysqli_close($con);   
    

   
?>

