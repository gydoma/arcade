let canvas = document.getElementById('canvas');
let ctx = canvas.getContext('2d');

/*Háttér rajz*/
function drawBg(){
    ctx.lineWidth=2;
    ctx.moveTo(000,300);
    ctx.lineTo(600,300);
    ctx.stroke();
}

/*Játékos rajzolása*/
class Plr{
    constructor(x,y){
        this.x=x;
        this.y=y;
        this.ready = false;
    }
    draw(){
    drawBg();
    ctx.fillRect(this.x,this.y,30,50);
    }
}

let player = new Plr(30,250);

/*Alaprajzolás*/
function start(){
    ctx.clearRect(0,0,canvas.width,canvas.height);
    drawBg();
    player.draw();
}

start();


/*Ugrás*/
addEventListener("keydown", e => {
    if(e.key == " "|| e.code =="Space"){
        player.y -=50;
        ctx.clearRect(0,0,canvas.width,canvas.height);
        console.log(player.x);
        player.draw();
        setTimeout(()=> {
            ctx.clearRect(0,0,canvas.width,canvas.height);
            player.y+=50;
            player.draw();
        } , 90)
    }
});
