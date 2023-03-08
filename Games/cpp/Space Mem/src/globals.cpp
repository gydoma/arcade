#include "globals.h"
#include "raylib.h"
#include <fstream>
#include <iostream>
#include <stdio.h>
#include <typeinfo>

// GameObject "array" (minden object tárolására)
std::list<GameObject*> gameObjects;

int score = 10;
int coins = 0;
