import {ctx,bullets,enemys} from './main.js';
import { player } from './player.js';
import { coll } from './airdrop.js';

export var bullet = 3;

export class Bullet {
    constructor(size, speed) {
        this.x = player.x + 30;
        this.y = player.y + 30;
        this.size = size;
        this.Sp = speed;
    }
    draw() {
        ctx.fillStyle = "#00000";
        ctx.fillRect(this.x,this.y,this.size,this.size);
    }
    collison(){
        enemys.forEach((element,i) => {
        if (
        (Math.round(Math.hypot(element.x - this.x, element.y - this.y))) < this.size + element.height){
            console.log(Math.hypot(element.x - this.x, element.y - this.y).toFixed(2));
            console.log(this.size + element.height);    
            enemys.splice(i,1);
            } 
         else {}})
    }
    slide() {
        this.draw();
        this.x += this.Sp; 
        this.collison();       
    }
}

function bulletg() {
    bullets.push(new Bullet(4, 1))
}

export function supplybullet(){
    bullet=3;
}

document.addEventListener("keydown", e => {
    switch (e.code) {
        case ('Space'):
            if (bullet > 0) {
                bulletg();
                bullet--;
            }
            break;
    }
})

