<?php
    
    session_start();

   if( $realfile = $_SESSION["realfile".$_GET['id']]){
        echo $realfile;
        header("Content-Type: application/force-download");
        header("Content-Disposition: attachment; filename=".($realfile));
        readfile($realfile);


    }   
    else
        echo "not get file";

?>