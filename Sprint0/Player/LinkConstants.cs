using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Player
{
    public static class LinkConstants
    {
        //Amount of time link is in an item use state (miliseconds)
        public static int itemUseTime = 350;
        public static int swordAttackTime = 320;
        public static float scaleX, scaleY;
        public static int linkSpeed = 3;
        public static int knockBackTime = 200;
        public static int knockBackSpeed = 9;

        public static int linkSize = 16;

        public static int swordDamage = 1;

        public static int linkInitialHealth = 6;

        public static int movementAnimInterval = 128;
        public static int swordAnimInterval = 64;
        public static int pickupAnimInterval = 1000;

        public static Point originPos = new Point(475, 250);

        public static int linkDamageDelay = 50;
        public static int linkInvincibilityDuration = 2000;
        public static int linkHitStunDuration = 500;
        public static int linkKnockbackDistancePerFrame = 5;

        public static float linkScaleX = 1f, linkScaleY =1f;
    }
}
