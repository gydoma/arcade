/*NE SCROLLOLJON*/
window.onkeydown = function (e) {
    return !(e.code == "ArrowUp" || "ArrowDown" && e.target == document.body);
};


let canvas = document.getElementById('canvas');
let ctx = canvas.getContext('2d');
let random = Math.floor(Math.random() * (1000 - 4000)) + 4000;

/*Játékos rajzolása, ugrás*/
const img = new Image();
const balon = new Image();
const cloud = new Image();
const bird = new Image();
const oil = new Image();
/**/
function skinchange() {
    let ran = Math.round(Math.random());
    if (ran == 1) {
        img.src = "./src/player.png";
    }
    else {
        img.src = "./src/player1.png";
    }

}

class Plr {
    constructor(x, y) {
        this.x = x;
        this.y = y;
        this.height = 33;
        this.width = 91;
    }
    draw() {
        img.height = 50;
        setInterval(skinchange, 400);
        ctx.drawImage(img, this.x, this.y, this.width, this.height);
    }
}

let player = new Plr(0, 30);


function Collison(enx,enw,eny,enh){
    if( player.x>enx+enw        ||
        player.x + player.width < enx   ||
        player.y>eny+enh       ||
        player.y + player.height < eny
        ){}
    else{
        console.log("dadada");
        cancelAnimationFrame(req);
    }
}

function Oilcol(enx,enw,eny,enh){
    if( player.x>enx+enw        ||
        player.x + player.width < enx   ||
        player.y>eny+enh       ||
        player.y + player.height < eny
        ){}
    else{
        oilnu+=100;
    }
}


/*A random blokkok , felhők*/
let enemys = [];
let clouds = [];
let ballons = [];
let bullets = [];
let oils = [];
let boss = [];
ctx.strokeStyle = "red";
class Birds {
    constructor(width , height, speed) {
        this.height = height;
        this.width = width;
        this.x = canvas.width + this.width;
        this.y = Math.floor(Math.random() * (50 - 580)) + 580;;
        this.Sp = speed;
    }
    draw() {
        bird.src = "./src/bird.png";
        ctx.drawImage(bird, this.x, this.y, this.width, this.height);
    }
    slide() {
        this.draw();
        this.x -= this.Sp;
        Collison(this.x,this.width,this.y,this.height);
        ctx.rect(this.x, this.y, this.width, this.height);
        ctx.stroke();
    }
}

class Clouds {
    constructor(width , height, speed) {
        this.width = width;
        this.height = height;
        this.x = canvas.width + this.width;
        this.y = Math.floor(Math.random() * (50 - 580)) + 580;;
        this.Sp = speed;
    }
    draw() {

        cloud.src = "./src/cloud.png";
        ctx.drawImage(cloud, this.x, this.y, this.width, this.height);
    }
    slide() {
        this.draw();
        this.x -= this.Sp;
        ctx.rect(this.x, this.y, this.width, this.height);
        ctx.stroke();
    }
}

class Baloons {
    constructor(width , height, speed) {
        this.height = height;
        this.width = width;
        this.x = canvas.width + this.width;
        this.y = Math.floor(Math.random() * (0 - 250)) + 250;;
        this.Sp = speed;
    }
    draw() {
        balon.src = "./src/balonred.png"
        ctx.drawImage(balon, this.x, this.y, this.width, this.height);
    }
    slide() {
        this.draw();
        this.x -= this.Sp;
        Collison(this.x,this.width,this.y,this.height);
        ctx.rect(this.x, this.y, this.width, this.height);
        ctx.stroke();
    }
}

class Bullet {
    constructor(size, speed) {
        this.x = player.x + 50;
        this.y = player.y + 50;
        this.size = size;
        this.Sp = speed;
    }
    draw() {
        ctx.fillRect(this.x, this.y, this.size, this.size);
    }

    slide() {
        this.draw();
        this.x += this.Sp;
        ctx.rect(this.x, this.y, this.size, this.size);
        ctx.stroke();
    }
}

let randomgen = Math.floor(Math.random() * (0 - 500)) + 500;
function general(){
if(randomgen%30<0){
    randomgen = Math.floor(Math.random() * (0 - 500)) + 500;
}
}
general()

class Oils {
    constructor(width , height) {
        this.height = height;
        this.width = width;
        this.x = randomgen;
        this.y = randomgen;
    }
    draw() {
        oil.src = "./src/oil.png";
        Oilcol(this.x,this.width,this.y,this.height);
        ctx.drawImage(oil, this.x, this.y, this.width, this.height);
        ctx.rect(this.x, this.y, this.width, this.height);
        ctx.stroke();
    }
}


class BossOne {
    constructor(size){
        this.size = size;
        this.x = 100;
        this.y = 100;
    }
    draw(){
        ctx.rect(this.x, this.y, this.size, this.size);
        ctx.stroke();
    }
    randmove(){
        this.x = randomgen;
        this.y  = randomgen;
    }
}

function hitbox(){
    ctx.beginPath();
    ctx.rect(player.x, player.y, player.width, player.height);
    ctx.stroke();
}

/*Generálások*/

let birdrandom = Math.floor(Math.random() * (2000 - 2500)) + 2000;
let cloudrandom =  Math.floor(Math.random() * (4000 - 5000)) + 4000;
let baloonrandom = Math.floor(Math.random() * (8000 - 10000)) + 8000;
let oilrandom =  Math.floor(Math.random() * (10000 - 13000)) + 10000;



