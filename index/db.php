<?php
$file = fopen(__DIR__ . "\.env", "r");
if ($file) {
    while (($line = fgets($file)) !== false) {
        parse_str($line,$dbcred);
        $sqlhost = (isset($dbcred["sqlhost_"])) ? trim($dbcred["sqlhost_"]) : @$sqlhost; 
        $sqlpwd = (isset($dbcred["sqlpwd_"])) ? trim($dbcred["sqlpwd_"]) : @$sqlpwd; 
        $sqluser = (isset($dbcred["sqluser_"])) ? trim($dbcred["sqluser_"]) : @$sqluser; 
        $sqldb = (isset($dbcred["sqldb_"])) ? trim($dbcred["sqldb_"]) : @$sqldb; 

    }
    fclose($file);
}

    $con = mysqli_connect("$sqlhost","$sqluser","$sqlpwd","$sqldb");
    if (mysqli_connect_errno()){
        echo "Failed to connect to MySQL: " . mysqli_connect_error();
    }
?>