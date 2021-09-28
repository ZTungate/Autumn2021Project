using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class Slime
    {
        public ISlimeState state;

        public ISprite mySprite = EnemySpriteFactory.Instance.CreateSlimeSprite();

        public Slime()
        {
            state = new BaseSlimeState(this);
        }

    }


    public class BaseSlimeState : ISlimeState
    {
        private Slime slime;
        private GameTime gameTime;

        private int interval = 40;
        private int timer = 0;

        public BaseSlimeState(Slime slime)
        {
            this.slime = slime;
            //skeleton.mySprite =; //TODO Get skeleton sprite from game1's factory.
        }

        public void Update()
        {
            slime.mySprite.Update(gameTime);

            //Timer to prevent from moving too fast, should unify with the timer in sprite.Update();
            if (timer < interval)
            {
                timer += 5;
            }
            else
            {
                timer = 0;
                slime.mySprite.Position = randomMove();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw the sprite in the provided spritebatch
            spriteBatch.Draw(
                slime.mySprite.Texture, //Use the sprite's texture
                                           //Use position stored in mySprite
                new Rectangle((int)slime.mySprite.Position.X, (int)slime.mySprite.Position.Y, slime.mySprite.SourceRect[slime.mySprite.CurrentFrame].Width, slime.mySprite.SourceRect[slime.mySprite.CurrentFrame].Height),
                //Get the relevant sourceRect from the current frome
                slime.mySprite.SourceRect[slime.mySprite.CurrentFrame],
                //Paint the skeleton white (don't tint)
                Color.White);
        }

        public Vector2 randomMove()
        {
            Vector2 pos = slime.mySprite.Position;

            //Get a random number from 0-3
            Random rand = new Random();
            int i = rand.Next(4);

            if (i == 0)
            {
                pos.X += 5;
            }
            else if (i == 1)
            {
                pos.Y += 5;
            }
            else if (i == 2)
            {
                pos.X -= 5;
            }
            else
            {
                pos.Y -= 5;
            }
            return pos;

        }

    }

}
