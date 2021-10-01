using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class OldBat
    {
        public IBatState bat;

        public ISprite mySprite;

        public OldBat()
        {
           bat = new BaseBatState(this);
        }

    }


    public class BaseBatState : IBatState
    {
        private OldBat bat;

        public BaseBatState(OldBat bat)
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
