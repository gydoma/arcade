<?php
    include("db.php");
    //account related log
    function accountlog($uid,$event) {
        if(isset($_COOKIE['AuthKey'])){
            global $con;
        $query    = "INSERT into `history` (UId, Type)
        VALUES ('$uid', '$event')";
        $result   = mysqli_query($con, $query);
        }
      }

      function ratinglog($uid,$rating,$desc){
        if(isset($_COOKIE['AuthKey'])){
            global $con;
        $query    = "INSERT into `history` (UId, Type,Description,Value)
        VALUES ('$uid', 'Rating', '$desc', '$rating')";
        $result   = mysqli_query($con, $query);
        }
      }

      
?>