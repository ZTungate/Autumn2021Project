using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Sprint2.Projectiles;
using static Sprint0.Projectiles.ProjectileConstants;
using Sprint2.Items;

namespace Sprint2.Player
{

    public class Link : ILink {

        //Game class contains a sprite factory, which creates each sprite with a source rectangle. this is saved in spriteBatch
        //spritebatch is passed down to the state in the player class (this file), which is sent to the state. The state actually draws the image.

        public ILinkState state { get; set; }
        public Rectangle DestRect { get; set; }
        public Point oldPosition { get; set; }
        public ISprite sprite { get; set; }
        public Color color { get; set; }
        public ProjectileFactory ProjectileFactory { get; set; }

        float damageTimer;
        Color[] damageColors = new Color[2] { Color.Red, Color.Blue };
        public float Timer = 0f;
        float damageFlashRate = 50f;
        public bool canMove = true;
        public bool isDamaged = false;
        int colorIndex = 0;
        float invincibilityFramesDuration = 2000f;
        float hitStunDuration = 500f;

        public Link()
        {
            state = new InitialLinkState(this,null); //start the player in the right idle state, initial sprite is null, will be fixed during content loading in game1
            DestRect = new Rectangle(new Point(300, 300), Point.Zero);
            colorIndex = 0;

            color = Color.White;
        }

        public void Update(GameTime gameTime)
        {
            oldPosition = DestRect.Location;

            if (isDamaged)
            {

                damageTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if(invincibilityFramesDuration - damageTimer % damageFlashRate == 0)
                {
                    colorIndex++;
                    color = damageColors[colorIndex % damageColors.Length];
                }


                if (damageTimer % (damageFlashRate) > damageFlashRate * 2)
                {
                    colorIndex++;
                }
                if (damageTimer <= 50f)
                { //damage invincibility time
                    isDamaged = false;
                    color = Color.White;
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
            state.Update(gameTime);
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, DestRect);   //draw the player sprite
        }

        public void takeDamage()
        {
            if (!isDamaged) {
                isDamaged = true;
                canMove = false;
                color = Color.Red;
                damageTimer = invincibilityFramesDuration;
            }
            /*state.takeDamage();*/
        }

        public void UseItem(ProjectileTypes item)
        {
            state.UseItem(item);
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
            state = new InitialLinkState(this, sprite); //start the player in the right idle state
            DestRect = new Rectangle(new Point(20, 20), DestRect.Size);

            colorIndex = 0;

            color = Color.White;
        }

        //Attacks

        public void SwordAttack()
        {
            state.SwordAttack();
        }

        public void PickUp(AbstractItem item)
        {
            state.PickUp(item);
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