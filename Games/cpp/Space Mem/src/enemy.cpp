#include "enemy.h"
#include <stdio.h>
#include <iostream>
#include <fstream>
#include <chrono>
#include <thread>
#include <functional>

int multiplier = 0;

Enemy::Enemy()
{
    gameObjects.push_back(this); // gameobjectbe "mentés"
    enemyCollisionObjects.push_back(this);

    id = GetRandomValue(0, 2);

    SetTraceLogLevel(LOG_DEBUG);

    Image coin = LoadImage("../assets/coin.png");

    coinTexture = LoadTextureFromImage(coin);
    coinTexture.width /= 2;
    coinTexture.height /= 2;

    // 3 féle enemy van, mind a 3 máshogy néz ki, szóval azt loadoljuk be amelyik éppen ki lett választva
    switch (id)
    {
    case 0:
    {
        // Textúra
        Image enemyImageOne = LoadImage("../assets/enemy1.png");
        ImageRotateCW(&enemyImageOne);
        texture = LoadTextureFromImage(enemyImageOne);
        texture.height *= 10;
        texture.width *= 10;

        // Sebesség
        speed = (-400 + multiplier);
        char array[10];
        sprintf(array, "%f", speed);
        TraceLog(LOG_DEBUG, array);
        break;
    }
    case 1 : 
    {
        // Textúra
        Image enemyImageTwo = LoadImage("../assets/enemy2.png");
        ImageRotateCW(&enemyImageTwo);
        texture = LoadTextureFromImage(enemyImageTwo);
        texture.height *= 10;
        texture.width *= 10;

        // Sebesség
        speed =(-450 + multiplier);
        char array[10];
        sprintf(array, "%f", speed);
        TraceLog(LOG_DEBUG, array);
        break; 
    } case 2:
    {
        // Textúra
        Image enemyImageThree = LoadImage("../assets/enemy3.png");
        ImageRotateCW(&enemyImageThree);
        texture = LoadTextureFromImage(enemyImageThree);
        texture.height *= 10;
        texture.width *= 10;

        // Sebesség
        speed = (-465 + multiplier);
        char array[10];
        sprintf(array, "%f", speed);
        TraceLog(LOG_DEBUG, array);
        break;
    }
    default:
        printf("Hiba");
        break;
    }

    position.x = GetScreenWidth() + 150;
    position.y = GetRandomValue(64, GetScreenHeight() - 64);

    collisionRect.height = texture.height;
    collisionRect.width = texture.width;

    UpdateCollisionRectPosition();
}

void Enemy::Update()
{
    position.x += speed * GetFrameTime();
    UpdateCollisionRectPosition();
}
void Enemy::Render()
{
    DrawTexture(texture, position.x - texture.width / 2, position.y - texture.height / 2, WHITE);
}
inline void Enemy::UpdateCollisionRectPosition()
{
    collisionRect.x = position.x - texture.width / 2;
    collisionRect.y = position.y - texture.height / 2;
}
Rectangle Enemy::GetRect()
{
    return collisionRect;
}
void Enemy::Destroy()
{
    delete this;
}

void EndGame()
{
    isInMenu = !isInMenu;
    score = 0;
    lives = 3;
    btnState = 0; 
    btnAction = false; 
    ShowCursor();
}

void Enemy::Unload()
{
    for (Enemy* &enemy : enemyCollisionObjects)
    {
        UnloadTexture(enemy->texture);
        gameObjects.erase(std::remove(gameObjects.begin(), gameObjects.end(), enemy));
    }
    enemyCollisionObjects.clear();
    multiplier = 0;
    std::ofstream outfile;
    outfile.open("afile.txt");

    outfile << coins << std::endl;

    outfile.close();
    if(lives > 0)
    {
        lives -= 1;
    } else {
        EndGame();
    }
}

// Ez meg lesz hívva hogyha az egyik "meghal"
Enemy::~Enemy()
{
    ++score;
    multiplier -= 10;
    

    int szerencse = GetRandomValue(0, 5);
    if(szerencse == 1){
        coins += 5;
        std::ofstream outfile;
        outfile.open("afile.txt");

        outfile << coins << std::endl;

        outfile.close();
        //DrawTexture(coinTexture, position.x - texture.width / 2, position.y - texture.height / 2, YELLOW);
        //TraceLog(LOG_DEBUG, "spawned coin");
        //std::this_thread::sleep_for(std::chrono::seconds(5));
        //UnloadTexture(coinTexture);
    }

    enemyCollisionObjects.erase(std::remove(enemyCollisionObjects.begin(), enemyCollisionObjects.end(), this));
    gameObjects.erase(std::remove(gameObjects.begin(), gameObjects.end(), this));
    UnloadTexture(texture);
}