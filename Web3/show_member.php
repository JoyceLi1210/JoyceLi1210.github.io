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
        
        $sql = "SELECT username,email,gender,color FROM info ";
        $result = mysqli_query($con, $sql);
      
    }
    
?>
 

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>資料庫讀取顯示</title>
</head>
 
<body>
  
    <table width="500" border="2">
      <tr>
        <td>Username</td>
        <td>E-mail</td>
        <td>Gender</td>
        <td>Favorite color</td>
      </tr>
      
    <?php
        
        for($i=1 ; $i<$result->num_rows ; $i++){
            $rs=mysqli_fetch_row($result);
    ?>
          <tr>
            <td><?php echo $rs["username"]?></td>
            <td><?php echo $rs["email"]?></td>
            <td><?php echo $rs["gender"]?></td>
            <td><?php echo $rs["color"]?></td>
          </tr>
    <?php
    }
    ?>
    </table>

    <p>&nbsp;</p>
</body>
</html>