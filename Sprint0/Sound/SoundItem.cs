using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Sound
{
    public class SoundItem
    {
        public float myVolume;

        //sound effects
        public SoundEffect swordSlash;
        public SoundEffect swordBeam;
        public SoundEffect swordCombined;
        public SoundEffect shieldDeflect;
        public SoundEffect arrowBoomerang;
        public SoundEffect bombDrop;
        public SoundEffect bombBlow;
        public SoundEffect enemyHit;
        public SoundEffect enemyDeath;
        public SoundEffect linkHit;
        public SoundEffect linkDeath;
        public SoundEffect lowHealth;
        public SoundEffect fanfare;
        public SoundEffect getItem;
        public SoundEffect getHeart;
        public SoundEffect getRupee;
        public SoundEffect refillLoop;
        public SoundEffect textLoop;
        public SoundEffect slowTextLoop;
        public SoundEffect keyAppear;
        public SoundEffect bossScream;
        public SoundEffect bossHurt;
        public SoundEffect stairs;
        public SoundEffect secret;

        public SoundEffectInstance instance;

        public SoundItem(float volume)
        {
            myVolume = volume;
        }

        public void LoadContent(ContentManager content)
        {
            //Load sound effects
            swordSlash = content.Load<SoundEffect>("LOZ_Sword_Slash");
            swordBeam = content.Load<SoundEffect>("LOZ_Sword_Shoot");
            swordCombined = content.Load<SoundEffect>("LOZ_Sword_Combined");
            shieldDeflect = content.Load<SoundEffect>("LOZ_Shield");
            arrowBoomerang = content.Load<SoundEffect>("LOZ_Arrow_Boomerang");
            bombDrop = content.Load<SoundEffect>("LOZ_Bomb_Drop");
            bombBlow = content.Load<SoundEffect>("LOZ_Bomb_Blow");
            enemyHit = content.Load<SoundEffect>("LOZ_Enemy_Hit");
            enemyDeath = content.Load<SoundEffect>("LOZ_Enemy_Die");
            linkHit = content.Load<SoundEffect>("LOZ_Link_Hurt");
            linkDeath = content.Load<SoundEffect>("LOZ_Link_Die");
            lowHealth = content.Load<SoundEffect>("LOZ_LowHealth");
            fanfare = content.Load<SoundEffect>("LOZ_Fanfare");
            getItem = content.Load<SoundEffect>("LOZ_Get_Item");
            getHeart = content.Load<SoundEffect>("LOZ_Get_Heart");
            getRupee = content.Load<SoundEffect>("LOZ_Get_Rupee");
            refillLoop = content.Load<SoundEffect>("LOZ_Refill_Loop");
            textLoop = content.Load<SoundEffect>("LOZ_Text");
            slowTextLoop = content.Load<SoundEffect>("LOZ_Text_Slow");
            keyAppear = content.Load<SoundEffect>("LOZ_Key_Appear");
            bossScream = content.Load<SoundEffect>("LOZ_Boss_Scream1");
            bossHurt = content.Load<SoundEffect>("LOZ_Boss_Hit");
            stairs = content.Load<SoundEffect>("LOZ_Stairs");
            secret = content.Load<SoundEffect>("LOZ_Secret");
        }

        public void SetVolume(float volume)
        {
            myVolume = volume;
        }

        public void playSwordSlash()
        {
            instance = swordSlash.CreateInstance();
            playSound();
        }

        public void playSwordBeam()
        {
            instance = swordBeam.CreateInstance();
            playSound();
        }

        public void playSwordCombined()
        {
            instance = swordCombined.CreateInstance();
            playSound();
        }

        public void playArrow()
        {
            instance = arrowBoomerang.CreateInstance();
            playSound();
        }

        public SoundEffectInstance playBoomerang()
        {
            instance = arrowBoomerang.CreateInstance();
            instance.Volume = myVolume;
            instance.IsLooped = true;
            instance.Play();
            return instance;
        }

        public void stopBoomerang(SoundEffectInstance instance)
        {
            instance.Stop();
        }

        public void playFanfare()
        {
            instance = fanfare.CreateInstance();
            playSound();
        }


        public void playSound()
        {
            instance.Volume = myVolume;
            instance.Play();
        }

    }
}
