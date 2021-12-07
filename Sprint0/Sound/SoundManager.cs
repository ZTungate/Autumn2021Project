using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Sound
{
    public class SoundManager
    {
        public float volume;
        //background music
        public Song song;

        public SoundItem sound;

        private float oldVolume = 0;
        private static SoundManager instance = new SoundManager();

        public static SoundManager Instance
        {
            get
            {
                return instance;
            }
        }
        public SoundManager()
        {
            volume = 1f;
            sound = new SoundItem(volume);
        }
        
        public void LoadContent(ContentManager content)
        {
            //load background music
            song = content.Load<Song>("dungeon");

            //Load sound effects
            sound.LoadContent(content);

            //start the music
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }

        public void ResumeMusic()
        {
            MediaPlayer.Resume();
        }

        public void StopMusic()
        {
            MediaPlayer.Pause();
            sound.stopSound();
        }

        public void Reset()
        {

        }

        public void SetVolume(float newVolume)
        {
            sound.SetVolume(newVolume);
            MediaPlayer.Volume = newVolume;
            volume = newVolume;
        }

        public void ToggleSound()
        {
            if (volume != 0) {
                oldVolume = volume;
                volume = 0;
            }
            else {
                volume = oldVolume;
            }

            sound.SetVolume(volume);
            sound.stopSound();
            
            MediaPlayer.Volume = volume;


        }
    }
}
