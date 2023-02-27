var checkbox = document.querySelector('input[name=mode]');
// document.cookie = "username=John Doe"; 
function darkmodecheck(){
     var sitetheme = getCookie("sitetheme")
    if (!sitetheme) {
        document.cookie = "sitetheme=light; path=/; SameSite=None;";
    }
    if(sitetheme == "light") {
        checkbox.checked = false
        // trans()
        document.documentElement.setAttribute('data-theme', 'light')
    } else {
        checkbox.checked = true
        // trans()
        document.documentElement.setAttribute('data-theme', 'dark')
        document.getElementById("logo").src = "Resources/logo/logodark.svg"
    }
}

checkbox.addEventListener('change', function() {
    if(this.checked) {
        document.cookie = "sitetheme=dark; path=/; SameSite=None;";
        // trans()
        document.documentElement.setAttribute('data-theme', 'dark')
        document.getElementById("logo").src = "Resources/logo/logodark.svg"
    } else {
        document.cookie = "sitetheme=light; path=/; SameSite=None;";
        // trans()
        document.documentElement.setAttribute('data-theme', 'light')
        document.getElementById("logo").src = "Resources/logo/logo.svg"
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