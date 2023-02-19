document.getElementById("filter").addEventListener("click", searchmenu);
document.getElementById("filterbtn").addEventListener("click", searchmenu);
document.getElementById("searchbtn").addEventListener("click", searchmenu)
const filtermneu = document.getElementById("filtermenu");

function searchmenu(){
    if(filtermneu.style.display == "none") {
    filtermneu.style.display = "block";
    document.getElementById("filter").style.display = "none";
    } else {
        document.getElementById("filtermenu").style.display = "none"
        document.getElementById("filter").style.display = "block"
    }
}