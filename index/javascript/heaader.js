let calloutvisible = false;

const userdiv = document.getElementById("userimg");
const callout_menu = document.getElementById("callout-menu");
const callout_bg = document.getElementById("callout_bg");


userdiv.addEventListener("click", () => {
    if(calloutvisible == false){
        callout_menu.style.display = "block"
        calloutvisible = true;
        callout_bg.style.display = "block"
    } else{
        callout_menu.style.display = "none"
        calloutvisible = false;
        callout_bg.style.display = "none"
    }
})

callout_bg.onclick = function(event) {
    if (event.target == callout_bg) {
      callout_menu.style.display = "none";
      callout_bg.style.display = "none";
      calloutvisible = false;
    }
  }