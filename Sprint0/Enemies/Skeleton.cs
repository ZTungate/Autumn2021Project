using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Enemies;
using Poggus.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public class Skeleton : AbstractEnemy
    {
        public Skeleton(Point pos) : base(pos, Point.Zero)
        {
            
        }
        public override void Update(GameTime gameTime)
        {
            oldPosition = DestRect.Location;

            //Get the number for the last frame
            int lastFrame = Sprite.CurrentFrame;
            //Update the sprite
            Sprite.Update(gameTime);

            //Move the skeleton if the animation frame changed
            if (lastFrame != Sprite.CurrentFrame)
            {
                DestRect = new Rectangle(RandomMove(), DestRect.Size);
            }
        }
        public Point RandomMove()
        {
            Point newPosition = DestRect.Location;

            //Get a random number from 0-3
            Random rand = new Random();
            int i = rand.Next(4);

            if (i == 0)
            {
                newPosition.X += EnemyConstants.skeletonMoveSpeed;
            }
            else if (i == 1)
            {
                newPosition.Y += EnemyConstants.skeletonMoveSpeed;
            }
            else if (i == 2)
            {
                newPosition.X -= EnemyConstants.skeletonMoveSpeed;
            }
            else
            {
                newPosition.Y -= EnemyConstants.skeletonMoveSpeed;
            }
            return newPosition;

        }
    }
}
