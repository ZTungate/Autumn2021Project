using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{

    public class Link: ILink{
        
        //Game class contains a sprite factory, which creates each sprite with a source rectangle. this is saved in spriteBatch
        //spritebatch is passed down to the state in the player class (this file), which is sent to the state. The state actually draws the image.

        public IPlayerState state { get; set; }
        public Vector2 position { get; set; }
        public ISprite sprite { get; set; } 

        public float Timer = 0f;
        float damageFlashRate = 50f;
        public bool canMove = true;
        public bool isDamaged = false;
        public Color[] colors;
        int colorIndex = 0;

        public Link()
        {
            state = new RightIdleState(); //start the player in the right idle state
            position = new Vector2(20,20);  //Link's initial position
            
            colors = new Color[2];
            colors[0] = Color.White;
            colors[1] = Color.Red;
        }

        public void Update(GameTime gameTime)
        {
            if (isDamaged)
            {
                if (Timer % (damageFlashRate) > damageFlashRate * 2)
                {
                    colorIndex++;
                }
                if (Timer > 500f)
                { //damage invincibility time
                    isDamaged = false;
                    Timer = 0;
                } 
                else if (Timer > 250f) //hit stun duration
                {
                    canMove = true;
                }
                    Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                
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
            canMove = false;
            isDamaged = true;
            Timer = 0;
            
        }

        public void moveUp(float speed)
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
        }
    }
}