using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Poggus.Enemies.Sprites;
using Poggus.Sound;

namespace Poggus.Enemies
{
    public abstract class AbstractEnemy : IEnemy
    {
        public ISprite Sprite { get; set; }
        public IEnemyState State { get; set; }
        public Rectangle DestRect { get; set; }
        public Point oldPosition { get; set; }
        public EnemyType EnemyType { get; }
        public int Health { get; set; }
        public int StunTimer { get; set; }

        public int InvincibilityTimer { get; set; }

        public AbstractEnemy(EnemyType type, Point position, Point size)
        {
            this.EnemyType = type;
            this.DestRect = new Rectangle(position, size);
            this.StunTimer = 0;
        }
        public virtual void CreateSprite()
        {
            this.Sprite = EnemySpriteFactory.Instance.GetEnemySprite(this.EnemyType);
            this.DestRect = new Rectangle(DestRect.Location, new Point((int)(Sprite.SourceRect[0].Width * Game1.gameScaleX),(int)(Sprite.SourceRect[0].Height * Game1.gameScaleY)));
        }
        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
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

        public void TakeDamage(int damageAmount)
        {
            if (InvincibilityTimer <= 0)
            {
                this.Health -= damageAmount;
                this.InvincibilityTimer = EnemyConstants.invincibilityTime;
                Game1.instance.soundManager.sound.playEnemyHit();
            }
        }
    }
}
