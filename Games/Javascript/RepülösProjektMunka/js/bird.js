import {ctx,enemys,birdrandom} from './main.js';
import {Collison} from "./collisions.js";
const bird = new Image();

export class Birds {
    constructor(width, height, speed) {
        this.height = height;
        this.width = width;
        this.x = canvas.width + this.width;
        this.y = Math.floor(Math.random() * (50 - 580)) + 580;
        this.Sp = speed;
    }
    draw() {
        bird.src = "./src/bird.gif";
        ctx.drawImage(bird, this.x, this.y, this.width, this.height);

    }
    slide() {
        this.draw();
        this.x -= this.Sp;
        Collison(this.x, this.width, this.y, this.height);
        ctx.rect(this.x, this.y, this.width, this.height);
        ctx.stroke();
    }
}

export function generate() {
    enemys.push(new Birds(65, 50, 0.5))
    setTimeout(generate, birdrandom)
}

