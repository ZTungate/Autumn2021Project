using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Projectiles
{
    public interface IProjectile
    {
        public ISprite Sprite { get; set; }

        public Rectangle DestRect { get; set; }
        public Point Velocity { get; set; }

        public int Life { get; set; }
        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch batch);
        public Point GetPosition();
        public void SetPosition(Point pos);
    }
}
