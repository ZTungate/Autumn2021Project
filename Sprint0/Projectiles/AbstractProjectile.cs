using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Projectiles
{
    public abstract class AbstractProjectile : IProjectile
    {
        public ISprite Sprite
        {
            get; set;
        }
        public Point Velocity
        {
            get; set;
        }
        public int Life
        {
            get; set;
        }
        public Rectangle DestRect
        {
            get; set;
        }
        public AbstractProjectile(Point position, Point velocity, Point size)
        {
            this.DestRect = new Rectangle(position, size);
            this.Velocity = velocity;
        }
        public virtual void Update(GameTime gameTime)
        {
            //no-op
        }
        public virtual void Draw(SpriteBatch batch)
        {
            Sprite.Draw(batch, DestRect);
        }
        public Point GetPosition()
        {
            return this.DestRect.Location;
        }
        public void SetPosition(Point pos)
        {
            this.DestRect = new Rectangle(pos, DestRect.Size);
        }
    }
}
