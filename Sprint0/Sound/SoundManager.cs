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
        public Song song;
        public SoundEffect sound;
        public SoundEffectInstance instance;

        public SoundManager()
        {
            sound = null;
            instance = null;
        }


        public virtual void AdjustVolume(float percent)
        {
            if (instance != null) {
                instance.Volume = percent * volume;
            }

        }
        public void LoadContent(ContentManager content)
        {
            //load background music
            song = content.Load<Song>("dungeon");

            //load sound effects


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
        }

        public void ToggleSound()
        {
            if (volume == 0) {
                volume = 1;
            }
            else {
                volume = 0;
            }

            MediaPlayer.Volume = volume;

        }
    }
}
