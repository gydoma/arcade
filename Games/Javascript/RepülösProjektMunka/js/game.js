import {canvas,ctx,oilg,clear,player,hitbox,text} from './main.js';


var enemys = [];
var clouds = [];
var ballons = [];
var bullets = [];
var oils = [];
var boss = [];
var oilnu = 100;
var score = 0;
var bullet = 3;
var req = null;
oilnu = 100;

export function start() {
    bullet = 3;
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

    /*map érintés*/
    if (player.x == 570 || player.x == 550 || player.x < 0) {
        player.x = (-20);
    }
    if (player.y == (-60) || player.y == 570) {
        player.y = (-30);
    }

    /*Benzin*/
    if (oilnu < 0) {
        cancelAnimationFrame(req);
        end();
    }
    /*fffff*/
}


export function end() {
    cancelAnimationFrame(req);
    enemys.splice(0);
    clouds.splice(0);
    ballons.splice(0);
    bullets.splice(0);
    oils.splice(0);
    boss.splice(0);
    clear();
    if (score > document.cookie.split('; ').find((row) => row.startsWith('score=')).split('=')) {
        setCookie("score", score, 28);
    }
    checkCookie();

    var path = new Path2D()
    ctx.fillStyle = "darkblue";
    function startbtn() {
        ctx.fillStyle = "white";
        ctx.font = "60px serif";
        ctx.fillText("Restart", 195, 365);
        ctx.fillStyle = "black";
    }
    
    ctx.font = "30px serif";
    path.rect(150, 300, 250, 100)
    path.closePath()
    ctx.fill(path)
    ctx.lineWidth = 1
    ctx.stroke(path)
    ctx.fillText("Pontszám :" + score + " m", 150, 225);
    ctx.fillText("Lőszer :" + bullet + " db", 150, 255);
    ctx.fillText("Üzemanyag :" + Math.round(oilnu) + " liter", 150, 285);

    function coord(canvas, event) {
        var rect = canvas.getBoundingClientRect()
        var y = event.clientY - rect.top
        var x = event.clientX - rect.left
        return { x: x, y: y }
    }
    document.addEventListener("click", function(e) {
        var XY = coord(canvas, e)
        if (ctx.isPointInPath(path, XY.x, XY.y) && started == 0) {
            start()
            generate();
            cloudg();
            balong();
            oilg();
        }
    }, false)
    startbtn();
    oilnu = 100;
    score = 0;
    bullet = 3;
}