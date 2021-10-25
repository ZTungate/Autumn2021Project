using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Enemies;
using Sprint2.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class Skeleton : IEnemy
    {
        //ISprite for the enemy
        ISprite mySprite;
        //Position vector
        Vector2 pos;
        //State for this enemy (unused for now for this type)
        IEnemyState currState;
        IEnemyState IEnemy.State
        {
            //For this enemy type, this should not be used yet.
            get => currState;
            set => currState = value;
        }
        Vector2 IEnemy.Position
        {
            get => pos;
            set => pos = value;
        }
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
                pos = RandomMove();
                mySprite.Position = pos;
            }
        }
        public Skeleton()
        {
            //Assign an arbitrary starting positon for the skeleton.
            pos = new Vector2(500, 300);
        }

        public Vector2 RandomMove()
        {
            Vector2 newPosition = this.pos;

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
