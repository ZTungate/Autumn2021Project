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
            song = content.Load<Song>("dungeon");
            
        }

        public void PlayMusic()
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }

        public void StopMusic()
        {
            MediaPlayer.Stop();
        }
    }
}
