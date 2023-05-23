<?php
    require('db.php');
    if (isset($_POST['username'])) {
        $username = stripslashes($_REQUEST['username']);    
        $username = mysqli_real_escape_string($con, $username);
        $password = stripslashes($_REQUEST['password']);
        $password = mysqli_real_escape_string($con, $password);

        $query    = "SELECT * FROM `users` WHERE Username='$username'
                     AND Password='" . md5($password) . "'";
        $result = mysqli_query($con, $query);
        $rows = mysqli_num_rows($result);
        if ($rows == 1) {
            $bytes = openssl_random_pseudo_bytes(32);
            $authkeyhash = base64_encode($bytes);
            $expire_date = date("Y-m-d H:i:s", strtotime("+1 week"));
            $uid;
            while($row=mysqli_fetch_array($result)){
                    $uid=$row["UId"];   
                }
            $authsessionquery = "INSERT into `authsessions` (AuthKey, UId, Expire_Date)
            VALUES ('$authkeyhash', '$uid', '$expire_date')";
            mysqli_query($con, $authsessionquery);
            setcookie("AuthKey", $authkeyhash, time() + (86400 * 7), "/"); 
            header("location: index.php");
        } else {
            header("location: login_page.php?status=invalidcred");
        }
    }