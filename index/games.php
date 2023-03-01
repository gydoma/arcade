<?php 

    include "db.php";
    if(isset($_GET["min-rating"])){
        $min_star = $_GET['min-rating'];
        $where = false;
        $cond = "";

        if(isset($_GET['name'])){
            if(strlen($_GET['name'] > 0)){
                if($where == false){
                    $cond.=" WHERE name = \"".$_GET['name'] ."\" ";
                    $where = true;
                } else {
                    $cond.=" AND name = \"".$_GET['name'] ."\" ";
                }
            }
        };

        if(isset($_GET['min-rating'])){
            if(!isset($_GET['js'])){
                if($where == false){
                    $cond.=" WHERE language != \"js\" ";
                    $where = true;
                } else {
                    $cond.=" AND language != \"js\" ";
                }
            }
        };

        if(isset($_GET['min-rating'])){
            if(!isset($_GET['exe'])){
                if($where == false){
                    $cond.=" WHERE language != \"cs\" ";
                    $where = true;
                } else {
                    $cond.=" AND language != \"cs\" ";
                }
            }
        };

        if(isset($_GET['min-rating'])){
            if(!isset($_GET['cli'])){ 
                if($where == false){
                    $cond.=" WHERE language != \"py\" ";
                    $where = true;
                } else {
                    $cond.=" AND language != \"py\" ";
                }
            }   
        };


        $games = "
        SELECT * 
        FROM games"
        . (strlen($cond) > 1 ? $cond : " ")
        ."HAVING id IN (SELECT gameid FROM ratings WHERE (SELECT AVG(rating)) >= " . $min_star/10 . " GROUP BY gameid )
        ";
    } else{
        $games = "SELECT * FROM games";
    }
    if($result = mysqli_query($con,$games)){
        if(mysqli_num_rows($result) > 0) {
            while($game=mysqli_fetch_array($result)){
            
                $ratings = "SELECT  cast(AVG(rating) AS DECIMAL(6,1)) AS rating
                FROM ratings
                WHERE gameid = '".$game['id']."'";
                $ratingresult = mysqli_query($con,$ratings);
                $rating = mysqli_fetch_array($ratingresult);
                
                if($rating['rating'] > 4.0){
                    $starimg = "Resources/rating/Full.svg";
                } 
                else if ($rating['rating'] > 3.0){
                    $starimg = "Resources/rating/Half.svg";
                } 
                else {
                    $starimg = "Resources/rating/Empty.svg";
                }

                if($game['language'] == "js" ){
                    $buttonname = "Play";
                    $file_ext = "web";
                } 
                else {
                    $buttonname = "Download";
                    $file_ext = ($game['language'] == "py" ? ".py" : ".exe");
                }

                echo "<div class=\"card roundedcornes shadow game-card card-" . $game['language'] . "\">";
                
                
                echo "<div class=\"card-top\">";
                echo "<div class=\"rating\">";
                echo "<h2>" . $rating['rating'] . "</h2>" ;
                echo "<img src=\"" . $starimg . "\">";
                echo "</div>";
                
                echo "<div class=\"badge\">";
                echo "<div class=\"badge-dot badge-". $game['language'] ."\">"  . "</div>";
                echo $file_ext;
                echo "</div>";
                echo "</div>";
                
                echo "<h2>" . $game['name']. "</h2>";
                echo "<p>" . (strlen($game['description']) > 0 ? $game['description'] : "undefined"). "</p>";
                echo "<div class=\"card-footer\">";
                echo "<p class=\"footer-madeby \">" . "made by " . $game['by'] . "</p>";
                echo "<button class=\"card-button\" onclick=\"window.location.href = '". $game['url'] . "';" ."\">" . $buttonname . "</button>";
                echo "</div>";
                echo "</div>";

            }
        } 
    }

?>