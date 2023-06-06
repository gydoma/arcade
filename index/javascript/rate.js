const ratings = document.querySelectorAll('input[name=rating]');
const rate = document.getElementById("rate");
const ratingsubmit = document.getElementById("ratingsubmit");
var current = 0;

ratings.forEach(Element => {
    Element.addEventListener("click", () => {
        rate.textContent= Element.value;
    })
})

ratingsubmit.addEventListener("click", () => {
    if(Array.from(ratings).find(radio => radio.checked)){

        const queryString = window.location.search;
        const urlParams = new URLSearchParams(queryString);
        const gameid = urlParams.get('gameid')
        console.log(gameid)

        current = Array.from(ratings).find(radio => radio.checked).value;

        var data = `rating=${current}&gameid=${gameid}`;

        var xhr = new XMLHttpRequest();
        xhr.withCredentials = true;
        
        xhr.addEventListener("readystatechange", function() {
          if(this.readyState === 4) {
            console.log(this.responseText);
          }
        });
        
        xhr.open("POST", "rating.php");
        xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        
        xhr.send(data);

    }
})