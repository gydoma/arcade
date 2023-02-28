#include "background.h"

Background::Background()
{
    gameObjects.push_back(this); // gameobjectbe "mentés"

    // Textúra
    Image backgroundImage = LoadImage("../assets/background.png");
    texture = LoadTextureFromImage(backgroundImage);
    SetTextureFilter(texture, 0);
}

void Background::Update()
{

}
void Background::Render()
{
    Rectangle source = {(float)GetScreenWidth() / 2, (float)GetScreenWidth() / 2 - texture.width, (float)GetScreenHeight() / 2, (float)GetScreenHeight() / 2 - texture.height};
    Rectangle destination = {0, 0, (float)GetScreenWidth() * 2, (float)GetScreenHeight() * 2};
    DrawTexturePro(texture, source, destination, {(float)GetScreenWidth() / 2, (float)GetScreenHeight() / 2}, 0, WHITE);
}

Background::~Background()
{
    UnloadTexture(texture);
}