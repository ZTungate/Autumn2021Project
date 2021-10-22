using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{

    public class DamagedLink: ILink{
        
        //Game class contains a sprite factory, which creates each sprite with a source rectangle. this is saved in spriteBatch
        //spritebatch is passed down to the state in the player class (this file), which is sent to the state. The state actually draws the image.

        public ILinkState state { get; set; }
        public Vector2 position { get; set; }
        public ISprite sprite { get; set; }
        public Color color { get; set; }

        Color[] damageColors = new Color[2] { Color.Red, Color.Blue };
        int colorIndex = 0;

        float invincibilityFramesDuration = 2000f;
        float hitStunDuration = 500f;
        float damageFlashRate = 50f;
        public bool canMove { get; set; }

        public Boolean canAttack { get; set; }

        public direction facing { get; set; }

        float timer = 2000f;

        Game1 game;
        ILink decoratedLink;

        public DamagedLink(ILink decoratedLink, Game1 game)
        {
            this.decoratedLink = decoratedLink;
            this.game = game;
            this.state = decoratedLink.state;
            this.sprite = decoratedLink.sprite;
            canAttack = true;
            canMove = true;
        }

        public void Update(GameTime gameTime)
        {

                timer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (2000f - timer % damageFlashRate == 0)
                {
                    colorIndex++;
                    color = damageColors[colorIndex % damageColors.Length];
                }


                if (timer % (damageFlashRate) > damageFlashRate * 2)
                {
                    colorIndex++;
                }
                if (timer <= 50f)
                { //damage invincibility time
                    /*isDamaged = false;*/ //remove decorator instead
                    color = Color.White;
                }
                else if (timer < (invincibilityFramesDuration - hitStunDuration)) //hit stun duration
                {
                    canMove = true;
                }
                timer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            
                colorIndex = 0;


            timer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if  (timer <= 0)
            {
                RemoveDecorator();
    }

    decoratedLink.Update(gameTime);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            decoratedLink.Draw(spriteBatch);
        }

        public void move(Vector2 moveDirection)
        {
                decoratedLink.canAttack = this.canAttack;
            decoratedLink.canMove = this.canMove;
                decoratedLink.move(moveDirection);
        }

        public void takeDamage()
        {
            //cannot take damage here
        }

        void RemoveDecorator()
        {
            game.link = decoratedLink;
        }

        public void SwordAttack()
        {
            decoratedLink.canAttack = this.canAttack;
            decoratedLink.SwordAttack();
        }

        public void RegBoomerangAttack()
        {
            decoratedLink.canAttack = this.canAttack;
            decoratedLink.RegBoomerangAttack();
        }

        public void BlueBoomerangAttack()
        {
            decoratedLink.canAttack = this.canAttack;
            decoratedLink.BlueBoomerangAttack();
        }

        public void RegArrowAttack()
        {
            decoratedLink.canAttack = this.canAttack;
            decoratedLink.RegArrowAttack();
        }

        public void BlueArrowAttack()
        {
            decoratedLink.canAttack = this.canAttack;
            decoratedLink.BlueArrowAttack();
        }

        public void BombAttack()
        {
            decoratedLink.canAttack = this.canAttack;
            decoratedLink.BombAttack();
        }

        public void FireAttack()
        {
            decoratedLink.canAttack = this.canAttack;
            decoratedLink.FireAttack();
        }



        /*        public void moveUp(float speed)
                {
                    decoratedLink.moveUp(speed);
                }

                public void moveRight(float speed)
                {
                    decoratedLink.moveRight(speed);
                }

                public void moveLeft(float speed)
                {
                    decoratedLink.moveLeft(speed);
                }

                public void moveDown(float speed)
                {
                    decoratedLink.moveDown(speed);
                }*/
    }
}