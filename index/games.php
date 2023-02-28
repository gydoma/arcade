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
                
                echo "<div class=\"card roundedcornes shadow\">";
                echo "<h2>" . $game['name']. "</h2>";
                echo "<p>" . $game['by']. "</p>";
                echo "<p>" . ($rating['rating'] ? $rating['rating'] : "Not rated yet") . "</p>";
                echo "<p>" . $game['language']. "</p>";
                echo "<p>" . $game['engine']. "</p>";
                echo "<p>" . $game['updated']. "</p>";
                echo "</div>";
            }
        } 
    }

?>