using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public static class EnemyConstants
    {
        //Enemy movement speeds
        public static int batMoveSpeed = 6;
        public static int dragonMoveSpeed = 6;
        public static int skeletonMoveSpeed = 6;
        public static int slimeMoveSpeed = 6;
        public static int throwerMoveSpeed = 6;
        public static int bladeAttackSpeed = 10;
        public static int bladeReturnSpeed = bladeAttackSpeed / 2;
        public static int grabberMoveSpeed = 6;

        //Enemy sizes
        public static float scaleX, scaleY;
        public static Rectangle stdEnemySize = new Rectangle(0,0, 16, 16);//Size of thrower, bladeTrap, skeleton, bat, and grabber.
        public static Rectangle slimeSize = new Rectangle(0, 0, 8, 16);
        public static Rectangle dragonSize = new Rectangle(0, 0, 24, 32);

        //Blade trap move times
        public static int horizBladeMoveTime = 1000;
        public static int vertBladeMoveTime = 500;
    }
    public enum EnemyTypes { Dragon, Skeleton, Slime, Thrower, Bat , OldMan, BladeTrap, Grabber };
}
