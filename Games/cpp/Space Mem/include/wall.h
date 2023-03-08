#ifndef WALL_H
#define WALL_H

#include "globals.h"
#include "bullet.h"
#include <iostream>

class Wall : public GameObject
{
public:
    Wall();
    virtual void Update();
    virtual void Render();
    ~Wall(void);
    Rectangle GetRect();
private:
    Vector2 position;
    Texture texture;

    Rectangle collisionRect;
    
};

#endif