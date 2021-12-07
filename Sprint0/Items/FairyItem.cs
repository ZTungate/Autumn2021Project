using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Poggus.Player;

namespace Poggus.Items
{
    public class FairyItem : AbstractItem
    {
        const int RANDMOVE = 4;
        const int MOVESPEED = 10;
        public FairyItem(Point pos) : base(ItemEnum.Fairy, pos, Point.Zero)
        {

        }

        public override void Update(GameTime gameTime)
        {
            //Update the sprite, check if the frame changed, and move if the frame changed.
            int lastFrame = sprite.CurrentFrame;
            this.sprite.Update(gameTime);
            if (lastFrame != sprite.CurrentFrame)
            {
                SetPosition(RandomMove());
            }
        }
        private Point RandomMove()
        {
            Point newPosition = rect.Location;

            Random rand = new Random();
            int i = rand.Next(RANDMOVE);

            if (i == 0)
            {
                newPosition.X += MOVESPEED;
            }
            else if (i == 1)
            {
                newPosition.Y += MOVESPEED;
            }
            else if (i == 2)
            {
                newPosition.X -= MOVESPEED;
            }
            else
            {
                newPosition.Y -= MOVESPEED;
            }
            return newPosition;
        }
    }
}
