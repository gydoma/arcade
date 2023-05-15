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