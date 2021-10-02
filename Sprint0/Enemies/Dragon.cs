using Microsoft.Xna.Framework;
using Sprint0.Helpers;
using Sprint2;
using Sprint2.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class Dragon : IEnemy
    {
        //ISprite for the enemy
        ISprite mySprite;

        //Position of the bat.
        Vector2 pos;
        //State of the dragon (not used yet for this enemy type)
        IEnemyState state;

        //Timers for updating sprite without moving
        private int interval = 120;
        private int timer = 0;
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
            //Return Dragon if type is ever asked for.
            get => EnemyTypes.Dragon;
        }

        public void Update(GameTime gameTime)
        {
            //Update the sprite
            mySprite.Update(gameTime);
            //Timer to prevent from moving too fast, should unify with the timer in sprite.Update();
            if (timer < interval)
            {
                timer += gameTime.ElapsedGameTime.Milliseconds;
            }
            else
            {
                timer = 0;
                pos = DragonMove();
                mySprite.Position = pos;
            }
        }
        public Dragon()
        { 
            //Assign an arbitrary starting positon for the bat.
            pos = new Vector2(500, 300);
        }

        public Vector2 DragonMove()
        {
            Random rand = new Random();
            Vector2 newPosition = pos;
            int val = rand.Next(3);

            if (val == 0)
            {
                newPosition.X += 5;
            }
            else if (val == 1)
            {
                newPosition.X -= 5;
            }
                return newPosition;
            
        }
    }
}
