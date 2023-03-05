# Chromium Arcade

<div align="center">

![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![Sketch](https://img.shields.io/badge/Sketch-FFB387?style=for-the-badge&logo=sketch&logoColor=black)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)
![PHP](https://img.shields.io/badge/php-%23777BB4.svg?style=for-the-badge&logo=php&logoColor=white)
![Python](https://img.shields.io/badge/python-3670A0?style=for-the-badge&logo=python&logoColor=ffdd54)

[![forthebadge](https://forthebadge.com/images/badges/gluten-free.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/built-with-grammas-recipe.svg)](https://forthebadge.com)

![progress](https://progress-bar.dev/15/?scale=100&title=progress&width=220&color=333&suffix=/100)
![codeql workflow](https://github.com/gydoma/arcade/actions/workflows/codeql.yml/badge.svg)
![last commit](https://img.shields.io/github/last-commit/gydoma/arcade)
![Contributors](https://img.shields.io/github/contributors-anon/gydoma/arcade)
![commit activity](https://img.shields.io/github/commit-activity/m/gydoma/arcade)

</div>

____
Ki ne szeretne játszani? Ez az oldal a Verebély László Technikumának a 2022/23. évi 11. szoftverfejlesztő és tesztelő évfolyamának I. sávú csoportjának a második projektmunkája. Mi úgy terveztük és készítettuk ezt a projektmunkát, hogy az unalmas óráidban csak böngéssz a játékok közül és nyugalmasan játszhass velük, esetleg tudj tanulni is a nyílt kódforrásunknak köszönhetően.

3 egyszerű lépésből már játszani is tudsz a játékainkkal!
1. Regisztrálj/Jelentkezz be!
2. Válassz ki egy játékot
3. Játssz!


## Q&A
[Q] **Miért kell regisztrálnom?**

[A] *Egyszerű, ne terhelje le a szervert a sok bot és adatbázis-kezelést is bele kellett vinni a projektünkbe.*

[Q] **Biztonságos ha megadom a saját jelszavam?**

[A] *Igen és Nem, A jelszavakat a szerver titkosítja, tehát mi nem tudjuk látni senkinek se a jelszavát. Viszont, nem ajánlott ugyanazt a jelszavat használni minden oldalon, mert a hekkerek előszeretettel fogják feltörni a fiókjaidat különböző platformokon is.*

[Q] **Telefonról vagyok, tudok futtatni .exe vagy .py játékokat?**

[A] *Mint egy egyszerű felhasználó, nem feltétlen. Ha értesz hozzá meglehet csinálni ezt is.*

[Q] **Vírusok vannak a játékaitokban?**

[A] *Nincsenek, gondosan átnéztük az összes fájt kézileg, le is teszteltük, és nem terveztünk kémprogramokat esetleg trójai falókat telepíteni a gépedre.* 

____

<p float="left">
  <img width="49%" alt="Deisgn of light mode" src="https://user-images.githubusercontent.com/65687471/212193250-f856dca0-9d3a-4905-8eb4-8353e412f619.png">
  <img width="49%" alt="Deisgn of dark mode" src="https://user-images.githubusercontent.com/65687471/213806773-14e58e2d-a402-43c2-a5e3-9a9c68bb7de6.png">
</p>

## SASS Compiler
A stílusa a weboldalnak SASS-ban íródott, semmilyen könyvtárat nem használtunk a sajátos dizájn miatt.
### SASS CLI Compiler letöltése
```sh
npm install -g sass
```
### Compiler futtatása:
```sh
sass --watch --verbose scss/config.scss style.css
```

## How it works

<img width="2368" alt="arcademap" src="https://user-images.githubusercontent.com/65687471/221352315-8cad08f2-4e74-422d-a2ac-a1c28dec9208.png">


## DEV NOTES

**Drótvázat - dizájntervet [ITT](https://www.sketch.com/s/be49d22c-e4f3-4380-bbfe-fca234c20055) tudod megnézni**

Elakadtál? Nincs Ötleted? Itt egy pár játékötlet chatgpt-vel generálva: https://github.com/gydoma/arcade/issues/5


Ha valami más programozási nyelvben szeretnéd megcsinálni a játékodat mint a kitűzött (nem konzolos JavaScript, Python, C#) akkor ügyelj arra, hogy lehessen futtatni a weben vagy könnyen letölthető egy fájlos (pl.: .exe) a programod/játékod.

### Weboldalra használt színpaletta


<img width="1596" alt="Screenshot 2023-03-05 at 13 43 38" src="https://user-images.githubusercontent.com/65687471/222961189-6031020c-136b-4c0f-820d-4ecfe436d90a.png">

A weboldal háttere svg-ben készült, 2 monokróm 	`#FFF4CC`,	`#F9E9BF` színnel. A kártyák háttere `#FFFFFF`, körvonaluk `#474A57` (sötét módban: `#b8b5a8`) és `#000000`. A nagyobb kontrasztot adó fő hangsúlyú a `#FFBD12`, sötét módban ez a `#F95A2C`. Világos módban a szövegek: 1. rangú (primary) -  `#000000`; 2. rangú (secondary) - `#18191F`; 3. rangú (tertiary) - `#474A57`. Sötét hátteren ebben a sorrendben: `#FFFFFF`; `#D1D1D1`; `#cccccc`.

## Készítették:

| Név | 3 JS - 2 PY - 6 CS - 1 C++|
| ------ | ------ |
| Gyurkovics Dominik | [Projektvezető] py (1) |
| Katona Roland | [Pv.-helyettes] js (1) |
| Andrási Szilvia | [Segítő - Tanár] |
| Bábolnai Bence | js (1) |
| Orosz Eszter | cs (1) |
| Dávid Benedek | py (1) |
| Vajda Dániel | cs (1)|
| Bán Gergő | cs (1) |
| Suhajda Zsolt Péter | cs (1) |
| Rostás András Péter | |
| Bárczi Bence | cs (2) |
| Kósa Márk | c++ (1) |
| Molnár-Horgos Kristóf | [TankTrouble](https://github.com/Trixep/TankTrouble-Multiplayer) |
| Vígh Noel | [TankTrouble](https://github.com/Trixep/TankTrouble-Multiplayer) |
| Horváth Péter Ákos | [TankTrouble](https://github.com/Trixep/TankTrouble-Multiplayer) |

A projekt weboldalának a kinézeti tervét, PHP és SCSS részét készítette és fenntartja: gydoma


## Játékok Listája

| Játék Neve | Programozási nyelv | Engine | Frissítve | Készítette |
| ------ | ------ | ------ | ------ | ------ |
| snakegame1.0 | C# | - | 2023/01/27 | Esztii |
| Blackjack | JavaScript | - | 2023/01/27 | Roland |
| quiz | Python | - | 2023/01/30 | gydoma |
| [TankTrouble](https://github.com/Trixep/TankTrouble-Multiplayer)| C# | Unity | 2023/01/27 | [készítette](https://github.com/Trixep/TankTrouble-Multiplayer#a-projekt-tagjai) |
| Catan | Python | PyGame | 2023/02/01 | Benedek |
| Keeper Of The Hates 1.6 | C# | Unity | 2023/02/01 | Vajda |
| RepülösProjektMunka | Javascript | - | 2023/02/07 | Bencso |
| [Pong](https://github.com/rewerze/Pong) | C# | Unity | 2023/02/07 | [rewerze](https://github.com/rewerze/) |
| FlappyBird | C# | MonoGame | 2023/02/14 | Bárczi Bence |
| Quoridor | C# | MonoGame | 2023/02/14 | Bárczi Bence |
| TextRPG | C# | - | 2023/02/28 | Bán Gergő |
| Space Mem | C++ | - | 2023/03/01 | Kósa Márk |


> __Note__ **Projekt várható befejezésének időpontja: 2023 Közepe**
