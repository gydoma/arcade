import {player} from "./player.js";
import {req,end} from "./main.js";


export function Collison(enx, enw, eny, enh) {
    if (player.x > enx + enw ||
        player.x + player.width < enx ||
        player.y > eny + enh ||
        player.y + player.height < eny
    ) {} else {
        console.log("dadada");
        cancelAnimationFrame(req);
        end();
    }
}

