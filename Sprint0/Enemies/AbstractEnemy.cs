using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poggus.Enemies
{
    public abstract class AbstractEnemy : IEnemy
    {
        public ISprite Sprite { get; set; }
        public IEnemyState State { get; set; }
        public Rectangle DestRect { get; set; }
        public Point oldPosition { get; set; }
        public EnemyTypes Type { get; }

        public AbstractEnemy(Point position, Point size)
        {
            this.DestRect = new Rectangle(position, size);
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
