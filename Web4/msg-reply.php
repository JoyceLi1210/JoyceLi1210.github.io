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
        <h3 class="text-center">留言回覆</h3>
        <a href="choose.php" class = "btn btn-default btn-sm"><span class="glyphicon glyphicon-home"></span> 返回選單</a>
        <a href="Q&A.php" class = "btn btn-default btn-sm"><span class="glyphicon glyphicon-comment"></span> 返回留言板</a>
        
        
        <hr>
    <?php
        
        $_SESSION['reply_id'] = $id = $_GET['id'];

        
        $re=mysqli_query($con,"SELECT * FROM reply WHERE reply_id=\"".$_SESSION['reply_id']."\"");
        
    
        if(mysqli_num_rows($re)>0){
             
             while($row=mysqli_fetch_array($re))
             {

                 echo "<div class=\"panel panel-default\">
                 <div class=\"panel-heading\">$row[username] 
                 <span class=\"pull-right\">$row[time]

                 <a href=\"msg-del-reply.php?id=$row[ID]\" class=\"btn btn-danger btn-xs\">
                 DELETE
                 </a>

                <a href=\"msg-edit-reply.php?id=$row[ID]\" class=\"btn btn-warning btn-xs\">
                EDIT
                 </a>
                
                 </span>
                 </div>
                 <div class=\"panel-body\"> $row[answer]
                 </div>
                 </div>";       
             }
        }

        else{  
         echo "<p class=\"text-center\">沒有任何回覆！</p>";
        }
    ?>
            <hr>
            <p class="pull-right">以 <?php echo $username; ?> 的身份回覆</p>
            <h4>新增回覆</h4>
            <form action="msg-add-reply.php" method="post" >
                <textarea name="msg" class="form-control"  ></textarea>
                <br>
                <input type="submit" name="submit" value="送出" class="btn btn-primary btn-sm pull-right">
            </form>
            
            
</div>
</body>

</html>