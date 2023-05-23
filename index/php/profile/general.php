<div class="content" id="general">
<div class="content_header">
<h1 class="tab_title">General</h1>
<hr>
</div>

<div id="personal">
        <p>Username: <?php echo $username?></p>
        <p>Email: <?php echo $email?></p>
        <p>Password: ***</p>
</div>

<hr class="content_break">

<div id="summary">
        <p>Your time on our website (on the chart you can see your time in minutes):</p>
        <p><?php echo $totalhours?>h <?php echo $minutes?>m</p>

<div id="chart">
        <?php 
                include "components/chart.php"
        ?>
        <script>
                renderchart()
        </script>
</div>


</div>

<hr>

        <div id="top">
                <p id="top-label">Top 3 most played games</p>
                <div id="game">
                        <h2>Snake Game - v1.</h2>
                        <p>A játék a snake játékot próbálja megvalósítani.</p>
                </div>
                <div id="game">
                <h2>Blackjack</h2>
                <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequuntur quaerat saepe nesciunt recusandae consequatur exercitationem nisi reiciendis nemo libero aspernatur, earum nam in inventore possimus vitae amet adipisci sunt molestiae.</p>
                </div>
                <div id="game"></div>
        </div>


</div>