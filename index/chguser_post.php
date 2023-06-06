<?php
    require('db.php');
    include('history.php');
    if (isset($_POST['username']) && isset($_POST['new_username']) && isset($_POST['confirm_new_username'])) {
        $username = stripslashes($_REQUEST['username']);
        $username = mysqli_real_escape_string($con, $username);
        $newusername = stripslashes($_REQUEST['new_username']);
        $newusername = mysqli_real_escape_string($con, $newusername);
        $newusernamecon = stripslashes($_REQUEST['confirm_new_username']);
        $newusernamecon = mysqli_real_escape_string($con, $newusernamecon);


        $authkey = $_COOKIE["AuthKey"];
        
        if($newusername == $newusernamecon){
        $query    = "SELECT users.* FROM `users` INNER JOIN authsessions ON users.UId = authsessions.UId WHERE authsessions.AuthKey = \"$authkey\"  AND users.Username = \"$username\"";
        $result = mysqli_query($con, $query);
        $rows = mysqli_num_rows($result);
        if ($rows == 1) {
            $uid;
            while($row=mysqli_fetch_array($result)){
                    $uid=$row["UId"];   
                }
            $chgquery = "UPDATE users SET `Username`= \"$newusername\" WHERE UId = $uid";
            mysqli_query($con, $chgquery);
            accountlog($uid,"Username Change");
            header("location: profile.php?page=change_username&status=sucess");
        } else {
            header("location: profile.php?page=change_username&status=invalid");
        }
    } else {
        header("location: profile.php?page=change_username&status=different");
    }
}
