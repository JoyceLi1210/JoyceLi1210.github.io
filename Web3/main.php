<?php

    //取得資料庫資訊
    $server="localhost";
    $db_username="root";
    $db_password="";
    $db = "try1";

    //檢查-帳號重複
    function CheckUserName($con,$username) {
        $sql = "SELECT username FROM infor";
        $result =mysqli_query($con,$sql);

            if($result->num_rows > 0){  //num_rows查筆數
                while($row = $result->fetch_assoc()){
                    if($username == $row["username"]){

                        echo "<script>alert('帳號重複')</script>";
                        header("refresh:0;url=main.html");
                        exit();  
                    }     
                }  
            }
    }

    //連結資料庫 
    $con = mysqli_connect($server,$db_username,$db_password,$db);

    if(!$con){
        die("can't connect".mysqli_error());      
    }
    else if(isset($_POST["Register"])){
        
        //post取得網頁表單資訊
        session_start();
        $username=$_POST['username'];
        
        CheckUserName($con,$username); 
        
        $password=$_POST['password'];
        $email=$_POST['email'];
        $gender=$_POST['gender'];
        $color=$_POST['color'];
        
        
        //檢查-資料完整
        if($username == ""){        
            echo "<script>alert('please enter your name')</script>";
            header("refresh:0;url=main.html");	
        }
        else if($password == ""){
            echo "<script>alert('please enter your password')</script>";
            header("refresh:0;url=main.html");	
        }
        else if($email == ""){
            echo "<script>alert('please enter your E-mail')</script>";
            header("refresh:0;url=main.html");
        }
        else if($gender == ""){
            echo "<script>alert('please enter your gender')</script>";
           header("refresh:0;url=main.html");
        }
        else if($color == ""){
            echo "<script>alert('please enter your favorite color')</script>";
            header("refresh:0;url=main.html");
        }
        //寫入資料
        else{      
            $q="insert into infor(username,password,email,gender,color) values ('$username','$password','$email','$gender','$color')";
            $reslut=mysqli_query($con,$q);
        }
  
        //寫入失敗
        if(!$reslut){  
            die('Error: ' . mysqli_error());
        }
        else{
            echo "註冊成功";
            $_SESSION['username'] = $username;
            header("refresh:0;url=choose.html");
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
                $_SESSION['username'] = $username;
                header("refresh:0;url=choose.html");
                exit();
            }
            else{
                echo "<script>alert('原因可能如下:    1.使用者名稱或密碼錯誤    2.尚未註冊')</script>";
                header("refresh:0;url=main.html");
            }
        }
        else{
            echo "<script>alert('尚未輸入使用者名稱或密碼')</script>";
            header("refresh:0;url=main.html");
            
        }
    }

    
     mysqli_close($con);   //關閉資料庫
    

   
?>
