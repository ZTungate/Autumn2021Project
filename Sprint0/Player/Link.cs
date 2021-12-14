using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Poggus.Projectiles;
using static Poggus.Projectiles.ProjectileConstants;
using Poggus.Items;
using Poggus.PlayerInventory;
using Poggus.Sound;
using Poggus.Collisions;
using Microsoft.Xna.Framework.Audio;

namespace Poggus.Player
{

    public class Link : ILink {

        //Game class contains a sprite factory, which creates each sprite with a source rectangle. this is saved in spriteBatch
        //spritebatch is passed down to the state in the player class (this file), which is sent to the state. The state actually draws the image.
        const int LinkX = 475;
        const int LinkY = 250;
        const int size = 64;
        public ILinkState State { get; set; }
        public Rectangle DestRect { get; set; }
        public Rectangle ColliderRect { get; set; }
        public Point OldPosition { get; set; }
        public ISprite Sprite { get; set; }
        public ProjectileFactory ProjectileFactory { get; set; }
        public SoundManager SoundManager { get; set; }
        public int Health { get; set; }
        public int maxHealth { get; set; }
        public bool collideWithBounds { get; set; } = true;

        public Inventory LinkInventory { get; set; }

        float damageTimer;
        //public Inventory inventory = new Inventory();
        public float Timer = 0f;
        public bool canMove = true;
        public bool isDamaged = false;
        public bool canAttack = true;
        public bool canUseItems = true;
        public bool movingTo { get; set; }
        public bool hasPickedUpBombs { get; set; }

        public ColDirections knockBackDirection;
        public float knockBackTime = 0;

        private SoundEffectInstance lowHealthSound;
        private bool isPlayingLow = false;

