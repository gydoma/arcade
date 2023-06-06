<div class="content" id="chgpwd">
    <div class="content_header">
    <h1 class="tab_title">Change Password</h1>
    <hr>
    </div>

    <form action="chgpwd_post.php" method="post">
    <div class="change_form">
    <p>Current Password</p>
<input type="Password" id="current_Password" class="chg-input" name="password" placeholder="Current Password" required>
<hr class="content_break">
<input type="Password" id="new_Password" class="chg-input" name="new_password" placeholder="New Password" required>
<input type="Password" id="confirm_Password" class="chg-input" name="confirm_new_password" placeholder="Confirm Password" required>
<input type="submit" value="Save">

<?php
    if(isset($_GET['status'])){
        if($_GET['status'] == "sucess"){
            echo "<p>Successful Password Change</p>";
        }
        if($_GET['status'] == "invalid"){
            echo "<p>Invalid Current Password</p>";
        }

        if($_GET['status'] == "different"){
            echo "<p>New password and Password Confirm doesn't match</p>";
        }
    }
    ?>

    </div>
    </form>
</div>