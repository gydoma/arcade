#ifndef COLLISION_OBJECTS_H
#define COLLISION_OBJECTS_H

#include <list>

class Bullet;
class Enemy;

extern std::list<Bullet *> bulletCollisionObjects;
extern std::list<Enemy *> enemyCollisionObjects;

#endif