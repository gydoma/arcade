#include "player.h"


Player::Player()
{
    gameObjects.push_back(this); // gameobjectbe "mentés"

    // A játékosunk
    Image playerImage = LoadImage("../assets/ship.png");
    ImageRotateCW(&playerImage);
    texture = LoadTextureFromImage(playerImage);
    texture.height *= 10;
    texture.width *= 10;

    // Pozíció
    position = {(float)GetScreenWidth() / 8, (float)GetScreenHeight() / 2};

    // Sebesség
    speed = -425;

    // Lövések "spameléséért"
    timeBetweenShots = 0.45f;
    lastShotTime = (float)GetTime() - timeBetweenShots;

    // Pontszám
    score = 0;

    // Lövés hang effekt
    shotSound = LoadSound("../assets/bullet.mp3");
}

void Player::Update()
{
    // Mivel 2D game, csak az y meg az x koordinátákat kell állítani
    if ((IsKeyDown(KEY_W) || IsKeyDown(KEY_UP)) && position.y > 64) 
    {
        // Felfele
        position.y += speed * GetFrameTime();
    }
    else if ((IsKeyDown(KEY_S) || IsKeyDown(KEY_DOWN)) && position.y < GetScreenHeight() - 64)
    {
        // Lefele
        position.y -= speed * GetFrameTime();
    }

    if (IsKeyPressed(KEY_SPACE) && lastShotTime + timeBetweenShots <= (float)GetTime())
    {
        new Bullet(position);

        PlaySound(shotSound);

        lastShotTime = (float)GetTime();
    }
}
void Player::Render()
{
    DrawTexture(texture, position.x - texture.width / 2, position.y - texture.height / 2, WHITE);
}


Player::~Player()
{
    UnloadTexture(texture);
    UnloadSound(shotSound);
}