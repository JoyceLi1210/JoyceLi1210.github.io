

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
    }

?>


<!DOCTYPE html>
<html>

<head>
    <title>Message Board</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
</head>

<body>
    <br><br><br><br>
    <div class="container">
        <h3 class="text-center">會員留言板</h3>
        <a href="choose.php" class = "btn btn-default btn-sm"><span class="glyphicon glyphicon-home"></span> 返回選單</a>
        <hr>

        <?php
            $re=mysqli_query($con,"SELECT * FROM ask");
            //檢査有沒有留言數（ message 資料表的資料筆數是否大於0）
            if(mysqli_num_rows($re)>0){
             //如果有留言，一筆一筆印出留言
             //使用 while 迴圈從 message 資料表一筆一筆讀取留言的方法
                
                
                 while($row=mysqli_fetch_array($re))
                 {
                     //$memberRe=mysqli_query($con,"SELECT * FROM ask WHERE id='$row[ID]'");
                     //$memberRow=mysqli_fetch_array($Re);
                    
                                        
                     echo "<div class=\"panel panel-default\">
                     <div class=\"panel-heading\">$row[username] 
                     <span class=\"pull-right\">$row[time]
                     
                     <a href=\"msg-del.php?id=$row[ID]\" class=\"btn btn-danger btn-xs\">
                     DELETE
                     </a>
                                      
                     
                     <a href=\"msg-reply.php?id=$row[ID]\" class=\"btn btn-success btn-xs\">
                     REPLY
                     </a>
                     
                     <a href=\"msg-edit.php?id=$row[ID]\" class=\"btn btn-warning btn-xs\">
                     EDIT
                     </a>
                     
                     </span>
                     </div>
                     <div class=\"panel-body\"> $row[question]
                     </div>
                     </div>";
                
                 }
            }

            else{
             //沒有留言的話
             echo "<p class=\"text-center\">沒有任何訊息！</p>";
            }
            ?>
            <hr>
            <p class="pull-right">以 <?php echo $username; ?> 的身份留言</p>
            <h4>新增留言</h4>
            <form action="msg-add.php" method="post">
                <textarea name="msg" class="form-control"></textarea>
                <br>
                <input type="submit" name="submit" value="送出" class="btn btn-primary btn-sm pull-right">
            </form>
</div>
</body>

</html>
