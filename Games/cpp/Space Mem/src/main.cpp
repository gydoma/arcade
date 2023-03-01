#include "globals.h"
#include "raylib.h"
#include "gameobject.h"
#include "background.h"
#include "player.h"
#include "collisionhandler.h"
#include "enemyspawner.h"
#include "musicplayer.h"
#include "scoredisplay.h"
#include <list>
#include <iostream>

int main(void)
{
    InitWindow(GetScreenWidth(), GetScreenHeight(), "Space Mem");

    Background bg;
    CollisionHandler handler;
    Player player;
    EnemySpawner spawner;
    MusicPlayer musicPlayer;
    ScoreDisplay display;

    // Fő game loop
    while (!WindowShouldClose())
    {
        // Update
        for (GameObject* gameObject : gameObjects)
        {
            gameObject->Update();
        }

        // "Rajzolás"
        BeginDrawing();
        ClearBackground(WHITE);

        for (GameObject *gameObject : gameObjects)
        {
            gameObject->Render();
        }
        EndDrawing();
    }

    CloseWindow();

    return 0;
}