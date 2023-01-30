#                                                           
#                                                           Elképzelés/drótváz
#
#                                                      col:  1 2 3 4 5 6 7 8 9       
#                                                  row:
#                                                   1       |x* * * * * * * * |
#                                                   2       |*\* * * * * * * *|
#                                                   3       |/* * * * * * * * |
#                                                   4       |*\* * * * * * * *|
#                                                   5       | *\* * * * * * * |
#                                                   6       |* *\* * * * * * *|
#                                                   7       | */* * * * * * * |
#                                                   8       |*/* * * * * * * *|
#                                                   9       |\* * * * * * * * |
#                                                   10      |*/* * * * * * * *|
#                                                   11      |x|_|_|_|_|_|_|_|_|
#                                                          100$  |10.000$| 100$
#                                                            500$| 0$ 0$ |500$
#                                                              1000$   1000$   
#                                                                           
#                                                          Lehetséges nyeremények
#
#                                               100$ 500$ 1000$ 0$ 10.000$ 0$ 1000$ 500$ 100$
#
#                                                1.   2.    3.  4.   5.    6.   7.   8.   9.

from random import randint
from time import sleep


money = 0


print('')
print(' ██▓███    ██▓     ██▓  ███▄    █   ██ ▄█▀ ▒█████  ')
print('▓██░  ██ ▒▓██▒    ▓██▒  ██ ▀█   █   ██▄█▒ ▒██▒  ██▒')
print('▓██░ ██▓ ▒▒██░    ▒██▒ ▓██  ▀█ ██▒ ▓███▄░ ▒██░  ██▒')
print('▒██▄█▓▒  ▒▒██░    ░██░ ▓██▒  ▐▌██▒ ▓██ █▄ ▒██   ██░')
print('▒██▒ ░   ░░██████▒░██░ ▒██░   ▓██░ ▒██▒ █▄░ ████▓▒░')
print('▒▓▒░ ░   ░░ ▒░▓  ░░▓   ░ ▒░   ▒ ▒  ▒ ▒▒ ▓▒░ ▒░▒░▒░ ')
print('░▒ ░      ░ ░ ▒  ░ ▒ ░ ░ ░░   ░ ▒░ ░ ░▒ ▒░  ░ ▒ ▒░ ')
print('░░          ░ ░    ▒ ░    ░   ░ ░  ░ ░░ ░ ░ ░ ░ ▒  ')
print('              ░  ░ ░            ░  ░  ░       ░ ░  ')

sleep(1.5)

print('')
print('                 | * * * * * * * * |')
print('                 |* * * * * * * * *|')
print('                 | * * * * * * * * |')
print('                 |* * * * * * * * *|')
print('                 | * * * * * * * * |')
print('                 |* * * * * * * * *|')
print('                 | * * * * * * * * |')
print('                 |* * * * * * * * *|')
print('                 | * * * * * * * * |')
print('                 |* * * * * * * * *|')
print('                 |_|_|_|_|_|_|_|_|_|')

col = 69

while not 1 <= col <= 9:
    print('')
    print('     Válassz melyik helyre dobod a labdád! [1-9]')
    col = int(input('                        '))

row = 0
turn = '-'

def where(row, col):
    if randint(1,2) == 1: # |> BALRA <|
        if (col == 1 and row) or (col == 2): 
            col += 1
            turn == '/'
        else:
            col -= 1
        row -= 1
    else:                 # |> JOBBRA <|
        col += 1
        row -= 1
        turn == '\\'
where(row, col)

#if row == 0 and placement == 1:
#   print(where())


col = 69