<nav class="nav flex">
    <img src="Resources/logo/logo.svg" class="navimg" id="logo">
    <div class="button r" id="button-1">
        <input type="checkbox" class="checkbox" name="mode">
            <div class="knobs"></div>
            <div class="layer"></div>
    </div>

    <div class="userdiv" id="userdiv">
        <img id="notification" class="usernotif" src="Resources/feather/notification.svg">
        <img id="userimg" src="Resources/feather/user.svg">
            <div class="callouts" id="callout-menu">
                <div class="callout">
                    <h1>GyDoma</h1>
                    <p>Email: gydoma@chromiumnetwork.com</p>
                    <hr>
                    <div class="calloutbtns">
                    <input type="submit" class="callout-button" id="callout-profile" value="My Profile">
                    <input type="submit" class="callout-button" id="callout-signout" value="Sign out">
                </div>
                </div>
            </div>
        <!-- ? Can be deleted, to hide the notification - ID [notification] is only a placeholder, not used in css -->
    </div>
    <div id="callout_bg"></div>
    <a href="menu.html" class="menubutton">
        <img src="Resources/feather/menu.svg" class="burgermenu">  
    </a>
</nav>
<script src="javascript/heaader.js"></script>