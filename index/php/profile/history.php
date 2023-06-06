<div class="content" id="history">
    <div class="content_header">
    <h1 class="tab_title">History</h1>
    <hr>
    </div>

    <ul>    
        <?php
                
                $historyelements    = "SELECT * FROM history WHERE UId = $uid ORDER BY Date DESC;";
                if($result = mysqli_query($con,$historyelements)){
                    if(mysqli_num_rows($result) > 0) {
                        while($historyelement=mysqli_fetch_array($result)){
                        
                            echo "<li>";
                                echo "<div class=\"historyelement\">";
                                echo "<div class=\"historyheader\">";
                                if($historyelement['Type'] == "Rating"){
                                    if ($historyelement['Value'] > 3.9) {
                                        $ratingImg = 'Resources/rating/Full.svg';
                                      } else if ($historyelement['Value'] > 2.9) {
                                        $ratingImg = 'Resources/rating/Half.svg';
                                      } else {
                                        $ratingImg = 'Resources/rating/Empty.svg';
                                      }
                                      $ratingvalue = $historyelement['Value'];
                                      $date = $historyelement['Date'];
                                      $gamename = $historyelement['Description'];
                                      echo "<h2 class=\"historyaction\">Rating:<img id=\"starimg\" src=\"$ratingImg\"> $ratingvalue </h2>";
                                      echo " <p class=\"historydate\">Date: $date</p> ";
                                      echo "</div>";
                                      echo "<p class=\"historydesc\">$gamename</p>";
                                      echo "</div>";
                                } else {
                                    $type = $historyelement['Type'];
                                    $date = $historyelement['Date'];
                                    echo "<h2 class=\"historyaction\">$type</h2>";
                                    echo " <p class=\"historydate\">Date: $date</p> ";
                                    echo "</div>";

                                    echo "</div>";
                                }


                        }
                    } 
                }
        ?>
    </ul>
</div>