#include "scoredisplay.h"


ScoreDisplay::ScoreDisplay()
{
    gameObjects.push_back(this); // gameobjectbe "mentés"
}

void ScoreDisplay::Update()
{

}
void ScoreDisplay::Render()
{
    DrawText(TextFormat("Pontszám: %01i", score), 100, 25, 32, WHITE);
}


ScoreDisplay::~ScoreDisplay()
{

}