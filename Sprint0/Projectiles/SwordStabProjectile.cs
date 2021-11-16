using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class SwordStabProjectile : AbstractProjectile
    {
        public SwordStabProjectile(Point position, Point size) : base(position, Point.Zero, size)
        {
            Life = LinkConstants.swordAttackTime;
        }
        public override void Update(GameTime gameTime)
        {
            Life -= gameTime.ElapsedGameTime.Milliseconds;
        }
        public override void Draw(SpriteBatch batch)
        {
            //Do not draw.
        }
    }
}
