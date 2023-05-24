<?php
    if(isset($_COOKIE["AuthKey"])) {
        unset($_COOKIE["AuthKey"]);
        setcookie("AuthKey", "", time() - 3600, "/");
        header("location: login_page.php");
    } else{
        header("location: login_page.php");
    }
?>