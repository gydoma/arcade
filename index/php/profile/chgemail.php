<div class="content" id="chgemail">
    <div class="content_header">
    <h1 class="tab_title">Change Email</h1>
    <hr>
    </div>
    <form action="chgemail_post.php" method="post">
    <div class="change_form">
    <p>Current Email</p>
<input type="Email" id="current_Email" class="chg-input" name="email" placeholder="Current Email" required>
<hr class="content_break">
<input type="Email" id="new_Email" class="chg-input" name="new_email" placeholder="New Email" required>
<input type="Email" id="confirm_Email" class="chg-input" name="confirm_new_email" placeholder="Confirm Email" required>
<input type="submit" value="Save">

<?php
    if(isset($_GET['status'])){
        if($_GET['status'] == "sucess"){
            echo "<p>Successful Email Change</p>";
        }
        if($_GET['status'] == "invalid"){
            echo "<p>Invalid Current Email</p>";
        }

        if($_GET['status'] == "different"){
            echo "<p>New Email and Email Confirm doesn't match</p>";
        }
    }
    ?>

    </div>
    </form>
</div>