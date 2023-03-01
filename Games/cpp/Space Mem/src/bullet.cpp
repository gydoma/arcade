#include "bullet.h"
#include <stdio.h>


Bullet::Bullet(Vector2 spawnPosition)
{
    //Init
    gameObjects.push_back(this); // gameobjectbe "mentés"
    bulletCollisionObjects.push_back(this); // Ha új töltény lesz, legyen collisionje

    int random = GetRandomValue(0, 2);

    // Textúra
    Image bulletImage = LoadImage("../assets/bullet.png");
    if (random == 1)
        bulletImage = LoadImage("../assets/bullet2.png");
    ImageRotateCW(&bulletImage); //Rotate to align
    texture = LoadTextureFromImage(bulletImage);
    texture.height *= 10;
    texture.width *= 10;

    bulletSpeed = 500;

    position = spawnPosition;
    position.x += 180;

    collisionRect.height = texture.height;
    collisionRect.width = texture.width;

    UpdateCollisionRectPosition();

    timeAlive = 0;
}
void Bullet::Update()
{
    position.x += bulletSpeed * GetFrameTime();

    if (timeAlive < 7)
    {
        timeAlive += GetFrameTime();
        UpdateCollisionRectPosition();
    }
    else
    {
        Destroy();
    }
}
void Bullet::Render()
{
    DrawTexture(texture, position.x - texture.width / 2, position.y - texture.height / 2, WHITE);
}

inline void Bullet::UpdateCollisionRectPosition()
{
    collisionRect.x = position.x - texture.width / 2;
    collisionRect.y = position.y - texture.height / 2;
}

Rectangle Bullet::GetRect()
{
    return collisionRect;
}
void Bullet::Destroy()
{
    delete this;
}

Bullet::~Bullet()
{
    bulletCollisionObjects.erase(std::remove(bulletCollisionObjects.begin(), bulletCollisionObjects.end(), this));
    gameObjects.erase(std::remove(gameObjects.begin(), gameObjects.end(), this));
    UnloadTexture(texture);
}