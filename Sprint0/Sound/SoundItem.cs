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
        private SoundEffect swordSlash;
        private SoundEffect swordBeam;
        private SoundEffect swordCombined;
        private SoundEffect shieldDeflect;
        private SoundEffect arrowBoomerang;
        private SoundEffect bombDrop;
        private SoundEffect bombBlow;
        private SoundEffect enemyHit;
        private SoundEffect enemyDeath;
        private SoundEffect linkHit;
        private SoundEffect linkDeath;
        private SoundEffect lowHealth;
        private SoundEffect fanfare;
        private SoundEffect getItem;
        private SoundEffect getHeart;
        private SoundEffect getRupee;
        private SoundEffect refillLoop;
        private SoundEffect textLoop;
        private SoundEffect slowTextLoop;
        private SoundEffect keyAppear;
        private SoundEffect bossScream;
        private SoundEffect bossHurt;
        private SoundEffect stairs;
        private SoundEffect secret;

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

        public SoundEffectInstance playBombDrop()
        {
            instance = bombDrop.CreateInstance();
            instance.Volume = myVolume;
            instance.IsLooped = true;
            instance.Play();
            return instance;
        }

        public void playBombBlow()
        {
            instance = bombBlow.CreateInstance();
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

        public SoundEffectInstance playLowHealthSound()
        {
            instance = lowHealth.CreateInstance();
            instance.Volume = myVolume;
            instance.IsLooped = true;
            instance.Play();
            return instance;
        }

        public void playFanfare()
        {
            instance = fanfare.CreateInstance();
            playSound();
        }

        public void playLinkHit()
        {
            instance = linkHit.CreateInstance();
            playSound();
        }

        public void playLinkDeath()
        {
            instance = linkDeath.CreateInstance();
            playSound();
        }

        public void playItemPickup()
        {
            instance = getItem.CreateInstance();
            playSound();
        }

        public void playRupeePickup()
        {
            instance = getRupee.CreateInstance();
            playSound();
        }

        public void playHeartPickup()
        {
            instance = getHeart.CreateInstance();
            playSound();
        }

        public void playEnemyHit()
        {
            instance = enemyHit.CreateInstance();
            playSound();
        }

        public void playEnemyDeath()
        {
            instance = enemyDeath.CreateInstance();
            playSound();
        }

        public void playSecret()
        {
            instance = secret.CreateInstance();
            playSound();
        }

        public void playShieldSound()
        {
            instance = shieldDeflect.CreateInstance();
            playSound();
        }
        public void playFireballSound()
        {
            instance = bossScream.CreateInstance();
            playSound();
        }

        public void playSound()
        {
            instance.Volume = myVolume;
            instance.Play();
        }

        public void stopSound()
        {
            if (!(instance is null)) {
                instance.Stop();
            }
        }

    }
}