function generate() {
    enemys.push(new Birds(35,30, 0.5))
    setTimeout(generate, birdrandom)
}

function cloudg() {
    clouds.push(new Clouds(85,50, 0.5))
    setTimeout(cloudg,cloudrandom);
}

function balong() {
    ballons.push(new Baloons(70,85, 0.5))
    setTimeout(balong, baloonrandom);
}

function oilg() {
    oils.push(new Oils(15,15))
    if(oilg.length==3){
        console.log(oilg.length);
    }
    else{
        setTimeout(oilg,oilrandom);
    }
}

function bossg() {
    boss.push(new BossOne(250))
}

/*Eredmény szöveg*/
let score = 0; 
let bullet = 3;
let oilnu = 50;

function text() {
    ctx.font = "15px serif";
    ctx.fillText("Pontszám :" + score / 10000 + " km", 10, 30);
    ctx.fillText("Lőszer :" + bullet + " lőszer", 480, 30);
    ctx.fillText("Benzin :" + oilnu + " liter", 150, 30);
    score += 1;
    oilnu -= 0.05;
    Math.floor(score);
}

/*Alaprajzolás , Birdsok rajzolása*/
let req = null;
function start() {
    req = requestAnimationFrame(start);
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    player.draw();
    hitbox();
    text()
    enemys.forEach(Birds => {
        Birds.slide();
    })
    clouds.forEach(Clouds => {
        Clouds.slide();
    })
    ballons.forEach(Baloons => {
        Baloons.slide();
    })
    bullets.forEach(Bullets => {
        Bullets.slide();
    })
    oils.forEach(Oils => {
        Oils.draw();
        oils.splice(3);
    })
    
    /*boss.forEach(BossOne => {
        BossOne.draw();
    })
    if(score / 1000 == 3 ){
        bossg();
    }*/

    /*map érintés*/
    if (player.x == 570 || player.x == 550 || player.x < 0) {
        player.x = (-20);
    }
    if (player.y == (-60) || player.y == 570) {
        player.y = (-30);
    }

    /*Benzin*/
    if(oilnu<0){
        cancelAnimationFrame(req);
        end();
    }
    /*fffff*/

}


/*Ugrás*/

addEventListener("keydown", e => {
    switch (e.code) {
        case ('ArrowDown'):
            player.y += 30;
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            player.draw();
            setTimeout(() => {
                ctx.clearRect(0, 0, canvas.width, canvas.height);
                player.draw();
            }, 250)
            break;
        /**/
        case ('ArrowUp'):
            player.y -= 30;
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            player.draw();
            setTimeout(() => {
                ctx.clearRect(0, 0, canvas.width, canvas.height);
                player.draw();
            }, 250)
            break;
        /**/
        case ('ArrowRight'):
            player.x += 30;
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            player.draw();
            setTimeout(() => {
                ctx.clearRect(0, 0, canvas.width, canvas.height);
                player.draw();
            }, 250)
            break;
        /**/
        case ('ArrowLeft'):
            player.x -= 30;
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            player.draw();
            setTimeout(() => {
                ctx.clearRect(0, 0, canvas.width, canvas.height);
                player.draw();
            }, 250)
            break;
        /**/
        case ('Space'):
            if (bullet > 0) {
                function bulletg() {
                    bullets.push(new Bullet(4, 1))
                }
                bulletg();
                bullet--;
            }
            break;
    }
});

/*Lőszer gen*/
function shoot() {
    if (bullets.x == balon.x) {
        balon.x = 0;
    }

}

shoot();

/*Érintkezés*/


/*COOKIES*/
function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires="+d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
  }
  
  function getCookie(cname) {
    let name = cname + "=";
    let ca = document.cookie.split(';');
    for(let i = 0; i < ca.length; i++) {
      let c = ca[i];
      while (c.charAt(0) == ' ') {
        c = c.substring(1);
      }
      if (c.indexOf(name) == 0) {
        return c.substring(name.length, c.length);
      }
    }
    return "";
  }
  
  function checkCookie() {
    let user = getCookie("username");
    if (user != "") {
      console.log(user);
    } else {
      user = prompt("Add meg a neved kérlek:", "");
      if (user != "" && user != null) {
        setCookie("username", user , 365);
        setCookie("score", score , 365);
      }
    }
  }

  function playmenu(){
    checkCookie();
    const path = new Path2D()
    ctx.fillStyle = "darkblue";
    path.rect(150, 300, 250, 100)
    path.closePath()
    ctx.fill(path)
    ctx.lineWidth = 1
    ctx.stroke(path)


    function startbtn(){
        ctx.fillStyle = "white";
        ctx.font = "50px serif";
        ctx.fillText("START", 195, 365);
        ctx.fillStyle = "black";
    }
    startbtn();
    function coord(canvas, event){
      const rect = canvas.getBoundingClientRect()
      const y = event.clientY - rect.top
      const x = event.clientX - rect.left
      return {x:x, y:y}
    }

    document.addEventListener("click",  function (e) {
      const XY = coord(canvas, e)
      if(ctx.isPointInPath(path, XY.x, XY.y)) {
        start()
        generate();
        cloudg();
        balong();
        oilg();
      }
    }, false)
  }
  
  playmenu();

function end(){
    setCookie("score", score/ 10000 , 365);
    document.getElementById('scorewrite').innerText = score/10000;
}