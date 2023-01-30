from time import sleep
from os import system, name
# from plinko import *
uclr = 'cls' if name == 'nt' else 'clear'

class Quiz:
    def __init__(self, sor:str):
        darabok:list = sor.strip().split('/')
        self.kerdessorszam = int(darabok[0])
        self.kerdes = darabok[1]
        self.avalasz = darabok[2]
        self.bvalasz = darabok[3]
        self.cvalasz = darabok[4]
        self.helyesvalasz = str(darabok[5])


def console_clear():
    system(uclr)
    
def ask_theme(file):
    while file is None:
        console_clear()
        print('             ██████╗ ██╗   ██╗██╗███████╗')
        print('            ██╔═══██╗██║   ██║██║╚══███╔╝')
        print('            ██║   ██║██║   ██║██║  ███╔╝ ')
        print('            ██║▄▄ ██║██║   ██║██║ ███╔╝  ')
        print('            ╚██████╔╝╚██████╔╝██║███████╗')
        print('             ╚══▀▀═╝  ╚═════╝ ╚═╝╚══════╝')
        print('')
        print('')
        print('                  Válassz egy témát!')
        print('')
        print('           [1] Történelem   [2] Matematika')
        print('')
        print('               [3] Forma1   [4] Python')
        print('')
        ask = int(input(''))
        if ask == 1:
            file = 'tori.txt'
        elif ask == 2: file = 'matek.txt'
        elif ask == 3: file = 'f1.txt'
        elif ask == 4:
            print('')
            print('Amatőr... Azt gondolod meg is fogjuk csinálni ezt?')
            sleep(3)
            console_clear()
            print('')
            print('Válassz egy másik témát!')
            print('     [1] Történelem')
            print('     [2] Matematika')
            print('     [3] Forma1')
            print('     uoɥʇʎd [ㄣ]')
            print('')
            ask = int(input(''))
            if ask == 1:
                file = 'tori.txt'
            elif ask == 2: file = 'matek.txt'
            elif ask == 3: file = 'f1.txt'
    console_clear()
    return file


def get_quizsheet(file) -> list[Quiz]:
    quiz:list[Quiz] = []
    for s in open(file):
        quiz.append(Quiz(s))
    return quiz


def print_quiz(quiz:list[Quiz], kerdesszam, pont):
    uservalasz = ''
    while kerdesszam != 15:
        print('')
        print(f'                    {quiz[kerdesszam].kerdessorszam}. kérdés')
        print('')
        print(quiz[kerdesszam].kerdes)
        print('')
        print(f'    {quiz[kerdesszam].avalasz}')
        print(f'    {quiz[kerdesszam].bvalasz}')
        print(f'    {quiz[kerdesszam].cvalasz}')
        print('')
        uservalasz = str(input('                 Írd ide a betűt: ').upper())
        print('')

        #átrakni ezt a szakaszt main.py-be és úgy letárolni az adatokat, mert így nem működik a buzi global var-ok miatt
        if uservalasz == quiz[kerdesszam].helyesvalasz:
            print('                 A válaszod helyes!')
            pont += 1
            sleep(1.5)
        else: 
            print(f'               Helytelen! A helyes: {quiz[kerdesszam].helyesvalasz}')
            sleep(2)
        kerdesszam += 1
        console_clear()

def show_rec(pont):
    print('')
    print('Gratulálok sikerült megoldanod a feladatokat! Nézzük mennyi pontot sikerült elérned!')
    sleep(3)
    if pont == 15: print(f'15/{pont}    Tökéletes! Gyönyörű szép munka!')
    elif pont == 14: print(f'15/{pont}    Majdnem hibátlan! csúcsszuper vagy!')
    elif pont >= 10: print(f'15/{pont}    Nagyon szép munka!')
    elif pont >= 7: print(f'15/{pont}    Egész jól dolgoztál!')
    elif pont >= 3: print(f'15/{pont}    ehh..')
    elif pont == 2: print(f'15/{pont}    Hát ez nagyon nem sikerült...')
    elif pont == 1: print(f'15/{pont}    Próbálkoztál egyáltalán?')
    elif pont == 0: print(f'15/{pont}    HOGY?!?')
    sleep(2)
    print('Köszönjük, hogy játszottál ezzel a játékkal')
    print('Viszlát!')
    sleep(5)

    
