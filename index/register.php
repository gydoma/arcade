<?php
  require("db.php");
  include('history.php');
  if (isset($_REQUEST['username'])) {
    $username = stripslashes($_REQUEST['username']);
    $username = mysqli_real_escape_string($con, $username);
    $email    = stripslashes($_REQUEST['email']);
    $email    = mysqli_real_escape_string($con, $email);
    $password = stripslashes($_REQUEST['password']);
    $password = mysqli_real_escape_string($con, $password);
    $create_datetime = date("Y-m-d H:i:s");

    $regquery = "SELECT username FROM users WHERE username='$username'";
    $reguname = mysqli_query($con, $regquery);
    $unamerows = mysqli_num_rows($reguname);
    
    if($unamerows == 0){
        $query    = "INSERT into `users` (Username, Password, Email, CreatedAt)
                    VALUES ('$username', '" . md5($password) . "', '$email', '$create_datetime')";
        $result   = mysqli_query($con, $query);
        if ($result) {
            header("location: login_page.php?status=successreg");
        } else {
            echo "Hiba";
        }
    } else{
        header("location: register_page.php?regstatus=takenname");
    }
}
?>
