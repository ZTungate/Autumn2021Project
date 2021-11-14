using Microsoft.Xna.Framework;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public static class ProjectileConstants
    {
        public enum ProjectileTypes{
            bomb,
            fireball,
            redArrow,
            blueArrow,
            fire,
            linkBoomerang,
            throwerBoomerang,
            blueBoomerang
        }

        public static Vector2 ArrowVelocity = new Vector2(6, 6);
        public static Vector2 RegBoomerangVelocity = new Vector2(3, 3);
        public static Vector2 BlueBoomerangVelocity = new Vector2(6, 6);
        public static Vector2 FireVelocity = new Vector2(6, 6);
        public static Point linkBoomerangMaxVelocity = new Point(1,1);

        public static Point VertArrowSize = new Point(16, 32);
        public static Point HorizArrowSize = new Point(32, 16);
        public static Point vertSwordBeamSize = new Point(16, 32);
        public static Point horizSwordBeamSize = new Point(32, 16);
        public static Point BombSize = new Point(32, 32);
        public static Point fireballSize = new Point(32, 32);
        public static Point boomerangSize = new Point(32, 32);
        public static Point fireSize = new Point(32, 32);
        public static Point swordBeamExplosionSize = new Point(8, 8);

        public static int regArrowLife = 3000;
        public static int blueArrowLife = 4000;
        public static int boomerangLife = 3000;
        public static int bombLife = 1000;
        public static int fireballLife = 2000;
        public static int fireLife = 2000;
        public static int swordBeamLife = 3000;
        public static int swordBeamBurstLife = 1000;

        public static int redArrowDamage = 2;
        public static int blueArrowDamage = 4;
        public static int bombDamage = 4;
        public static int fireDamage = 1;
        public static int swordBeamDamage = 1;
        public static int throwerBoomerangDamage = 1;
        public static int fireballDamage = 1;

    }
}
