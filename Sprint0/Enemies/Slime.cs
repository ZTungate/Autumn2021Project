using Microsoft.Xna.Framework;
using Sprint3.Helpers;
using Sprint3;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Enemies
{
    public class Slime : IEnemy
    {
        //Timers for updating sprite without moving
        private int interval = 40;
        private int timer = 0;

        //Position of the bat.
        Vector2 pos;
        //State of the bat (not used yet for this enemy type)
        IEnemyState state;
        
        //ISprite for the enemy
        ISprite mySprite;
        public ISprite Sprite
        {
            //Allow sprite to be set by the spriteFactory, and return mySprite when requested.
            get => mySprite;
            set => mySprite = value;
        }
        public Vector2 Position
        {
            get => pos;
            set => pos = value;
        }
        public IEnemyState State
        {
            //This will not be used until damage states are added.
            get => state;
            set => state = value;
        }
        public EnemyTypes Type
        {
            //Return Slime if type is ever asked for.
            get => EnemyTypes.Slime;
        }

        public void Update(GameTime gameTime)
        {
            mySprite.Update(gameTime);

            //Timer to prevent from moving too fast, should unify with the timer in sprite.Update();
            if (timer < interval)
            {
                timer += 5;
            }
            else
            {
                timer = 0;
                pos = SlimeRandomMove();
                mySprite.Position = pos;
            }
        }
        public Slime()
        {
            //Assign an arbitrary starting positon for the slime.
            pos = new Vector2(500, 300);
        }

        //Placeholder movement method, will require reworking when actual level exists.
        public Vector2 SlimeRandomMove()
        {
            //Get the current position of the slime
            Vector2 newPosition = pos;

            //Get a random number from 0-3
            Random rand = new Random();
            int i = rand.Next(5);

            if (i == 0)
            {
                //Move right if i = 0
                newPosition.X += 5;
            }
            else if (i == 1)
            {
                //Move up if i = 1
                newPosition.Y += 5;
            }
            else if (i == 2)
            {
                //Move left if i = 2
                newPosition.X -= 5;
            }
            else if (i == 3)
            {
                //Move down if i = 3
                newPosition.Y -= 5;
            }
            //If i = 4, do nothing, the slime can stand still.
            return newPosition;
        }
    }
}