import {ctx,ballons,baloonrandom} from './main.js';
import {Collison} from "./collisions.js";
const balon = new Image();

export class Baloons {
    constructor(width, height, speed) {
        this.height = height;
        this.width = width;
        this.x = canvas.width + this.width;
        this.y = Math.floor(Math.random() * (0 - 250)) + 250;
        this.Sp = speed;
    }
    draw() {
        balon.src = "./src/balonred.png"
        ctx.drawImage(balon, this.x, this.y, this.width, this.height);
    }
    slide() {
        this.draw();
        this.x -= this.Sp;
        Collison(this.x, this.width, this.y, this.height);
        ctx.rect(this.x, this.y, this.width, this.height);
        ctx.stroke();
    }
}

export function balong() {
    ballons.push(new Baloons(70, 85, 0.5))
    setTimeout(balong, baloonrandom);
}
