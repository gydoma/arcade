<!DOCTYPE html>
<html lang="en" data-theme="light">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="/index/style.css">
</head>
<body>
    <?php include 'navbar.php'?>
    <script src="javascript/darkmode.js" onload="darkmodecheck()"></script>
    <?php include 'php/christmas.php'?>

    <div class="lrpanel">
        <h2>Sign Up</h2>
        <p>You have chance to create new account if you really want to.</p>
        <form onsubmit="">
        
            <input type="text" id="username" class="lr-input" name="username" placeholder="Username" required>

            <input type="email" id="email" class="lr-input" name="email" placeholder="Email Address" required>

            <input type="password" id="password" class="lr-input" name="password" placeholder="Password" required>

            <input type="submit" value="Sign Up">

        </form>
        <p class="switch-lr">You are new? <a class="switch-lr-link" href="login_page.php">Create a new account</a></p>
    </div>

    <?php include 'search.php'; ?>
</body>
</html>