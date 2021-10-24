using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Projectiles
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
    }
}
