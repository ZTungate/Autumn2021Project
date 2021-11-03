﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Enemies;
using Sprint2.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class Grabber : AbstractEnemy
    {
        public override void Update(GameTime gameTime)
        {
            //Get the number for the last frame
            int lastFrame = Sprite.CurrentFrame;
            oldPosition = DestRect.Location;

            //Update the sprite
            Sprite.Update(gameTime);

            //Move the grabber if the animation frame changed
            if (lastFrame != Sprite.CurrentFrame)
            {
                DestRect = new Rectangle(RandomMove(), DestRect.Size);
            }
        }
        public Grabber(Point pos) : base(pos, Point.Zero)
        {

        }

        public Point RandomMove()
        {
            Point newPosition = this.DestRect.Location;

            //Get a random number from 0-3
            Random rand = new Random();
            int i = rand.Next(4);

            if (i == 0)
            {
                newPosition.X += EnemyConstants.grabberMoveSpeed;
            }
            else if (i == 1)
            {
                newPosition.Y += EnemyConstants.grabberMoveSpeed;
            }
            else if (i == 2)
            {
                newPosition.X -= EnemyConstants.grabberMoveSpeed;
            }
            else
            {
                newPosition.Y -= EnemyConstants.grabberMoveSpeed;
            }
            return newPosition;
        }

    }
}
