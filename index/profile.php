

<?php 
if(!isset($_COOKIE["AuthKey"])) {
    header("location: login_page.php");
    die();
  }
?>


<?php 
include "db.php";
if(isset($_COOKIE["AuthKey"])) {
    $uid;
    $authkey = $_COOKIE["AuthKey"];
    $query    = "SELECT * FROM users INNER JOIN authsessions on users.UId = authsessions.UId WHERE AuthKey like \"$authkey\"";
$result = mysqli_query($con, $query);
$rows = mysqli_num_rows($result);
if(mysqli_num_rows($result) > 0) {
    while($user=mysqli_fetch_array($result)){
        $username = $user['Username'];
        $email = $user['Email'];
        $uid = $user['UId'];
    }
}

$firstdata = true;
$dates = "";
$datas = "";
$totaltime = 0;
$query    = "SELECT * FROM active_sessions WHERE UId = $uid";
$result = mysqli_query($con, $query);
$rows = mysqli_num_rows($result);
if(mysqli_num_rows($result) > 0) {
    while($sess=mysqli_fetch_array($result)){
        if($firstdata == true){
            $dates .= "["."\"".$sess['Date']."\"";
            $datas .= "["."\"".$sess['Time']."\"";
            $firstdata = false;
        } else{
            $dates .= ","."\"".$sess['Date']."\"";
            $datas .= ","."\"".$sess['Time']."\"";
        }
        $totaltime += $sess['Time'];
    }
}
$dates .= "]";
$datas .= "]";

$totalhours = floor($totaltime / 60);
$minutes = $totaltime-($totalhours*60);

  }

?>

<!DOCTYPE html>
<html lang="en" data-theme="light">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Chromium Arcade</title>
    <link rel="stylesheet" href="style.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@500;700;800&display=swap" rel="stylesheet">
</head>
<body>
    <?php include 'navbar.php'?>
    <?php include 'php/christmas.php'?>

    <div class="shadow profile-card">
        <div class="profile-header">
            <h1>Chromium Arcade Settings</h1>
        </div>
        <div class="tabs">
        <div class="tab-container">
                <div class="tab" id="generalbtn">
                    <h3>General</h3>
                </div>
                <div class="tab" id="historybtn">
                    <h3>History</h3>
            </div>
                <div class="tab" id="chguserbtn">
                    <h3>Change Username</h3>
            </div>
                <div class="tab" id="chgemailbtn">
                    <h3>Change Email</h3>
            </div>
                <div class="tab" id="chgpwdbtn">
                    <h3>Change Password</h3>
            </div>
                <!-- <div class="tab" id="dangerzonebtn">
                    <h3>Danger Zone</h3>
            </div>
                <div class="tab" id="helpbtn">
                    <h3>Help</h3>
            </div> -->
                <div class="tab signout" id="signoutbtn">
                    <h3>Sign Out</h3>
            </div>
            </div>
        </div>
        <div class="tab-content">
            <?php 
                include 'php/profile/general.php';
                include 'php/profile/history.php';
                include 'php/profile/chguser.php';
                include 'php/profile/chgemail.php';
                include 'php/profile/chgpwd.php';
                include 'php/profile/signout.php';
            ?>
        </div>
    </div>

    
    <script src="javascript/darkmode.js" onload="darkmodecheck()"></script>
    <script src="javascript/profie.js"></script>

</body>
</html>