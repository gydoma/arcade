<?php 
include "db.php";
if(isset($_COOKIE["AuthKey"])) {
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
  }

?>

<nav class="nav flex">
    <img src="Resources/logo/logo.svg" class="navimg" id="logo">
    <div class="button r" id="button-1">
        <input type="checkbox" class="checkbox" name="mode">
            <div class="knobs"></div>
            <div class="layer"></div>
    </div>

    <?php 
include "db.php";
if(isset($_COOKIE["AuthKey"])) {

    ?>

    <div class="userdiv" id="userdiv">
        <img id="notification" class="usernotif" src="Resources/feather/notification.svg">
        <img id="userimg" src="Resources/feather/user.svg">
            <div class="callouts" id="callout-menu">
                <div class="callout">
                    <h1><?php echo $username;?></h1>
                    <p>Email: <?php echo $email;?> </p>
                    <hr>
                    <div class="calloutbtns">
                        <input type="submit" class="callout-button" id="callout-profile" value="My Profile" onclick="window.location.href = 'profile.php'">
                        <input type="submit" class="callout-button" id="callout-signout" value="Sign out" onclick="window.location.href = 'signout.php'">

                </div>
                </div>
            </div>
        <!-- ? Can be deleted, to hide the notification - ID [notification] is only a placeholder, not used in css -->
    </div>
    <?php 
}
    ?>
    <div id="callout_bg"></div>
    <a class="menubutton" id="menubutton">
        <img src="Resources/feather/menu.svg" class="burgermenu">  
    </a>
    <div id="mobilemenu">
        <div id="userdetails">
            <h1><?php echo $username;?></h1>
            <p>Email: <?php echo $email;?> </p>
        </div>

        <div class="menubtns">
                    <input type="submit" class="menu-button" id="menu-profile" value="My Profile" onclick="window.location.href = 'profile.php'">
                    <input type="submit" class="menu-button" id="menu-signout" value="Sign out" onclick="window.location.href = 'signout.php'">
                </div>

        <hr>

        <div class="button r" id="button-1">
        <input type="checkbox" class="checkbox" name="mode-m">
            <div class="knobs"></div>
            <div class="layer"></div>
    </div>
    </div>
</nav>

<script src="javascript/heaader.js"></script>