import {ctx,cloudrandom,clouds} from './main.js'
const cloud = new Image();

export class Clouds {
    constructor(width, height, speed) {
        this.width = width;
        this.height = height;
        this.x = canvas.width + this.width;
        this.y = Math.floor(Math.random() * (50 - 580)) + 580;
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

export function cloudg() {
    clouds.push(new Clouds(100, 50, 0.5))
    setTimeout(cloudg, cloudrandom);
}
