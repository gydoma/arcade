<?php
    if (isset($_GET['regstatus'])) {
        $regstatus = $_GET['regstatus'];
    }
?>

<!DOCTYPE html>
<html lang="en" data-theme="light">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Chromium Arcade | Register</title>
    <link rel="stylesheet" href="/index/style.css">


</head>
<body>
    <?php include 'navbar.php'?>
    <script src="javascript/darkmode.js" onload="darkmodecheck()"></script>
    <?php include 'php/christmas.php'?>

    <div class="lrpanel">
        <h2>Sign Up</h2>
        <p>You have chance to create new account if you really want to.</p>
        <form method="post" action="register.php">
        
            <input type="text" id="username" class="lr-input" name="username" placeholder="Username" required>
            <?php
            if(isset($regstatus)) {
                if($regstatus == "takenname") {
                    echo "<p>Foglalt Felhasználó név</p>";
                    }
                } 
            ?>

            <input type="email" id="email" class="lr-input" name="email" placeholder="Email Address" required>
            <div id="email_error"></div>

            <input type="password" id="password" class="lr-input" name="password" placeholder="●●●●●●●●●" required>
            <div id="pwd_error"></div>


            <input type="submit" value="Sign Up" id="regbutton">

        </form>
        <p class="switch-lr">Already have account? <a class="switch-lr-link" href="login_page.php">Login</a></p>
    </div>

    <script src="javascript/registervalideting.js"></script>

</body>
</html>