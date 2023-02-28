document.getElementById("filterbtn").addEventListener("click", searchmenu);
const filtermneu = document.getElementById("filtermenu");

function searchmenu(){
    if(window.getComputedStyle(filtermneu).display === "none") {
    filtermneu.style.display = "block";
    document.getElementById("filterbtn").style.display = "none";
    } else {
        document.getElementById("filtermenu").style.display = "none"
        document.getElementById("filterbtn").style.display = "block"
    }
}