<?php
    require('db.php');
    include('history.php');
    if (isset($_POST['email']) && isset($_POST['new_email']) && isset($_POST['confirm_new_email'])) {
        $email = stripslashes($_REQUEST['email']);
        $email = mysqli_real_escape_string($con, $email);
        $newemail = stripslashes($_REQUEST['new_email']);
        $newemail = mysqli_real_escape_string($con, $newemail);
        $newemailcon = stripslashes($_REQUEST['confirm_new_email']);
        $newemailcon = mysqli_real_escape_string($con, $newemailcon);


        $authkey = $_COOKIE["AuthKey"];
        
        if($newemail == $newemailcon){
        $query    = "SELECT users.* FROM `users` INNER JOIN authsessions ON users.UId = authsessions.UId WHERE authsessions.AuthKey = \"$authkey\"  AND users.Email = \"$email\"";
        $result = mysqli_query($con, $query);
        $rows = mysqli_num_rows($result);
        if ($rows == 1) {
            $uid;
            while($row=mysqli_fetch_array($result)){
                    $uid=$row["UId"];   
                }
            $chgquery = "UPDATE users SET `Email`= \"$newemail\" WHERE UId = $uid";
            mysqli_query($con, $chgquery);
            accountlog($uid,"Email Change");
            header("location: profile.php?page=change_email&status=sucess");
        } else {
            header("location: profile.php?page=change_email&status=invalid");
        }
    } else {
        header("location: profile.php?page=change_email&status=different");
    }
}
