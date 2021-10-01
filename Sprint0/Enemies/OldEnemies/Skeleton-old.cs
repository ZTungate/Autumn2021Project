using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class oldSkeleton 
    {
        public ISkeletonState skeleton;

        public ISprite mySprite;

        public oldSkeleton()
        {
            skeleton = new SkeletonType(this);
        }

    }


    public class SkeletonType : ISkeletonState
    {
        private oldSkeleton skeleton;

        public SkeletonType(oldSkeleton skeleton)
        {
            this.skeleton = skeleton;
        }

        public void Update(GameTime gameTime)
        {
            int lastFrame = skeleton.mySprite.CurrentFrame;
            skeleton.mySprite.Update(gameTime);

            //Move the skeleton if the animation frame changed
            if (lastFrame != skeleton.mySprite.CurrentFrame)
            {
                skeleton.mySprite.Position = RandomMove();
            }
        }

        public Vector2 RandomMove()
        {
            Vector2 pos = skeleton.mySprite.Position;

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
            else if (i== 2)
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
