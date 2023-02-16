<?php
$lines = file(__DIR__ . "\.env");
foreach ($lines as $line) {
    [$key, $value] = explode('=', $line, 2);
    $key = trim($key);
    $value = trim($value);

    putenv(sprintf('%s=%s', $key, $value));
    $_ENV[$key] = $value;
    $_SERVER[$key] = $value;
}

    $host = $_ENV['sqlhost'];
    $user = $_ENV['sqluser'];
    $password = $_ENV['sqlpwd'];
    $database = $_ENV['sqldb'];
    
    $con = mysqli_connect($host,$user,$password,$database);
    if (mysqli_connect_errno()){
        echo "Failed to connect to MySQL: " . mysqli_connect_error();
    }
?>
