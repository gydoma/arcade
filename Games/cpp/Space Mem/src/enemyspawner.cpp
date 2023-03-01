#include "enemyspawner.h"


EnemySpawner::EnemySpawner()
{
    gameObjects.push_back(this); // gameobjectbe "mentés"

    timeBetweenSpawns = 1.0f;
    timeAtLastSpawn = GetTime() - timeBetweenSpawns;
}

void EnemySpawner::Update()
{
    if (timeAtLastSpawn + timeBetweenSpawns <= (float)GetTime())
    {
        Spawn();

        timeAtLastSpawn = (float)GetTime();
    }
}
void EnemySpawner::Render()
{

}

EnemySpawner::~EnemySpawner()
{
    enemies.clear();
}

////////////////////////////////
void EnemySpawner::Spawn()
{
    Enemy* enemy = new Enemy();
    enemies.push_back(enemy);
}