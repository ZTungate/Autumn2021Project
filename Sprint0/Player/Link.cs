using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Poggus.Projectiles;
using static Poggus.Projectiles.ProjectileConstants;
using Poggus.Items;
using Poggus.PlayerInventory;
using Poggus.Sound;
using Poggus.Collisions;

namespace Poggus.Player
{

    public class Link : ILink {

        //Game class contains a sprite factory, which creates each sprite with a source rectangle. this is saved in spriteBatch
        //spritebatch is passed down to the state in the player class (this file), which is sent to the state. The state actually draws the image.
        const int LinkX = 300;
        const int LinkY = 250;
        const int size = 64;
        public ILinkState State { get; set; }
        public Rectangle DestRect { get; set; }
        public Point OldPosition { get; set; }
        public ISprite Sprite { get; set; }
        public ProjectileFactory ProjectileFactory { get; set; }
        public SoundManager SoundManager { get; set; }
        public int Health { get; set; }
        public int maxHealth { get; set; }

        public Inventory LinkInventory { get; set; }

        float damageTimer;
        //public Inventory inventory = new Inventory();
        public float Timer = 0f;
        public bool canMove = true;
        public bool isDamaged = false;
        float invincibilityFramesDuration = LinkConstants.linkInvincibilityDuration;
        float hitStunDuration = LinkConstants.linkHitStunDuration;
        
        
        public Link()
        {
            State = new InitialLinkState(this,null); //start the player in the right idle state, initial sprite is null, will be fixed during content loading in game1
            DestRect = new Rectangle(new Point(LinkX, LinkY), new Point(size, size));
            System.Diagnostics.Debug.WriteLine(DestRect);
            LinkInventory = new Inventory();
            //LinkInventory.setSlotA(Poggus.Items.ItemSprites.ItemSpriteFactory.Instance.GetItemSprite(Items.ItemEnum.Arrow)); //temp to set sword
            LinkInventory.AddItem(new BowItem(new Point())); //temp to add item
            LinkInventory.AddItem(new SwordItem(new Point())); //temp to add item
            LinkInventory.AddItem(new ArrowItem(new Point())); //temp to add item
            LinkInventory.AddItem(new ClockItem(new Point())); //temp to add item

            //Set link's health and maxHealth
            Health = LinkConstants.linkInitialHealth;
            maxHealth = Health;
        }
        public void Reset()
        {
            State = new InitialLinkState(this, Sprite); //start the player in the right idle state

            Sprite.Color = Color.White;

            State = new InitialLinkState(this, Sprite); //start the player in the right idle state, initial sprite is null, will be fixed during content loading in game1
            DestRect = new Rectangle(new Point(300, 250), new Point(64, 64));
            System.Diagnostics.Debug.WriteLine(DestRect);
            LinkInventory = new Inventory();
            //Set link's health and maxHealth
            Health = LinkConstants.linkInitialHealth;
            maxHealth = Health;

        }
        public void Update(GameTime gameTime)
        {
            OldPosition = DestRect.Location;

            updateDamageState(gameTime);
            State.Update(gameTime);
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle tempRect = new Rectangle(DestRect.Location, new Point((int)(Sprite.SourceRect[Sprite.CurrentFrame].Width * Game1.gameScaleX), (int)(Sprite.SourceRect[Sprite.CurrentFrame].Height * Game1.gameScaleY)));
            
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
            if (!isDamaged) {
                this.SoundManager.sound.playLinkHit();
                isDamaged = true;
                canMove = false;
                Sprite.Color = Color.Red;
                damageTimer = invincibilityFramesDuration;
                //TODO: Knockback
                Health -= dmgAmount;
                SoundManager.sound.playLinkHit();
                knockback(damageDirection);
            }

            //Kill link if his health hits zero
            if(Health <= 0)
            {
                this.SoundManager.sound.playLinkDeath();
                State = new DeadLinkState(this, Sprite);
                SoundManager.sound.playLinkDeath();

            }
        }

        private void knockback(ColDirections dir)
        {
            switch (dir)
            {
                case ColDirections.North:
                    //knockback down
                    DestRect = new Rectangle(DestRect.Location + new Point(0,-LinkConstants.knockbackDistance), DestRect.Size);

                    break;
                case ColDirections.South:
                    //knockback up
                    DestRect = new Rectangle(DestRect.Location + new Point(0, LinkConstants.knockbackDistance), DestRect.Size);
                    break;
                case ColDirections.East:
                    //knockback left
                    DestRect = new Rectangle(DestRect.Location + new Point(LinkConstants.knockbackDistance, 0), DestRect.Size);
                    break;
                case ColDirections.West:
                    //knockback right
                    DestRect = new Rectangle(DestRect.Location + new Point(-LinkConstants.knockbackDistance, 0), DestRect.Size);
                    break;
                case ColDirections.None:
                    //no knockback
                    break;

            }

        }

        public void UseItem(ProjectileTypes item)
        {
            State.UseItem(item);
        }

        public void Move(Point moveDirection)
        {
            if (canMove) 
            {
                DestRect = new Rectangle(DestRect.Location + moveDirection, DestRect.Size);
            }   
        }
 

        //Attacks

        public void SwordAttack()
        {
            State.SwordAttack();
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