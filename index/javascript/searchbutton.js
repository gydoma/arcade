document.getElementById("filterbtn").addEventListener("click", searchmenu);
const filtermneu = document.getElementById("filtermenu");
const filterbtn = document.getElementById("filterbtn");
const filterbg = document.getElementById("filter_bg");

function searchmenu(){
    if(window.getComputedStyle(filtermneu).display === "none") {
    filtermneu.style.display = "block";
    filterbtn.style.display = "none";
    filterbg.style.display = "block"
    } else {
        filtermneu.style.display = "none"
        filterbtn.style.display = "block"
        filterbg.style.display = "none"
    }
}


window.onclick = function(event) {
    console.log(event.target)
    if(window.getComputedStyle(filtermneu).display === "block") {
    if (event.target == filterbg) {
      filtermneu.style.display = "none";
      filterbtn.style.display = "block"
      filterbg.style.display = "none"
        }
    }
  }
