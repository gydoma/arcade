uname = document.getElementById("username");
email = document.getElementById("email");
pwd = document.getElementById("password");
regbutton = document.getElementById("regbutton")

uname.addEventListener("change", unamecheck);
email.addEventListener("change", emailcheck);
pwd.addEventListener("change", passwordcheck);

function unamecheck(){
    username = uname.value;
    console.log(username);
    if(username.length < 4){
        uname.style.border = "2px solid red";
        regbutton.disabled = true;
    } else {
        uname.style.border = "";
        regbutton.disabled = false;
    }
}

function emailcheck(){
    const validemail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if(!email.value.match(validemail)){
        email.style.border = "2px solid red";
        regbutton.disabled = true;
    } else {
        email.style.border = "";
        regbutton.disabled = false;
    }
}

function passwordcheck(){
    const validpassword = /^(?=.*[0-9])[a-zA-Z0-9!@#$%^&*]{6,32}$/;
    if(!pwd.value.match(validpassword)){
        pwd.style.border = "2px solid red";
        regbutton.disabled = true;
    } else {
        pwd.style.border = "";
        regbutton.disabled = false;
    }
}