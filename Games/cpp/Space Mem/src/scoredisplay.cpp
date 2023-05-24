#include "scoredisplay.h"
#include <iostream>
#include <stdio.h>
#include <typeinfo>
#include <fstream>

int LoadPoints()
{
    int data;

    std::ifstream infile; 
    infile.open("afile.txt"); 

    infile >> data;

    char array[10];
    sprintf(array, "%i", data);
    if(typeid(data).name() == typeid(int).name()){
        TraceLog(LOG_INFO, array);
        TraceLog(LOG_INFO, "-------------------------------------------------------");
        return data;
    } else {
        TraceLog(LOG_INFO, "null");
        TraceLog(LOG_INFO, "-------------------------------------------------------");
        return 0;
    }
}


ScoreDisplay::ScoreDisplay()
{
    gameObjects.push_back(this); // gameobjectbe "mentés"
    coins = LoadPoints();
    lives = 3;
    Image health = LoadImage("../assets/heart.png");
    Image emptyHealth = LoadImage("../assets/emptyheart.png");

    texture1 = LoadTextureFromImage(health);
    
    emptyTexture1 = LoadTextureFromImage(emptyHealth);

    texture1.height /= 5;
    texture1.width /= 5;

    emptyTexture1.height /= 5;
    emptyTexture1.width /= 5;
}

void ScoreDisplay::Update()
{
    //char array[10];
    //sprintf(array, "%i", coins);
    //TraceLog(LOG_INFO, array);
}
void ScoreDisplay::Render()
{
    if(lives == 3){
        DrawTexture(texture1, GetScreenWidth() / 2.3, 25, RED);
        DrawTexture(texture1, GetScreenWidth() / 2, 25, RED);
        DrawTexture(texture1, GetScreenWidth() / 1.8, 25, RED);
    } else if(lives == 2)
    {
        DrawTexture(texture1, GetScreenWidth() / 2.3, 25, RED);
        DrawTexture(texture1, GetScreenWidth() / 2, 25, RED);
        DrawTexture(emptyTexture1, GetScreenWidth() / 1.8, 25, BLACK);
    } else if(lives == 1){
        DrawTexture(texture1, GetScreenWidth() / 2.3, 25, RED);
        DrawTexture(emptyTexture1, GetScreenWidth() / 2, 25, BLACK);
        DrawTexture(emptyTexture1, GetScreenWidth() / 1.8, 25, BLACK);
    } else{
        DrawTexture(emptyTexture1, GetScreenWidth() / 2.3, 25, BLACK);
        DrawTexture(emptyTexture1, GetScreenWidth() / 2, 25, BLACK);
        DrawTexture(emptyTexture1, GetScreenWidth() / 1.8, 25, BLACK);
    }
    //DrawText(TextFormat("Élet: %01i", lives), GetScreenWidth() / 2.3, 25, 32, RED);
    DrawText(TextFormat("Pontszám: %01i", score), 100, 25, 40, WHITE);
    DrawText(TextFormat("Pénz: %01i", coins), GetScreenWidth() / 1.2, 25, 40, WHITE);
}


ScoreDisplay::~ScoreDisplay()
{

}