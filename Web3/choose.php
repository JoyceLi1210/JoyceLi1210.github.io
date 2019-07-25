<!DOCTYPE HTML>
<html lang="en">
	<head>
		<meta charset="UTF-8">
		<title>choose</title>
	</head>
	<body>
        
       <a href="show_person.php"><div class="page">個人資訊</div></a>
       <a href="show_member.php"><div class="page">會員資訊</div></a>
       
       
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
