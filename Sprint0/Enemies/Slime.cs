using Microsoft.Xna.Framework;
using Sprint0.Helpers;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class Slime : IEnemy
    {
        //Timers for updating sprite without moving
        private int interval = 40;
        private int timer = 0;

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
                mySprite.Position = SlimeRandomMove();
            }
        }
        public Slime()
        {
            //Nothing special about the slime object itself, no implementation required
        }

        //Placeholder movement method, will require reworking when actual level exists.
        public Vector2 SlimeRandomMove()
        {
            Vector2 pos = mySprite.Position;

            //Get a random number from 0-3
            Random rand = new Random();
            int i = rand.Next(5);

            if (i == 0)
            {
                //Move right if i = 0
                pos.X += 5;
            }
            else if (i == 1)
            {
                //Move up if i = 1
                pos.Y += 5;
            }
            else if (i == 2)
            {
                //Move left if i = 2
                pos.X -= 5;
            }
            else if (i == 3)
            {
                //Move down if i = 3
                pos.Y -= 5;
            }
            //If i = 4, do nothing, the slime can stand still.
            return pos;
        }
    }
}