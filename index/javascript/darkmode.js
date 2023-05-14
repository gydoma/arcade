var checkbox = document.querySelector('input[name=mode]');

function darkmodecheck(){
     var sitetheme = getCookie("sitetheme")
    if (!sitetheme) {
        document.cookie = "sitetheme=light; path=/; Secure; SameSite=None;";
    }
    if(sitetheme == "light") {
        checkbox.checked = false
        // trans()
        document.documentElement.setAttribute('data-theme', 'light')
    } else if (sitetheme == "dark"){
        checkbox.checked = true
        // trans()
        document.documentElement.setAttribute('data-theme', 'dark')
        document.getElementById("logo").src = "Resources/logo/logodark.svg"
    }
}

checkbox.addEventListener('change', function() {
    if(this.checked) {
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