<div class="content" id="chguser">
    <div class="content_header">
    <h1 class="tab_title">Change Username</h1>
    <hr>
    </div>
    <form action="chguser_post.php" method="post">
    <div class="change_form">
    <p>Current Username</p>
<input type="Username" id="current_Username" class="chg-input" name="username" placeholder="Current Username" required>
<hr class="content_break">
<input type="Username" id="new_Username" class="chg-input" name="new_username" placeholder="New Username" required>
<input type="Username" id="confirm_Username" class="chg-input" name="confirm_new_username" placeholder="Confirm Username" required>
<input type="submit" value="Save">

<?php
    if(isset($_GET['status'])){
        if($_GET['status'] == "sucess"){
            echo "<p>Successful username Change</p>";
        }
        if($_GET['status'] == "invalid"){
            echo "<p>Invalid Current username</p>";
        }

        if($_GET['status'] == "different"){
            echo "<p>New username and username Confirm doesn't match</p>";
        }
    }
    ?>

    </div>


    </form>    
</div>