using Microsoft.Xna.Framework;
using Poggus.Helpers;
using Poggus;
using Poggus.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public class OldMan : AbstractEnemy
    {
        public override void Update(GameTime gameTime)
        {
            oldPosition = DestRect.Location;
            Sprite.Update(gameTime);
            //Decrement the invincibility timer if there is time on it
            if (InvincibilityTimer > 0)
            {
                InvincibilityTimer -= gameTime.ElapsedGameTime.Milliseconds;
            }
        }

        public OldMan(Point pos) : base(EnemyType.OldMan, pos, EnemyConstants.stdEnemySize.Size)
        {
            Health = EnemyConstants.oldManHealth;
        }

    }
}
