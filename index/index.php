<!DOCTYPE html>
<html lang="en" data-theme="light">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Chromium Arcade</title>
    <script async data-id="five-server" src="http://localhost:5555/fiveserver.js"></script>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <?php include 'navbar.php'?>
    <script src="javascript/darkmode.js" onload="darkmodecheck()"></script>
    <?php include 'php/christmas.php'?>
    <h1>This is a Header (1)</h1>
    <h2>But, thiiis... this is too (2)</h2>
    <p>paralelogramma, nah, just paragraph</p>
    <a href="alma.html">Casual link tag</a>
    <br>
    <div class="games">
        <?php include "games.php" ?>
    </div>

    <?php include 'filter.php'; ?>
    <?php include 'search.php'; ?>


    <?php include 'footer.php'; ?>
    
    <!-- <script src="javascript/games.js"></script> -->

</body>
</html>