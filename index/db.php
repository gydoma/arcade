<?php


        $sqlhost = "pma.adminom.hu";
        $sqlpwd = "Arc4D3";
        $sqluser = "c1752_arcade"; 
        $sqldb = "c1752_arcade"; 
    
    $con = mysqli_connect($sqlhost,$sqluser,$sqlpwd,$sqldb);
    if (mysqli_connect_errno()){
        echo "Failed to connect to MySQL: " . mysqli_connect_error();
    }
?>
