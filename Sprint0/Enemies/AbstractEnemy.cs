using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Poggus.Enemies.Sprites;
using Poggus.Sound;
using Poggus.Collisions;

namespace Poggus.Enemies
{
    public abstract class AbstractEnemy : IEnemy
    {
        public bool interactable { get; set; } = true;
        public ISprite Sprite { get; set; }
        public IEnemyState State { get; set; }
        public Rectangle DestRect { get; set; }
        public Rectangle ColliderRect { get; set; }
        public Point oldPosition { get; set; }
        public EnemyType EnemyType { get; }
        public int Health { get; set; }
        public int StunTimer { get; set; }
        public int InvincibilityTimer { get; set; }

        public ColDirections knockBackDirection = ColDirections.None;
        public float knockBackTime = 0;

        public AbstractEnemy(EnemyType type, Point position, Point size)
        {
            this.EnemyType = type;
            this.DestRect = new Rectangle(position, size);
            this.StunTimer = 0;
        }
        public virtual void CreateSprite()
        {
            this.Sprite = EnemySpriteFactory.Instance.GetEnemySprite(this.EnemyType);
            //this.DestRect = new Rectangle(DestRect.Location, new Point((int)(Sprite.SourceRect[0].Width * Game1.gameScaleX),(int)(Sprite.SourceRect[0].Height * Game1.gameScaleY)));
            this.DestRect = new Rectangle(DestRect.Location, new Point((int)(DestRect.Width * Game1.gameScaleX), (int)(DestRect.Height * Game1.gameScaleY)));
        }
        public virtual void Update(GameTime gameTime)
        {
            knockback(gameTime);
            Sprite.Update(gameTime);
        }
        public virtual void Draw(SpriteBatch batch)
        {
            Sprite.Draw(batch, DestRect);
        }
        public void changeDifficulty(int oldDifficulty, int newDifficulty)
        {
            this.Health = (this.Health/oldDifficulty) * newDifficulty;
        }
        public Point GetPosition()
        {
            return this.DestRect.Location;
        }
        public void SetPosition(Point pos)
        {
            this.DestRect = new Rectangle(pos, DestRect.Size);
        }

        public virtual void TakeDamage(int damageAmount, ColDirections damageDirection)
        {
            if (InvincibilityTimer <= 0)
            {
                this.Health -= damageAmount;
                this.InvincibilityTimer = EnemyConstants.invincibilityTime;
                this.knockBackDirection = damageDirection;
                this.knockBackTime = Player.LinkConstants.knockBackTime;
                Game1.instance.soundManager.sound.playEnemyHit();
                
            }
        }

        private void knockback(GameTime gameTime)
        {
            if (knockBackTime > 0)
            {
                knockBackTime -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                switch (knockBackDirection)
                {
                    case ColDirections.North:
                        //knockback down
                        knockbackMove(new Point(0, Player.LinkConstants.knockBackSpeed));
                        break;
                    case ColDirections.South:
                        //knockback up
                        knockbackMove(new Point(0, -Player.LinkConstants.knockBackSpeed));
                        break;
                    case ColDirections.East:
                        //knockback left
                        knockbackMove(new Point(-Player.LinkConstants.knockBackSpeed, 0));
                        break;
                    case ColDirections.West:
                        //knockback right
                        knockbackMove(new Point(Player.LinkConstants.knockBackSpeed, 0));
                        break;
                    case ColDirections.None:
                        //no knockback
                        break;
                }
            }
        }

        private void knockbackMove(Point moveDirection)
        {
            /*            var xDir = moveDirection.X;
                        var yDir = moveDirection.Y;
                        var currentPos = this.GetPosition();
                        this.SetPosition(new Point(currentPos.X+xDir,currentPos.Y+yDir));*/
            DestRect = new Rectangle(DestRect.Location + moveDirection, DestRect.Size);
            
        }
    }
}
