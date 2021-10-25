using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
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

        //Enemy sizes
        public static Rectangle stdEnemySize = new Rectangle(0,0, 32, 32);//Size of thrower, bladeTrap, skeleton, bat, and grabber.
        public static Rectangle slimeSize = new Rectangle(0, 0, 16, 32);
        public static Rectangle dragonSize = new Rectangle(0, 0, 48, 64);
    }
    public enum EnemyTypes { Dragon, Skeleton, Slime, Thrower, Bat , OldMan, SpikeTrap, Grabber };
}
