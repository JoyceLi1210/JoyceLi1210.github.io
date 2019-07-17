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
    else {
        
        $sql = "SELECT username,password,email,gender,color FROM infor";
        $result = $con->query($sql);
        
        session_start();
        $username = $_SESSION["username"];

        if($result->num_rows > 0){        
            while($row = $result->fetch_assoc())
            {
                if($username == $row["username"]){
                    
                    echo   "Username: " .$row["username"]."<br>" ; 
                    echo   "Password: " .$row["password"]."<br>"; 
                    echo   "E-mail: " .$row["email"]."<br>";
                    echo   "Gender: " .$row["gender"]."<br>";
                    echo   "Favorite color : ".$row["color"]."<br>";

                    exit();
                }     
            }
        }
        else
            echo "0 result";
    }
    mysqli_close($con);

?>