#include "wall.h"
#include <fstream>
#include <iostream>
#include <stdio.h>

Wall::Wall()
{
    gameObjects.push_back(this); // gameobjectbe "mentés"
    wallCollisionObjects.push_back(this);

    Image playerImage = LoadImage("../assets/lava.png");
    ImageRotateCW(&playerImage);
    texture = LoadTextureFromImage(playerImage);
    texture.height *= 2;
    texture.width *= 0.5;

    position = {(float)GetScreenWidth() / 9, (float)GetScreenHeight() / 2};

    collisionRect.height = texture.height;
    collisionRect.width = texture.width;

    collisionRect.x = -400;
    collisionRect.y = position.y - texture.height / 2;
}

void Wall::Update()
{
    
}

Rectangle Wall::GetRect()
{
    return collisionRect;
}

void Wall::Render()
{
    //DrawTexture(texture, position.x - texture.width / 2, position.y - texture.height / 2, WHITE);
    DrawTexture(texture, -400, position.y - texture.height / 2, WHITE);
}

Wall::~Wall()
{
    UnloadTexture(texture);
    UnloadSound(shotSound);
}