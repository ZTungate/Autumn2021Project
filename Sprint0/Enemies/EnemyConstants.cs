using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public static class EnemyConstants
    {
        //private static int difficulty = Game1.instance.menuHandler.difficulty;
        public static int invincibilityTime = 500;
        //Enemy movement speeds
        public static int batMoveSpeed = 10;
        public static int dragonMoveSpeed = 6;
        public static int skeletonMoveSpeed = 6;
        public static int slimeMoveSpeed = 8;
        public static int throwerMoveSpeed = 6;
        public static int bladeAttackSpeedHoriz = 6;
        public static int bladeAttackSpeedVert = 3;
        public static int bladeReturnSpeedHoriz = 2;
        public static int bladeReturnSpeedVert = 1;

        //Enemy sizes
        public static float scaleX, scaleY;
        public static Rectangle stdEnemySize = new Rectangle(0,0, 16, 16);//Size of thrower, bladeTrap, skeleton, bat, and grabber.
        public static Point bladeTrapSize = new Point(14, 14);
        public static Rectangle slimeSize = new Rectangle(0, 0, 8, 16);
        public static Rectangle dragonSize = new Rectangle(0, 0, 24, 32);

        //Blade trap move times
        public static int horizBladeAttackTime = 900;
        public static int vertBladeAttackTime = 600;
        public static int horizBladeReturnTime = 2700;
        public static int vertBladeReturnTime = vertBladeAttackTime * 3;

        //Grabber stuff
        public static int grabberStateTime = 2000;
        public static int grabberEmergeVelocity = 1;
        public static int grabberSlideVelocity = 2;

        //Enemy Healths
        public static int batHealth = 1;
        public static int skeletonHealth = 2;
        public static int slimeHealth = 1;
        public static int throwerHealth = 3;
        public static int grabberHealth = 2;
        public static int dragonHealth = 6;
        public static int bladeTrapHealth = 99; //Note: blade traps do not take damage, so any number > 0 works
        public static int oldManHealth = 10;

        //Enemy Attack Damage
        public static int batDamage = 1;
        public static int skeletonDamage = 1;
        public static int slimeDamage = 1;
        public static int bladeTrapDamage = 1;
        public static int throwerDamage = 2;
        public static int grabberDamage = 1;
        public static int dragonDamage = 2;

        //Enemy attack rates
        public static int dragonAttackInterval = 2000;
        public static int throwerAttackDelay = 3000;

        public static int clockStunTime = 2000;
        public static int grabberFlipTrigger = -10000;

        public static int roomHeight = 1000;
        public static int roomLength = 1000;
        public static int rupeeDropRate = 30;
        public static int grabberMaxDelay = 1000;

        public static int numItemDropTypes = 3;
    }
}
