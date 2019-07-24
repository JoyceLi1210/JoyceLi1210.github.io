
<?php
    session_start();
    $old_name = $_SESSION["old_file".$_GET['id']];
?>

<!DOCTYPE HTML>
<html lang="en">
	<head>
		<meta charset="UTF-8">
		<title></title>
	</head>
	<body>
        <form action="reName.php" method="post">
            新檔名 :
            <input type ="text" name="new_name" >
            舊檔名 :
            <input type ="text" name="old_name" value=<?php echo "$old_name"; ?> >

            <input type ="submit" value="送出">
        </form>
        

	</body>
</html>
   

    


