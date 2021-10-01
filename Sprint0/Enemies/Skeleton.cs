using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies;
using Sprint0.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class Skeleton : IEnemy
    {
        //ISprite for the enemy
        ISprite mySprite;
        public ISprite Sprite
        {
            //Allow sprite to be set by the spriteFactory, and return mySprite when requested.
            get => mySprite;
            set => mySprite = value;
        }

        public EnemyTypes Type
        {
            //Return Dragon if type is ever asked for.
            get => EnemyTypes.Skeleton;
        }

        public void Update(GameTime gameTime)
        {
            //Get the number for the last frame
            int lastFrame = mySprite.CurrentFrame;
            //Update the sprite
            mySprite.Update(gameTime);

            //Move the skeleton if the animation frame changed
            if (lastFrame != mySprite.CurrentFrame)
            {
                 mySprite.Position = RandomMove();
            }
        }
        public Skeleton()
        {
            //Nothing special about the dragon object itself, no implementation required
        }

        public Vector2 RandomMove()
        {
            Vector2 pos = mySprite.Position;

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
