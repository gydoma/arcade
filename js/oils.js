import {ctx,player,oils} from './main.js';

let randomgen = Math.floor(Math.random() * (100 - 400)) + 400;
const oil = new Image();

export function oilg() { 
    if(oils){
        if(oils.length==1){}
        else{
        setTimeout(oils.push(new Oils(20, 20)),600);
        randomgen = Math.floor(Math.random() * (100 - 500)) + 500;
    }
    }

}
oilg()

export var oilnumber = Infinity;

export function Oilcol(enx, enw, eny, enh) {
    if (player.x > enx + enw ||
        player.x + player.width < enx ||
        player.y > eny + enh ||
        player.y + player.height < eny
    ) { } else {
        oilnumber = 100;
        var found = (element) => element.x = enx;
        var index = oils.findIndex(found);
        oils.splice(index,1);
        oilg()
    }
}

export class Oils {
    constructor(width, height) {
        this.height = height;
        this.width = width;
        this.x = randomgen;
        this.y = randomgen;
    }
    draw() {
        oil.src = "./src/oil.png";
        oilnumber -= 0.04;
        ctx.drawImage(oil, this.x, this.y, this.width, this.height);
        ctx.rect(this.x, this.y, this.width, this.height);
        ctx.stroke();
        Oilcol(this.x, this.width, this.y, this.height ,oilnumber);
    }
}

