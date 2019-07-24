<?php
// 開啟伺服器連接
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
        
        $sql = "SELECT username,gender,color,email  FROM infor";
        $rows = mysqli_query($con,$sql);      
        $num = mysqli_num_rows($rows); 

            
    }
?>
 

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>資料庫讀取顯示</title>
</head>
 
<body>
    
    <h1>會員資訊 </h1>
    
    <table width="500" border="2">
      <tr>
        <td>Username</td>
        <td>Gender</td>
        <td>Favorite color</td>
        <td>E-mail</td>
      </tr>
      
    <?php
    //for($i=1 ; $i <mysqli_num_rows($result); $i++){
    //    for($i=1 ; $i<$result->num_rows ; $i++){
        if ($num > 0) { // 顯示每一筆記錄  
        for ($i = 0;$i < $num; $i++ ) {  
            $row=mysqli_fetch_row($rows);
    ?>        
          <tr>
            <td><?php echo $row[0]?></td>
            <td><?php echo $row[1]?></td>
            <td><?php echo $row[2]?></td>
            <td><?php echo $row[3]?></td>         
          </tr>
    <?php
    }
        }
    ?>
    </table>

    <p>&nbsp;</p>
</body>
</html>