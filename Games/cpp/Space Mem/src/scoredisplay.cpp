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
}

void ScoreDisplay::Update()
{
    //char array[10];
    //sprintf(array, "%i", coins);
    //TraceLog(LOG_INFO, array);
}
void ScoreDisplay::Render()
{
    DrawText(TextFormat("Pontszám: %01i", score), 100, 25, 32, WHITE);
    DrawText(TextFormat("Pénz: %01i", coins), GetScreenWidth() / 3, 25, 32, WHITE);
}


ScoreDisplay::~ScoreDisplay()
{

}