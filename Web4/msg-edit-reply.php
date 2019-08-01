<?php 
    error_reporting(0);
    $server="localhost";
    $db_username="root";
    $db_password="";
    $db = "try1";

    $con = mysqli_connect($server,$db_username,$db_password,$db);

    if(!$con){
        die("can't connect".mysqli_error());      
    }

    else{
        mysqli_query($con,"SET NAMES UTF-8");
        session_start();
        $username = $_SESSION['username']  ; 
        
           
        $id = $_GET['id'];
        
        
        $re=mysqli_query($con,"SELECT * FROM reply WHERE ID=\"".$id."\"")or die("can't connect".mysqli_error());
        if($row = mysqli_fetch_array($re)) {
            if($row[username] != $username) {     
               
                echo "<script>alert('非本人,無法編輯')</script>";
                header("refresh:0;url=Q&A.php");
            }
        }              
    }
?>


<!DOCTYPE HTML>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <title></title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
</head>

<body>
    <p class="pull-right">以 <?php echo $username; ?> 的身份編輯</p>
    <h4>編輯留言</h4>
    
    <form action="msg-update-reply.php" method="post">
        <textarea name="msg" class="form-control" >
            <?php     
//                $id = $_GET['id'];
                //echo $id;
                $re=mysqli_query($con,"SELECT * FROM reply WHERE ID=\"".$id."\"")or die("can't connect".mysqli_error());
                if($row = mysqli_fetch_array($re)) {
                    if($row[username] == $username) {     
                        echo  $row[answer];
                        $_SESSION['iddd'] = $row[ID];
                    } 
                } 
                   
            ?>

            </textarea>
        <br>
        <input type="submit" name="submit" value="送出" class="btn btn-primary btn-sm pull-right">
    </form>
</body>

</html>