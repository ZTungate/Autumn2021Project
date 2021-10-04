using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{

    public class Link : ILink {

        //Game class contains a sprite factory, which creates each sprite with a source rectangle. this is saved in spriteBatch
        //spritebatch is passed down to the state in the player class (this file), which is sent to the state. The state actually draws the image.

        public ILinkState state { get; set; }
        public Vector2 position { get; set; }
        public ISprite sprite { get; set; }
        public Color color { get; set; }

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
            state = new RightState(this); //start the player in the right idle state
            position = new Vector2(20, 20);  //Link's initial position


            colorIndex = 0;

            color = Color.White;

        }

        public void Update(GameTime gameTime)
        {
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
            sprite.Update(gameTime);
            /*playerState.Update();*/
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);   //draw the player sprite
            /*playerState.Draw(SpriteBatch);*/
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

        public void useItem(Game1 game)
        {
            state.useItem(game);
        }

        public void move(Vector2 moveDirection)
        {
            if (canMove) 
            {
                position += moveDirection;
            }   
        }
        /*        public void moveUp(float speed)
                {
                    position += new Vector2(0, -speed);
                }

                public void moveRight(float speed)
                {
                    position += new Vector2(speed, 0);
                }

                public void moveLeft(float speed)
                {
                    position += new Vector2(-speed, 0);
                }

                public void moveDown(float speed)
                {
                    position += new Vector2(0, speed);
                }*/
        public void Reset()
        {
            //This may not work, since the state does not determine the sprite
            state = new RightIdleState(); //start the player in the right idle state
            position = new Vector2(20, 20);  //Link's initial position

            colorIndex = 0;

            color = Color.White;
        }
    }
    
}