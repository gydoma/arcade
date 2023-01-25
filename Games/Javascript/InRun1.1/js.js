let canvas = document.getElementById('canvas');
let ctx = canvas.getContext('2d');
let random = Math.floor(Math.random()*(100-40)) + 40;

console.log(random)
/*Háttér rajz*/

function drawBg(){
    ctx.lineWidth=2;
    ctx.moveTo(000,300);
    ctx.lineTo(600,300);
    ctx.stroke();
}

/*Játékos rajzolása, ugrás*/
class Plr{
    constructor(x,y){
        this.x=x;
        this.y=y;
        this.ugrasMag = 60;
        this.ugrasSum = 0;
        this.ready = false;
    }
    draw(){
    drawBg();
    ctx.fillRect(this.x,this.y,30,50);
    }
}

let player = new Plr(150,250);

/*A random blokkok*/
class RndBlokk{
    constructor(size,speed){
        this.x = canvas.width-size;
        this.y = 270 ;
        this.size = size;
        this.Sp = speed;
    }
    draw() {
        ctx.fillRect(this.x,this.y,this.size,this.size);
    }

    slide() {
        this.draw();
        this.x -= this.Sp;
    }
}

let enemys = [];

function generate(){
    enemys.push(new RndBlokk(30,1))
    setTimeout(generate,1000)
}
generate();


function text() {
    ctx.font = "30px serif";
    ctx.fillText("Pontszám:", 10, 50);
}

/*Alaprajzolás , rndblokkok rajzolása*/
let aid = null;
function start(){
    aid = requestAnimationFrame(start);
    ctx.clearRect(0,0,canvas.width,canvas.height);
    drawBg();
    player.draw();
    text()
    enemys.forEach(RndBlokk  => {
        RndBlokk.slide();

        let p1 = Object.assign(Object.create(Object.getPrototypeOf(player)),player);
        let e1 = Object.assign(Object.create(Object.getPrototypeOf(enemys)),enemys);
        if(p1.x>e1.x+e1.size || e1.x>p1.x+p1.size || p1.x>e1.y+e1.size || e1.y>p1.y+p1.size){
            cancelAnimationFrame(aid);
        }
    })
}

start();


/*Ugrás*/

addEventListener("keydown", e => {
    if(e.key == " "|| e.code =="Space"){
        player.y -=100;
        player.x+=15;
        ctx.clearRect(0,0,canvas.width,canvas.height);
        console.log(player.x);
        player.draw();
        setTimeout(()=> {
            ctx.clearRect(0,0,canvas.width,canvas.height);
            player.y+=100;
            player.x-=15;
            player.draw();
        } , 250)
    }
});


