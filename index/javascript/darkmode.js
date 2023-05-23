var checkbox = document.querySelector('input[name=mode]');
var checkbox_m = document.querySelector('input[name=mode-m]');

function darkmodecheck(){
     var sitetheme = getCookie("sitetheme")
    if (!sitetheme) {
        document.cookie = "sitetheme=light; path=/; Secure; SameSite=None;";
    }
    if(sitetheme == "light") {
        checkbox.checked = false
        checkbox_m.checked = false
        // trans()
        document.documentElement.setAttribute('data-theme', 'light')
    } else if (sitetheme == "dark"){
        checkbox.checked = true
        checkbox_m.checked = true
        // trans()
        document.documentElement.setAttribute('data-theme', 'dark')
        document.getElementById("logo").src = "Resources/logo/logodark.svg"
    }
}

checkbox.addEventListener('change', function() {
    console.log("asd")
    if(this.checked) {
        console.log(this)
        document.cookie = "sitetheme=dark; path=/; Secure; SameSite=None;";
        // trans()
        document.documentElement.setAttribute('data-theme', 'dark')
        document.getElementById("logo").src = "Resources/logo/logodark.svg"
        document.getElementById("userimg").src = "Resources/feather/userdark.svg"
        document.getElementById("notification").src = "Resources/feather/notification_dark.svg"
    } else {
        document.cookie = "sitetheme=light; path=/; Secure; SameSite=None;";
        // trans()
        document.documentElement.setAttribute('data-theme', 'light')
        document.getElementById("logo").src = "Resources/logo/logo.svg"
        document.getElementById("userimg").src = "Resources/feather/user.svg"
        document.getElementById("notification").src = "Resources/feather/notification.svg"
        
    }
})

checkbox_m.addEventListener('change', function() {
    console.log("asd")
    if(this.checked) {
        console.log(this)
        document.cookie = "sitetheme=dark; path=/; Secure; SameSite=None;";
        // trans()
        document.documentElement.setAttribute('data-theme', 'dark')
        document.getElementById("logo").src = "Resources/logo/logodark.svg"
        document.getElementById("userimg").src = "Resources/feather/userdark.svg"
        document.getElementById("notification").src = "Resources/feather/notification_dark.svg"
    } else {
        document.cookie = "sitetheme=light; path=/; Secure; SameSite=None;";
        // trans()
        document.documentElement.setAttribute('data-theme', 'light')
        document.getElementById("logo").src = "Resources/logo/logo.svg"
        document.getElementById("userimg").src = "Resources/feather/user.svg"
        document.getElementById("notification").src = "Resources/feather/notification.svg"
        
    }
})

window.getCookie = function getCookie(name) {
    let cookie = {};
    document.cookie.split(';').forEach(function(el) {
      let [k,v] = el.split('=');
      cookie[k.trim()] = v;
    })
    return cookie[name];
  }