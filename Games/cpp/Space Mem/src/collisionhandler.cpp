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
}
void CollisionHandler::Render()
{

}


CollisionHandler::~CollisionHandler()
{

}