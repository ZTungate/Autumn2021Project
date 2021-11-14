using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Poggus.Projectiles;
using static Poggus.Projectiles.ProjectileConstants;
using Poggus.Items;
using Sprint0.Inventory;

namespace Poggus.Player
{

    public class Link : ILink {

        //Game class contains a sprite factory, which creates each sprite with a source rectangle. this is saved in spriteBatch
        //spritebatch is passed down to the state in the player class (this file), which is sent to the state. The state actually draws the image.

        public ILinkState State { get; set; }
        public Rectangle DestRect { get; set; }
        public Point OldPosition { get; set; }
        public ISprite Sprite { get; set; }
        public ProjectileFactory ProjectileFactory { get; set; }
        public int Health { get; set; }

        float damageTimer;
        Color[] damageColors = new Color[2] { Color.Red, Color.Blue };
        public Inventory inventory = new Inventory();
        public float Timer = 0f;
        float damageFlashRate = 50f;
        public bool canMove = true;
        public bool isDamaged = false;
        int colorIndex = 0;
        float invincibilityFramesDuration = 2000f;
        float hitStunDuration = 500f;
        private int maxHealth;

        public Link()
        {
            State = new InitialLinkState(this,null); //start the player in the right idle state, initial sprite is null, will be fixed during content loading in game1
            DestRect = new Rectangle(new Point(300, 300), new Point(64, 64));
            System.Diagnostics.Debug.WriteLine(DestRect);
            colorIndex = 0;
            //Set link's health and maxHealth
            Health = LinkConstants.linkHealth;
            maxHealth = Health;
        }

        public void Update(GameTime gameTime)
        {
            OldPosition = DestRect.Location;

            if (isDamaged)
            {

                damageTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if(invincibilityFramesDuration - damageTimer % damageFlashRate == 0)
                {
                    colorIndex++;
                    Sprite.Color = damageColors[colorIndex % damageColors.Length];
                }


                if (damageTimer % (damageFlashRate) > damageFlashRate * 2)
                {
                    colorIndex++;
                }
                if (damageTimer <= 50f)
                { //damage invincibility time
                    isDamaged = false;
                    Sprite.Color = Color.White;
                }
                else if (damageTimer < (invincibilityFramesDuration-hitStunDuration)) //hit stun duration
                {
                    canMove = true;
                }
                damageTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            }
            else
            {
                canMove = true;
                colorIndex = 0;
            }
            State.Update(gameTime);
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle tempRect = new Rectangle(DestRect.Location, new Point((int)(Sprite.SourceRect[Sprite.CurrentFrame].Width * Game1.gameScaleX), (int)(Sprite.SourceRect[Sprite.CurrentFrame].Height * Game1.gameScaleY)));
            
            Sprite.Draw(spriteBatch, tempRect);   //draw the player sprite
        }

        public void TakeDamage(int dmgAmount)
        {
            if (!isDamaged) {
                isDamaged = true;
                canMove = false;
                Sprite.Color = Color.Red;
                damageTimer = invincibilityFramesDuration;

                Health -= dmgAmount;
            }

            //Kill link if his health hits zero
            if(Health <= 0)
            {
                State = new DeadLinkState(this, Sprite);
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
        public void Reset()
        {
            //This may not work, since the state does not determine the sprite
            State = new InitialLinkState(this, Sprite); //start the player in the right idle state
            DestRect = new Rectangle(new Point(20, 20), DestRect.Size);

            colorIndex = 0;

            Sprite.Color = Color.White;
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