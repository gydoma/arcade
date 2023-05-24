import {ctx,clear} from './main.js'
const img = new Image();


export class Plr {
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
        if (this.x > 570 || this.x<0) {
            this.x = (-20);
        }
        if (this.y > 570) {
            this.y = 40;
        }
        else if(this.y < 30){
            this.y = 560;
        }
    }
}

function skinchange() {
    let ran = Math.round(Math.random());
    if (ran == 1) {
        img.src = "./src/player.png";
    } else {
        img.src = "./src/player1.png";
    }
}

export var player = new Plr(0, 300);

export function movement(){
    document.addEventListener("keydown", e => {
    switch (e.code) {
        case ('ArrowDown'):
            player.y += 30;
            clear();
            player.draw();
            setTimeout(() => {
                clear();
                player.draw();
            }, 250)
            break;
            /**/
        case ('ArrowUp'):
            player.y -= 30;
            clear();
            player.draw();
            setTimeout(() => {
                clear();
                player.draw();
            }, 250)
            break;
            /**/
        case ('ArrowRight'):
            player.x += 30;
            clear();
            player.draw();
            setTimeout(() => {
                clear();
                player.draw();
            }, 250)
            break;
            /**/
        case ('ArrowLeft'):
            player.x -= 30;
            clear();
            player.draw();
            setTimeout(() => {
                clear();
                player.draw();
            }, 250)
            break;
    }})};

    movement();