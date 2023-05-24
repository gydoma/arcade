<?php
    require('db.php');
    if (isset($_POST['authkey'])) {
        $authkey = $_POST['authkey'];
        $query    = "SELECT users.UId FROM users INNER JOIN authsessions on users.UId = authsessions.UId WHERE AuthKey like \"$authkey\";";
        $result = mysqli_query($con, $query);
        $rows = mysqli_num_rows($result);
        if(mysqli_num_rows($result) > 0) {
            while($user=mysqli_fetch_array($result)){
                $uid = $user['UId'];
                date_default_timezone_set('Etc/GMT-2');
                $today = date("Y-m-d");
                $dayquery = "SELECT * FROM active_sessions WHERE UId like \"$uid\" AND Date = \"$today\";";
                // echo $dayquery;
                $dayresult = mysqli_query($con, $dayquery);
                $dayrows = mysqli_num_rows($dayresult);
                if(mysqli_num_rows($dayresult) > 0) {
                    echo $dayrows;
                    while($day = mysqli_fetch_array($dayresult)){
                        $newtime = $day['Time'] + 1;
                        $id = $day['Id'];
                        $timequery = "UPDATE `active_sessions` SET `Time` = '$newtime' WHERE `active_sessions`.`Id` = $id;";
                        $timeresult = mysqli_query($con, $timequery);
                    }
                } else{
                    $newquery = "INSERT INTO `active_sessions` (`Id`, `UId`, `Time`, `Date`) VALUES (NULL, '$uid', 1, current_timestamp());";
                    $newresult = mysqli_query($con, $newquery);
                }
            }
        }

    }