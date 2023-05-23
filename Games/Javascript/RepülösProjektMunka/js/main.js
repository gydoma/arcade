import { player } from "./player.js";
import { oilg, oilnumber } from "./oils.js";
import { cloudg } from "./clouds.js";
import { balong } from "./baloons.js";
import { generate } from "./bird.js";
import { bullet, supplybullet } from "./bullet.js";
import { checkCookie, setCookie } from "./cookies.js";
import { playmenu } from './menu.js';
import { airdropg } from "./airdrop.js";

var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');
var started = false;
var enemys = [];
var clouds = [];
var ballons = [];
var bullets = [];
var oils = [];
var airdrops = [];
var score = 0;
var req = null;
ctx.strokeStyle = "transparent";
var birdrandom = Math.floor(Math.random() * (2000 - 2500)) + 2000;
var cloudrandom = Math.floor(Math.random() * (4000 - 5000)) + 4000;
var baloonrandom = Math.floor(Math.random() * (8000 - 10000)) + 8000;
var oilrandom = Math.floor(Math.random() * (1000 - 1300)) + 1000;

checkCookie();
playmenu();

function clear() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
}


function text() {
    ctx.font = "15px serif";
    ctx.fillText("Pontszám :" + Math.round(score) + " m", 10, 30);
    ctx.fillText("Lőszer :" + bullet + " db", 480, 30);
    ctx.fillText("Üzemanyag :" + Math.round(oilnumber) + " liter", 150, 30);
    score += 0.5;
    if (score % 3000 == 0) {
        airdropg();
    }
}

function hitbox() {
    ctx.beginPath();
    ctx.strokeStyle = "transparent";
    ctx.rect(player.x, player.y, player.width, player.height);
}

function start() {
    started = true;
    req = requestAnimationFrame(start);
    clear();
    player.draw();
    hitbox();
    text();
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
    })
    airdrops.forEach(Airdrop => {
            Airdrop.slide();
        })
        /*Benzin*/
    if (oilnumber < 0) {
        cancelAnimationFrame(req);
        end();
    }
    /*ffff*/
}


function end() {
    cancelAnimationFrame(req);
    removeEventListener("keydown");
    started=false;
    player.x = 0;
    player.y = 300;
    enemys.splice(0);
    clouds.splice(0);
    ballons.splice(0);
    bullets.splice(0);
    oils.splice(0);
    airdrops.splice(0);
    clear();
    if (score > document.cookie.split('; ').find((row) => row.startsWith('score=')).split('=')) {
        setCookie("score", score, 28);
    }
    checkCookie();
    var path = new Path2D()
    ctx.fillStyle = "darkblue";
    path.rect(150, 300, 250, 100)
    path.closePath()
    ctx.fill(path)
    ctx.lineWidth = 1
    ctx.stroke(path)


    function startbtn() {
        ctx.fillStyle = "white";
        ctx.font = "50px serif";
        ctx.fillText("Restart", 195, 365);
        ctx.fillStyle = "black";
    }

    function coord(canvas, event) {
        var rect = canvas.getBoundingClientRect()
        var y = event.clientY - rect.top
        var x = event.clientX - rect.left
        return { x: x, y: y }
    }

    document.addEventListener("click", function(e) {
        var XY = coord(canvas, e)
        if (ctx.isPointInPath(path, XY.x, XY.y) && started == false) {
            start()
            generate();
            cloudg();
            balong();
            oilg();
        }
    })
    startbtn();
}

/*export*/
export {
    canvas,
    ctx,
    req,
    end,
    clear,
    generate,
    start,
    oils,
    oilnumber,
    oilg,
    oilrandom,
    enemys,
    birdrandom,
    bullets,
    bullet,
    player,
    score,
    cloudg,
    clouds,
    cloudrandom,
    ballons,
    balong,
    baloonrandom,
    started,
    airdrops
};