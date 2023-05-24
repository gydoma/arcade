<?php 
if(!isset($_COOKIE["AuthKey"])) {
    // header("location: login_page.php");
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
    <div class="game-header">
    <?php include 'navbar.php'?>
    <?php include 'php/christmas.php'?>
    </div>

        <div class="game-container shadow roundedcorners">
            <div class="game-content">
            <h1>Game Title</h1>
            <div class="play-container"></div>

            <div class="game-info">
                <div class="game-details">
                    <hr>
                    <h2>Details</h2>
                    <p>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Vero rerum numquam qui illo aliquid eaque at consectetur molestiae facere quos libero</p>
                </div>
                <div class="game-rate">
                    <hr>
                    <h2 class="rate-title">Rate this game</h2>
                    <div class="new_rate">
                        <h2 id="rate">0</h2>
                        <div class="stars">
                            <input type="radio" id="star1" name="rating" value="1" />
                            <input type="radio" id="star2" name="rating" value="2" />
                            <input type="radio" id="star3" name="rating" value="3" />
                            <input type="radio" id="star4" name="rating" value="4" />
                            <input type="radio" id="star5" name="rating" value="5" />
                            <label for="star1">1 star</label>
                            <label for="star2">2 stars</label>
                            <label for="star3">3 stars</label>
                            <label for="star4">4 stars</label>
                            <label for="star5">5 stars</label>
                        </div>
                        <input type="submit" class="submitbtn shadow" id="ratingsubmit" value="Submit">
                    </div>
            </div>
            </div>
    </div>
</div>

    <?php include 'footer.php'; ?>
    
    <script src="javascript/games.js"></script>
    <script src="javascript/rate.js"></script>
    <script src="javascript/darkmode.js" onload="darkmodecheck()"></script>

</body>
</html>