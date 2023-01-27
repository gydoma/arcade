
var dealerSum = 0;
var sajatsum = 0;

var dealerAceCount = 0;
var yourAceCount = 0; 

var rejtett;
var pakli;

var canHit = true;
window.onload = function() {
    pakli();
    keveres();
    startGame();
}

function pakli() {
    let values = ["A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"];
    let types = ["C", "D", "H", "S"];
    pakli = [];

    for (let i = 0; i < types.length; i++) {
        for (let j = 0; j < values.length; j++) {
            pakli.push(values[j] + "-" + types[i]);
        }
    }
}

function keveres() {
    for (let i = 0; i < pakli.length; i++) {
        let j = Math.floor(Math.random() * pakli.length);
        let temp = pakli[i];
        pakli[i] = pakli[j];
        pakli[j] = temp;
    }
    console.log(pakli);
}

function startGame() {
    rejtett = pakli.pop();
    dealerSum += getValue(rejtett);
    dealerAceCount += checkAce(rejtett);
    while (dealerSum < 17) {
        let cardImg = document.createElement("img");
        let card = pakli.pop();
        cardImg.src = "./cards/" + card + ".png";
        dealerSum += getValue(card);
        dealerAceCount += checkAce(card);
        document.getElementById("dealer-kartyak").append(cardImg);
    }
 
    for (let i = 0; i < 2; i++) {
        let cardImg = document.createElement("img");
        let card = pakli.pop();
        cardImg.src = "./cards/" + card + ".png";
        sajatsum += getValue(card);
        yourAceCount += checkAce(card);
        document.getElementById("sajat-kartyak").append(cardImg);
    }

    console.log(sajatsum);
    document.getElementById("hit").addEventListener("click", hit);
    document.getElementById("stay").addEventListener("click", stay);

    document.getElementById("your-sum").innerText = sajatsum;
}

function hit() {
    if (!canHit) {
        return;
    }

    let cardImg = document.createElement("img");
    let card = pakli.pop();
    cardImg.src = "./cards/" + card + ".png";
    sajatsum += getValue(card);
    yourAceCount += checkAce(card);
    document.getElementById("sajat-kartyak").append(cardImg);
    document.getElementById("your-sum").innerText = sajatsum;
    if (reduceAce(sajatsum, yourAceCount) > 21) {
        canHit = false;
    }

}

function stay() {
    dealerSum = reduceAce(dealerSum, dealerAceCount);
    sajatsum = reduceAce(sajatsum, yourAceCount);

    canHit = false;
    document.getElementById("hidden").src = "./cards/" + rejtett + ".png";

    let message = "";
    if (sajatsum > 21) {
        message = "Vesztettél!";
    }
    else if (dealerSum > 21) {
        message = "Nyertél!";
    }
    else if (sajatsum == dealerSum) {
        message = "Döntetlen!";
    }
    else if (sajatsum > dealerSum) {
        message = "Nyertél!";
    }
    else if (sajatsum < dealerSum) {
        message = "Vesztettél";
    }

    document.getElementById("dealer-sum").innerText = dealerSum;
    document.getElementById("your-sum").innerText = sajatsum;
    document.getElementById("results").innerText = message;
}

function getValue(card) {
    let data = card.split("-"); // "4-C" -> ["4", "C"]
    let value = data[0];

    if (isNaN(value)) { //A J Q K
        if (value == "A") {
            return 11;
        }
        return 10;
    }
    return parseInt(value);
}

function checkAce(card) {
    if (card[0] == "A") {
        return 1;
    }
    return 0;
}

function reduceAce(playerSum, playerAceCount) {
    while (playerSum > 21 && playerAceCount > 0) {
        playerSum -= 10;
        playerAceCount -= 1;
    }
    return playerSum;
}