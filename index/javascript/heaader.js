let menuvisible = false;

const userdiv = document.getElementById("userimg");
const callout_menu = document.getElementById("callout-menu");
const callout_bg = document.getElementById("callout_bg");

const menubutton = document.getElementById("menubutton");
const menu_m = document.getElementById("mobilemenu");


userdiv.addEventListener("click", () => {
    if(menuvisible == false){
        callout_menu.style.display = "block"
        menuvisible = true;
        callout_bg.style.display = "block"
    } else{
        callout_menu.style.display = "none"
        menuvisible = false;
        callout_bg.style.display = "none"
    }
})

callout_bg.onclick = function(event) {
    if (event.target == callout_bg) {
      callout_menu.style.display = "none";
      callout_bg.style.display = "none";
      menuvisible = false;
    }
  }

  menubutton.addEventListener("click", () => {
    if(menuvisible == false){
        menu_m.style.display = "block"
        menuvisible = true;
    } else{
        menu_m.style.display = "none"
        menuvisible = false;
    }
})