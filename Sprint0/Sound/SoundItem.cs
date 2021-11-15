using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Sound
{
    class SoundItem
    {
        public float myVolume;
        public SoundEffect sound;
        public SoundEffectInstance instance;

        public SoundItem(float volume)
        {
            myVolume = volume;


        }

    }
}
