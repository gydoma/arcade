import { checkCookie } from "./cookies.js";
import { ctx, start, generate, cloudg, balong, oilg, started } from "./main.js";

export function playmenu() {
    document.removeEventListener("keydown", e => {
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
        }})
    checkCookie();
    var path = new Path2D()
    ctx.fillStyle = "darkblue";
    path.rect(150, 300, 250, 100)
    path.closePath();
    ctx.fill(path);
    ctx.lineWidth = 1;
    ctx.stroke(path);


    function startbtn() {
        ctx.fillStyle = "white";
        ctx.font = "50px serif";
        ctx.fillText("START", 195, 365);
        ctx.fillStyle = "black";
    }
    startbtn();

    function coord(canvas, event) {
        var rect = canvas.getBoundingClientRect()
        var y = event.clientY - rect.top
        var x = event.clientX - rect.left
        return { x: x, y: y }
    }

document.addEventListener("click", function(e) {
    var XY = coord(canvas, e)
    if (ctx.isPointInPath(path, XY.x, XY.y)&& started == false) {
        start()
        generate();
        cloudg();
        balong();
        oilg();
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
            }})
}})}
