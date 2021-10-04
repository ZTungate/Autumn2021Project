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

        float timer = 1000f;


        Game1 game;
        ILink decoratedLink;

        public DamagedLink(ILink decoratedLink, Game1 game)
        {
            this.decoratedLink = decoratedLink;
            this.game = game;
        }

        public void Update(GameTime gameTime)
        {

            timer-= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer <= 0)
            {
                RemoveDecorator();
            }

            decoratedLink.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            decoratedLink.Draw(spriteBatch);
        }

        public void takeDamage()
        {
            //cannot take damage here
        }

        void RemoveDecorator()
        {
            game.link = decoratedLink;
        }

        public void move(Vector2 moveDirection)
        {
            decoratedLink.move(moveDirection);
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