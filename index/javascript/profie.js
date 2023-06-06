let current_tab;

const sanitize = (tab) => {
    tab = tab.replace(" ", "_")
    return tab.toLowerCase()
}

document.querySelectorAll(".tab").forEach(element => {
    element.addEventListener("click", () => {
        tab_click(sanitize(element.children[0].innerHTML))
    })
});

function changetab(new_tab) {
    console.log(new_tab)
    switch(new_tab){
        case "change_username":
            new_tab = "chguser";
            break;
        case "change_email":
            new_tab = "chgemail";
            break;
        case "change_password":
            new_tab = "chgpwd";
            break;
        default:
            break;
    }

    if(new_tab != "sign_out"){
    if(current_tab != new_tab){
    console.log(new_tab)
    document.getElementById(new_tab).style.display = "block";
    if(current_tab){document.getElementById(current_tab).style.display = "none";
    document.getElementById(`${current_tab}btn`).classList.remove("active");};
    current_tab = new_tab
    document.getElementById(`${current_tab}btn`).classList.add("active")
    console.log(new_tab)
    }
} else{
    const modalbox = document.getElementById("signout_modal");
    modalbox.style.display = "block";
    const modal = document.getElementById("modal_content");
    const modalbg = document.getElementById("modal_bg");
    modalbg.onclick = function(event) {
        if (event.target == modalbg) {
          modalbox.style.display = "none";
        }
      }

}
}

function tab_click(new_tab){
    if(new_tab != "sign_out"){
        window.location.replace(`profile.php?page=${new_tab}`) 
    }
}

// window.onload = () => {
//     current_tab = "general"
//     document.getElementById(current_tab).style.display = "block";
//     document.getElementById(`${current_tab}btn`).classList.add("active")
// }

