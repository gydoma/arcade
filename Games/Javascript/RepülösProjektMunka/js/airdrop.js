import {ctx,airdrops,player} from './main.js';
import { supplybullet } from './bullet.js';
const airdrop = new Image();

var coll = false;

export class Airdrop {
    constructor(width, height, speed) {
        this.height = height;
        this.width = width;
        this.x = Math.floor(Math.random() * (200 - 400)) + 400;
        this.y = 0;
        this.Sp = speed;
    }
    draw() {
        airdrop.src = "./src/ammobox.png";
        ctx.drawImage(airdrop, this.x, this.y, this.width, this.height);
    }
    collison(){
        if (player.x > this.x + this.width ||
            player.x + player.width < this.x ||
            player.y > this.y + this.height ||
            player.y + player.height < this.y
        ) {} else {
            supplybullet();
            airdrops.splice(0);
        }
    }
    slide() {
        this.draw();
        this.y += this.Sp;
        this.collison();
        ctx.rect(this.x, this.y, this.width, this.height);
        ctx.stroke();
    }
}

export function airdropg() {
    airdrops.push(new Airdrop(70, 85, 0.5))
}

export{coll};