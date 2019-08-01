<!DOCTYPE HTML>
<html lang="en">
	<head>
		<meta charset="UTF-8">
		<title>choose</title>
		
		<link rel="stylesheet" href="main.css">
		
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <link rel='stylesheet' href='https://use.fontawesome.com/releases/v5.7.0/css/all.css' integrity='sha384-lZN37f5QGtY3VHgisS14W3ExzMWZxybE1SJSEsQp9S+oqd12jhcu+A56Ebc1zFSJ' crossorigin='anonymous'>
    
    
		
	</head>
	<body background="http://file06.16sucai.com/2017/0915/b49b5cb96d139e7db45dede3f82c562d.jpg">
<!--   
       <a href="show_person.php"><div class="page">個人資訊</div></a>
       <a href="show_member.php"><div class="page">會員資訊</div></a>
       <a href="Q&A.php"><div class="page">留言板</div></a>
-->
       
       <a href="show_person.php" class = "btn btn-default btn-sm page"><span class="glyphicon glyphicon-user"></span> 個人資訊</a>
       <a href="show_member.php" class = "btn btn-default btn-sm page"><span class="fas fa-user-friends"></span> 會員資訊</a>
       <a href="Q&A.php" class = "btn btn-default btn-sm page"><span class="glyphicon glyphicon-comment"></span> 留言板</a>
       
       <a href="main.html" class = "btn btn-default btn-sm page"><span class="glyphicon glyphicon-log-out"></span> 登出</a>
       
       <br>
       <br>
       
       <!--檔案上傳-->
       <h1>檔案上傳</h1>
       <a href="insert.php"><div class="page"></div></a>     
       <form action="doUpload.php" method="post" enctype="multipart/form-data">

            <input type="file" name="my_file" id="">
            <input type="submit" value="立即上傳">
    
       </form>
       <br>
       
       
       <!--下載檔案-->
       <h1>檔案下載 </h1>
    
        <table width="500" border="2">
            <tr>
                <td>File Name</td>
                <td>Size (KB)</td>
                <td>Upload Time</td>
                <td>ReName</td>
            </tr>
            <?php
                // 定義要開啟的目錄
                $dir = "./uploadfile";

                // 用 opendir() 開啟目錄，開啟失敗終止程式
                $handle = @opendir($dir) or die("Cannot open " . $dir);
                date_default_timezone_set("Asia/Taipei");
                session_start();
                
                $i = 0;
                while($file = readdir($handle)){
                    // 將 "." 及 ".." 排除不顯示       
                    if($file != "." && $file != ".."){
                        $realfile = $dir . "/" . $file;
                        
                        $i++;
                        $_SESSION["realfile".$i]=$realfile;
                        $_SESSION["old_file".$i]=$file; //
                        
                        $url = "doDownload.php?id=".$i;
                        $url_2 = "reNamePage.php?id=".$i;
                        
                        $fileSize = filesize($realfile)/1024;
                        $Date = date("Y-m-d H:i:s",filemtime($realfile));
                        
                        echo "<tr>";
                        echo    "<td><a href='$url'> $file </a></td>";
                        echo    "<td>$fileSize</td>";
                        echo    "<td>$Date</td>";
                        echo    "<td><a href='$url_2'>修改</a></td>";  //
                        echo "</tr>";
                     }
                }
                closedir($handle);  // 關閉目錄
                ?>
      
        </table>      
	</body>
</html>
