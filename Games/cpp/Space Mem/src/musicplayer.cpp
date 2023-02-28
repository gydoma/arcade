#include "musicplayer.h"


MusicPlayer::MusicPlayer()
{
    gameObjects.push_back(this); // gameobjectbe "mentés"

    InitAudioDevice();

    music = LoadMusicStream("../assets/Zene.mp3");
    PlayMusicStream(music);
    music.looping = true;
}

void MusicPlayer::Update()
{
    UpdateMusicStream(music);
}
void MusicPlayer::Render()
{

}


MusicPlayer::~MusicPlayer()
{
    UnloadTexture(texture);
}