<?php
    require('db.php');
    include('history.php');
    if (isset($_POST['password']) && isset($_POST['new_password']) && isset($_POST['confirm_new_password'])) {
        $password = stripslashes($_REQUEST['password']);
        $password = mysqli_real_escape_string($con, $password);
        $newpassword = stripslashes($_REQUEST['new_password']);
        $newpassword = mysqli_real_escape_string($con, $newpassword);
        $newpasswordcon = stripslashes($_REQUEST['confirm_new_password']);
        $newpasswordcon = mysqli_real_escape_string($con, $newpasswordcon);


        $authkey = $_COOKIE["AuthKey"];
        
        if($newpassword == $newpasswordcon){
        $query    = "SELECT users.* FROM `users` INNER JOIN authsessions ON users.UId = authsessions.UId WHERE authsessions.AuthKey = \"$authkey\"  AND users.Password = md5(\"$password\")";
        $result = mysqli_query($con, $query);
        $rows = mysqli_num_rows($result);
        if ($rows == 1) {
            $uid;
            while($row=mysqli_fetch_array($result)){
                    $uid=$row["UId"];   
                }
            $chgquery = "UPDATE users SET `Password`= md5(\"$newpassword\") WHERE UId = $uid";
            mysqli_query($con, $chgquery);
            accountlog($uid,"Password Change");
            header("location: profile.php?page=change_password&status=sucess");
        } else {
            header("location: profile.php?page=change_password&status=invalid");
        }
    } else {
        header("location: profile.php?page=change_password&status=different");
    }
}
