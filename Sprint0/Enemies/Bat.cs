using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class Bat
    {
        public IBatState state;

        public ISprite mySprite = EnemySpriteFactory.Instance.CreateBatSprite();

        public Bat()
        {
            state = new BaseBatState(this);
        }

    }


    public class BaseBatState : IBatState
    {
        private Bat bat;

        public BaseBatState(Bat bat)
        {
            this.bat = bat;
        }

        public void Update(GameTime gameTime)
        {
            int lastFrame = bat.mySprite.CurrentFrame;
            bat.mySprite.Update(gameTime);

            //Move the bat if the animation frame changed
            if (lastFrame != bat.mySprite.CurrentFrame)
            {
                bat.mySprite.Position = BatRandomMove();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw the sprite in the provided spritebatch
            spriteBatch.Draw(
                bat.mySprite.Texture, //Use the sprite's texture
                //Use position stored in mySprite
                new Rectangle((int)bat.mySprite.Position.X, (int)bat.mySprite.Position.Y, bat.mySprite.SourceRect[bat.mySprite.CurrentFrame].Width, bat.mySprite.SourceRect[bat.mySprite.CurrentFrame].Height),
                //Get the relevant sourceRect from the current frome
                bat.mySprite.SourceRect[bat.mySprite.CurrentFrame],
                //Paint the skeleton white (don't tint)
                Color.White);
        }
        //Placeholder movement method, will require reworking when actual level exists.
        public Vector2 BatRandomMove()
        {
            Vector2 pos = bat.mySprite.Position;

            //Get a random number from 0-3
            Random rand = new Random();
            int i = rand.Next(4);

            if (i == 0)
            {
                //Move right/Up if i = 0
                pos.X += 3;
                pos.Y += 3;
            }
            else if (i == 1)
            {
                //Move right/down if i = 1
                pos.X += 3;
                pos.Y -= 3;
            }
            else if (i == 2)
            {
                //Move left/up if i = 2
                pos.X -= 3;
                pos.Y += 3;
            }
            else if (i==3)
            {
                //Move left/down if i = 3
                pos.X -= 3;
                pos.Y -= 3;
            }
            //Return the modified position.
            return pos;

        }

    }

}
