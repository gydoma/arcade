<?php
    require('db.php');
    if (isset($_COOKIE["AuthKey"])) {
        $authkey = $_COOKIE["AuthKey"];
        $query    = "SELECT users.UId FROM users INNER JOIN authsessions on users.UId = authsessions.UId WHERE AuthKey like \"$authkey\";";
        $result = mysqli_query($con, $query);
        $rows = mysqli_num_rows($result);
        if(mysqli_num_rows($result) > 0) {
            while($user=mysqli_fetch_array($result)){
                $uid = $user['UId'];
                $rating = $_POST['rating'];
                $gameid = $_POST['gameid'];
                $ratingquery = "SELECT * FROM ratings WHERE UId like \"$uid\" AND gameid = \"$gameid\";";
                $ratingresult = mysqli_query($con, $ratingquery);
                $ratingrows = mysqli_num_rows($ratingresult);
                if(!mysqli_num_rows($ratingresult) > 0) {
                    $newquery = "INSERT INTO `ratings` (`id`, `rating`, `gameid`, `UId`) VALUES (NULL, '$rating', $gameid, $uid);";
                    $newresult = mysqli_query($con, $newquery);
                }
            }
        }

    }