function time(authkey){
    const key = authkey;

    setInterval(() => {
        var data = `authkey=${authkey}`;

        var xhr = new XMLHttpRequest();
        xhr.withCredentials = true;
        
        xhr.addEventListener("readystatechange", function() {
          if(this.readyState === 4) {
            console.log(this.responseText);
          }
        });
        
        xhr.open("POST", "tracker.php");
        xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        
        xhr.send(data);
    }, 60000);
}