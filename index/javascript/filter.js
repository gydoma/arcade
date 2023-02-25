const minstar = document.getElementById("min-star");
const starimg = document.getElementById("starimg");
const rating = document.getElementById("rating")

minstar.addEventListener("change", starcheck);

function starcheck(){
    const min = minstar.value;

    rating.innerHTML = min/10;

    if(min >= 50){
        starimg.src = "Resources/rating/Full.svg";
    }

    else if(min >= 30){
        starimg.src = "Resources/rating/Half.svg";
    }

    else{
        starimg.src = "Resources/rating/Empty.svg";
    }
}

starcheck();