        float invincibilityFramesDuration = LinkConstants.linkInvincibilityDuration;
        float hitStunDuration = LinkConstants.linkHitStunDuration;
        
        
        public Link()
        {
            State = new InitialLinkState(this,null); //start the player in the right idle state, initial sprite is null, will be fixed during content loading in game1
            DestRect = new Rectangle(new Point(LinkX, LinkY), new Point(size, size));
            //System.Diagnostics.Debug.WriteLine(DestRect);
            LinkInventory = new Inventory();
            //LinkInventory.setSlotA(Poggus.Items.ItemSprites.ItemSpriteFactory.Instance.GetItemSprite(Items.ItemEnum.Arrow)); //Debug items
            //LinkInventory.setSlotA(new SwordItem(new Point()));
            //LinkInventory.AddItem(new BowItem(new Point())); //temp to add item
            //LinkInventory.AddItem(new SwordItem(new Point())); //temp to add item
            //LinkInventory.AddItem(new ArrowItem(new Point())); //temp to add item
            //LinkInventory.AddItem(new ClockItem(new Point())); //temp to add item

            //Set link's health and maxHealth
            Health = LinkConstants.linkInitialHealth;
            maxHealth = Health;
            hasPickedUpBombs = false;
        }
        public void Reset()
        {
            State = new InitialLinkState(this, Sprite); //start the player in the right idle state

            Sprite.Color = Color.White;

            State = new InitialLinkState(this, Sprite); //start the player in the right idle state, initial sprite is null, will be fixed during content loading in game1
            DestRect = new Rectangle(new Point(475, 250), new Point(64, 64));
            System.Diagnostics.Debug.WriteLine(DestRect);
            LinkInventory = new Inventory();
            //Set link's health and maxHealth
            Health = LinkConstants.linkInitialHealth;
            maxHealth = Health;
            hasPickedUpBombs = false;

        }
        public void Update(GameTime gameTime)
        {
            OldPosition = DestRect.Location;
            if (movingTo)
            {
                this.SetPosition(this.GetPosition() + moveDir);
                if((this.GetPosition().ToVector2() - nextPoint.ToVector2()).LengthSquared() <= 4f)
                {
                    this.SetPosition(nextPoint);
                    this.movingTo = false;
                    this.collideWithBounds = true;
                }
            }

            updateDamageState(gameTime);
            knockback(gameTime);
            State.Update(gameTime);
            Sprite.Update(gameTime);

            ColliderRect = new Rectangle(DestRect.Location + new Point(8, (int)(DestRect.Height / 2f)), new Point(DestRect.Width - 16, (int)(DestRect.Height / 2f) - 12));
        }
        Point nextPoint, moveDir;
        public void StartMoveToNewRoom(Point nextPoint)
        {
            if (!movingTo)
            {
                this.collideWithBounds = false;
                this.nextPoint = nextPoint;
                moveDir = new Point(nextPoint.X - GetPosition().X, nextPoint.Y - GetPosition().Y);
                if (moveDir.X != 0)
                {
                    moveDir.X /= Math.Abs(moveDir.X);
                }
                if (moveDir.Y != 0)
                {
                    moveDir.Y /= Math.Abs(moveDir.Y);
                }
                moveDir.X *= 3;
                moveDir.Y *= 3;

                movingTo = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle tempRect = new Rectangle(DestRect.Location, new Point((int)(Sprite.SourceRect[Sprite.CurrentFrame].Width * Game1.gameScaleX * LinkConstants.linkScaleX), (int)(Sprite.SourceRect[Sprite.CurrentFrame].Height * Game1.gameScaleY * LinkConstants.linkScaleY)));
            
            Sprite.Draw(spriteBatch, tempRect);   //draw the player sprite
        }

        private void updateDamageState(GameTime gameTime)
        {
            if (isDamaged)
            {

                damageTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (damageTimer <= LinkConstants.linkDamageDelay)
                { //damage invincibility time
                    isDamaged = false;
                    Sprite.Color = Color.White;
                }
                else if (damageTimer < (invincibilityFramesDuration - hitStunDuration)) //hit stun duration
                {
                    canMove = true;
                }
                damageTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            }
            else
            {
                canMove = true;
            }
        }
        public void TakeDamage(int dmgAmount, ColDirections damageDirection)
        {
            if (!isDamaged && !(State is DeadLinkState)) {

                isDamaged = true;
                canMove = false;
                Sprite.Color = Color.Red;
                damageTimer = invincibilityFramesDuration;
                //TODO: Knockback
                Health -= dmgAmount;
                SoundManager.sound.playLinkHit();

                if (Health > 0)
                {
                    knockBackDirection = damageDirection;
                    knockBackTime = LinkConstants.knockBackTime;
                }
                if (Health < 2 && !isPlayingLow) {
                    lowHealthSound = SoundManager.sound.playLowHealthSound();
                    isPlayingLow = true;
                }
                else {
                    if (!(lowHealthSound is null)) {
                        lowHealthSound.Stop();
                        isPlayingLow = false;
                    }
                }
            
            }

            //Kill link if his health hits zero
            if(Health <= 0 && !(State is DeadLinkState))
            {
                State = new DeadLinkState(this, Sprite);
                SoundManager.sound.playLinkDeath();

            }
        }

        private void knockback(GameTime gameTime)
        {
            if (knockBackTime > 0) {
                canAttack = false;
                canUseItems = false;
                knockBackTime -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                switch (knockBackDirection) {
                    case ColDirections.North:
                        //knockback down
                        knockbackMove(new Point(0, LinkConstants.knockBackSpeed));
                        break;
                    case ColDirections.South:
                        //knockback up
                        knockbackMove(new Point(0, -LinkConstants.knockBackSpeed));
                        break;
                    case ColDirections.East:
                        //knockback left
                        knockbackMove(new Point(-LinkConstants.knockBackSpeed, 0));
                        break;
                    case ColDirections.West:
                        //knockback right
                        knockbackMove(new Point(LinkConstants.knockBackSpeed, 0));
                        break;
                    case ColDirections.None:
                        //no knockback
                        break;
                }
            }
            else {
                canAttack = true;
                canUseItems = true;
            }
        }

        public void UseItem(ProjectileTypes item)
        {
            if (canUseItems) {
                State.UseItem(item);
            }
        }

        public void Move(Point moveDirection)
        {
            if (canMove) 
            {
                DestRect = new Rectangle(DestRect.Location + moveDirection, DestRect.Size);
            }   
        }
 
        private void knockbackMove(Point moveDirection)
        {
            DestRect = new Rectangle(DestRect.Location + moveDirection, DestRect.Size);
        }

        //Attacks
        public void SwordAttack()
        {
            if (canAttack) {
                State.SwordAttack();
            }
        }

        public void PickUp(AbstractItem item)
        {
            State.PickUp(item);
        }

        public Point GetPosition()
        {
            return this.DestRect.Location;
        }
        public void SetPosition(Point pos)
        {
            this.DestRect = new Rectangle(pos, DestRect.Size);
        }
        public Rectangle GetCollider()
        {
            return this.ColliderRect;
        }

        public bool FullHealth()
        {
            //Return true if health is full, false otherwise
            if (Health == maxHealth)
            {
                return true;
            }
            return false;
        }
    }
    
}