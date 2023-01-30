import time

#üdvözlő
print("üdvözöllek a Quizünkben")
time.sleep(1)

chances = 1
print("Választ ki a helyes választ. \nKérlek válasz az ábécé Válaszokat\n")
time.sleep(2)

#Eredmény
score = 0

#kérdés 1
kerdes_1 = print("1) Melyik vár kapitánya volt Zrínyi Miklós?\n(A) Szigetvár\n(B)Drégely \n(C)Egri vár\n\n ")
valasz_1 = "A"

for i in range(chances):
    valasz=input("valasz: ")
    if(valasz.upper()==valasz_1):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_1, "\n\n ")


time.sleep(2)

kerdes_2 = print("2) Melyik volt Magyarországon a legnagyobb parasztháború?\n(A) 1989\n(B) 1514\n(C)1848\n\n ")
valasz_2 = "B"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_2):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_2, "\n\n ")

time.sleep(2)

kerdes_3 = print("3) Melyik USA támaszpontot támadta meg Japán 1941.12.07-én?\n (A) Nevada\n(B) Maldív-szigetek\n(C) Pearl Harbor\n\n ")
valasz_3 = "C"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_3):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_3, "\n\n ")


time.sleep(2)

kerdes_4 = print("4) Melyik birodalom tartománya volt Poroszország?\n (A) Római\n(B) Német\n(C) Bizánci\n\n ")
valasz_4 = "B"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_4):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_4, "\n\n ")


time.sleep(2)

kerdes_5 = print("5) Melyik kor következett az újkőkor után?\n (A) Bronzkor\n(B) Vaskor\n(C) Rézkor\n\n ")
valasz_5 = "C"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_5):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_5, "\n\n ")


time.sleep(2)

kerdes_6 = print("6) Melyik állat terjesztette el a pestist?\n (A) Bolha\n(B) Ló\n(C) Sertés\n\n ")
valasz_6 = "A"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_6):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_6, "\n\n ")


time.sleep(2)

kerdes_7 = print("7) Melyik városban halt meg „Mohamed”?\n (A) Medina\n(B) Jeruzsálem\n(C) Mekka\n\n ")
valasz_7 = "A"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_7):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_7, "\n\n ")


time.sleep(2)

kerdes_8 = print("8) Mikor kezdődött az „iszlám” időszámítás?\n (A) Kr.e. 400\n(B) 622\n(C) 400\n\n ")
valasz_8 = "B"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_8):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_8, "\n\n ")


time.sleep(2)

kerdes_9 = print("9) Melyik magyar király négyelte fel a testvérét?\n (A) Szent István\n(B) VI. Béla\n(C) I. András\n\n ")
valasz_9 = "A"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_9):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_9, "\n\n ")


time.sleep(2)

kerdes_10 = print("10) Melyik magyar király négyelte fel a testvérét?\n (A) István\n(B) Árpád\n(C) Géza\n\n ")
valasz_10 = "C"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_10):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_10, "\n\n ")


time.sleep(2)

kerdes_11 = print("11) Ki volt az utolsó kínai császár?\n (A) BU LI\n(B) PU BI\n(C) PU JI\n\n ")
valasz_11 = "C"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_11):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_11, "\n\n ")


time.sleep(2)

kerdes_12 = print("12) Melyik német királyt nevezték „rőtszakállúnak”?\n (A) I. Frigyes\n(B) III. Henrik\n(C) I. Richárd\n\n ")
valasz_12 = "A"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_12):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_12, "\n\n ")


time.sleep(2)

kerdes_13 = print("13) Kit neveztek „sivatagi rókának”?\n (A) Göring-et\n(B) Rommel-t\n(C) Montgomery-t\n\n ")
valasz_13 = "B"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_13):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_13, "\n\n ")


time.sleep(2)

kerdes_14 = print("14) Melyik országnak van a legnagyobb kereskedelmi flottája?\n (A) USA\n(B) Japán\n(C) Kína\n\n ")
valasz_14 = "B"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_14):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_14, "\n\n ")


time.sleep(2)

kerdes_15 = print("15) Hogy hívták Augustus császár fogadott fiát?\n (A) Caesario\n(B) Octavianus\n(C) Nero\n\n ")
valasz_15 = "C"

for i in range(chances):
    answer=input("Answer: ")
    if(answer.upper()==valasz_15):
        print("Helyes a válasz!\n")
        score=score+1
        break
    else:
        print("A válasz helytelen")
        time.sleep(0.5)
        print("a helyes válasz", valasz_15, "\n\n ")

#pontok 
while score>=6:
    print("Szép volt! A pontjaid",score)
    break

while score < 5:
    print("Ez most nem sikerült oly jól sajnos... ): Reméljük legközelebb szerencséd lesz! Elért pontszám: 10/", score)
    break


#elköszönés
print("Köszönjük hogy játszottál!")