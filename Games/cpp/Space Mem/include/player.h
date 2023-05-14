#ifndef PLAYER_H
#define PLAYER_H

#include "collisionobjects.h"
#include "globals.h"
#include "bullet.h"
#include <iostream>
#include "raylib.h"

class Player : public GameObject
{
public:
    Player();
    virtual void Update();
    virtual void Render();
    ~Player(void);

    Rectangle GetRect();
private:
    void UpdateCollisionRectPosition();
    Vector2 position;
    float speed;
    Texture texture;

    float lastShotTime;
    float timeBetweenShots;

    Sound shotSound;
    Rectangle collisionRect;
};

#endif