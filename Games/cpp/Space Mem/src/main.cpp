#include "globals.h"
#include "raylib.h"
#include "gameobject.h"
#include "background.h"
#include "player.h"
#include "collisionhandler.h"
#include "enemyspawner.h"
#include "musicplayer.h"
#include "scoredisplay.h"
#include "globals.h"
#include "wall.h"
#include <list>
#include <iostream>
#include <stdio.h>
#include <fstream>

bool isInMenu = true;
bool exitWindow = false;
int btnState = 0;
bool btnAction = false;

int main(void)
{
    InitWindow(GetScreenWidth(), GetScreenHeight(), "Space Mem");

    SetTraceLogLevel(LOG_DEBUG);

    Background bg;
    CollisionHandler handler;
    Player player;
    EnemySpawner spawner;
    MusicPlayer musicPlayer;
    ScoreDisplay display;
    Wall wall;

    SetExitKey(KEY_NULL);
    Texture2D button = LoadTexture("../assets/start.png");

    float frameHeight = (float)button.height;
    Rectangle sourceRec = { 0, 0, (float)button.width, frameHeight };

    Rectangle btnBounds = { GetScreenWidth()/2.0f - button.width/2.0f, (float)GetScreenHeight() / 1.3f - button.height/2.0f, (float)button.width, frameHeight };


    Vector2 mousePoint = { 0.0f, 0.0f };

    SetTargetFPS(60);
    // Fő game loop
    while (!exitWindow)
    {
        mousePoint = GetMousePosition();
        btnAction = false;

        // Check button state
        if (CheckCollisionPointRec(mousePoint, btnBounds))
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT) && isInMenu){ btnState = 2; }
            else btnState = 1;

            if (IsMouseButtonReleased(MOUSE_BUTTON_LEFT) && isInMenu) btnAction = true;
        }
        else btnState = 0;

        if (btnAction)
        {
            isInMenu = !isInMenu;
        }

        if(!isInMenu){
            if(IsKeyPressed(KEY_ESCAPE)){ isInMenu = !isInMenu; btnState = 0; btnAction = false; ShowCursor(); }
        } else {
            if(IsKeyPressed(KEY_BACKSPACE) || WindowShouldClose()) 
            { 
                exitWindow = true;
                std::ofstream outfile;
                outfile.open("afile.txt");

                outfile << coins << std::endl;

                outfile.close();
            }
        }

        sourceRec.y = btnState*frameHeight;

        BeginDrawing();
        // Update

        if(isInMenu){
            ClearBackground(RAYWHITE);
            DrawTextureRec(button, sourceRec, (Vector2){ btnBounds.x, btnBounds.y }, WHITE);
            int width = MeasureText("Press the button to start the game.", 40);
            DrawText("Press the button to start the game.", GetScreenWidth() / 2.9f, GetScreenHeight() / 2.0f, 20, RED);
        } else {
            HideCursor();
            for (GameObject* gameObject : gameObjects)
            {
                if(!isInMenu){
                    gameObject->Update();
                }
            }

        // "Rajzolás"
        
            ClearBackground(WHITE);

            for (GameObject *gameObject : gameObjects)
            {
                if(!isInMenu){
                    gameObject->Render();
                }
            }
        }
        
        EndDrawing();
    }

    CloseWindow();

    return 0;
}