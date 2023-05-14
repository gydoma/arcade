#ifndef GLOBALS_H
#define GLOBALS_H

#include "gameobject.h"
#include <list>

extern std::list<GameObject*> gameObjects;

extern int score;
extern int coins;
extern bool isInMenu;
extern bool EndMenu;
extern int btnState;
extern bool btnAction;
extern int lives;

#endif