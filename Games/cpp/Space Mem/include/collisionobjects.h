#ifndef COLLISION_OBJECTS_H
#define COLLISION_OBJECTS_H

#include <list>

class Bullet;
class Enemy;
class Wall;

extern std::list<Bullet *> bulletCollisionObjects;
extern std::list<Enemy *> enemyCollisionObjects;
extern std::list<Wall *> wallCollisionObjects;

#endif