#include "collisionhandler.h"


CollisionHandler::CollisionHandler()
{
    gameObjects.push_back(this); // gameobjectbe "mentés"
}

void CollisionHandler::Update()
{
    // Sima collision (ez a kód nagyon rossz, de működik)
    for (Bullet* &bullet : bulletCollisionObjects)
    {
        for (Enemy* &enemy : enemyCollisionObjects)
        {
            bool collided = CheckCollisionRecs(bullet->GetRect(), enemy->GetRect());
            if (collided)
            {
                bullet->Destroy();
                enemy->Destroy();
            }
        }
    }

    for(Wall* &wall : wallCollisionObjects)
    {
        for(Enemy* &enemy : enemyCollisionObjects)
        {
            bool collided = CheckCollisionRecs(enemy->GetRect(), wall->GetRect());
            if (collided)
            {
                enemy->Unload();
            }
        }
    }

    for(Enemy* &enemy : enemyCollisionObjects)
    {
        for(Player* &player : playerCollisionObjects)
        {
            bool collided = CheckCollisionRecs(enemy->GetRect(), player->GetRect());
            if (collided)
            {
                enemy->Unload();
            }
        }
    }
}
void CollisionHandler::Render()
{

}


CollisionHandler::~CollisionHandler()
{

}