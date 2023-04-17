let current_tab;

const sanitize = (tab) => {
    tab = tab.replace(" ", "_")
    return tab.toLowerCase()
}

document.querySelectorAll(".tab").forEach(element => {
    element.addEventListener("click", () => {
        changetab(sanitize(element.children[0].innerHTML))
    })
});

function changetab(new_tab) {
    if(current_tab != new_tab){
    document.getElementById(new_tab).style.display = "block";
    document.getElementById(current_tab).style.display = "none";
    current_tab = new_tab
    }
}

window.onload = () => {
    current_tab = "general"
    document.getElementById(current_tab).style.display = "block";
}

