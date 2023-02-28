#include "enemy.h"


Enemy::Enemy()
{
    gameObjects.push_back(this); // gameobjectbe "mentés"
    enemyCollisionObjects.push_back(this);

    id = GetRandomValue(0, 2);

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
        speed = -400;
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
        speed = -450;
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
        speed = -465;
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

// Ez meg lesz hívva hogyha az egyik "meghal"
Enemy::~Enemy()
{
    ++score;

    enemyCollisionObjects.erase(std::remove(enemyCollisionObjects.begin(), enemyCollisionObjects.end(), this));
    gameObjects.erase(std::remove(gameObjects.begin(), gameObjects.end(), this));
    UnloadTexture(texture);
}