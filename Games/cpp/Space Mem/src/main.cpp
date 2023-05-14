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
bool EndMenu = false;
bool exitWindow = false;
int btnState = 0;
bool btnAction = false;
int endbtnState = 0;
bool endbtnAction = false;

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
    Texture2D button2 = LoadTexture("../assets/restart.png");

    float frameHeight = (float)button.height;
    Rectangle sourceRec = { 0, 0, (float)button.width, frameHeight };

    float restartFrameHeight = (float)button2.height;
    Rectangle restartSourceRec = { 0, 0, (float)button2.width, restartFrameHeight };

    Rectangle btnBounds = { GetScreenWidth()/2.0f - button.width/2.0f, (float)GetScreenHeight() / 1.3f - button.height/2.0f, (float)button.width, frameHeight };
    Rectangle restartBtnBounds = { GetScreenWidth()/2.0f - button2.width/2.0f, (float)GetScreenHeight() / 1.3f - button2.height/2.0f, (float)button2.width, frameHeight };


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
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT) && isInMenu && !EndMenu){ btnState = 2; }
            else btnState = 1;

            if (IsMouseButtonReleased(MOUSE_BUTTON_LEFT) && isInMenu && !EndMenu) btnAction = true;
        }
        else btnState = 0;

        if (btnAction)
        {
            isInMenu = !isInMenu;
        }

        if (CheckCollisionPointRec(mousePoint, restartBtnBounds))
        {
            if (IsMouseButtonDown(MOUSE_BUTTON_LEFT) && EndMenu){ endbtnState = 2; EndMenu = false; }
            else endbtnState = 1;

            if (IsMouseButtonReleased(MOUSE_BUTTON_LEFT) && EndMenu) endbtnAction = true;
        }
        else endbtnState = 0;

        if (endbtnAction)
        {
            EndMenu = !EndMenu;
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
            if(EndMenu){
                ClearBackground(RAYWHITE);
                DrawTextureRec(button2, restartSourceRec, (Vector2){ restartBtnBounds.x / 1.6f, restartBtnBounds.y }, WHITE);
                score = 0;
                DrawText(TextFormat("Elért pontszám: %01i", score), GetScreenWidth() / 2.7f, GetScreenHeight() / 2.0f, 40, RED);
            } else {
                ClearBackground(RAYWHITE);
                DrawTextureRec(button, sourceRec, (Vector2){ btnBounds.x, btnBounds.y }, WHITE);
                DrawText("Nyomj rá a gombra hogy elindítsd a játékot.", GetScreenWidth() / 2.9f, GetScreenHeight() / 2.0f, 20, RED);
            };
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