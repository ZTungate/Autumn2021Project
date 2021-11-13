using Microsoft.Xna.Framework;
using Poggus.Projectiles;
using Poggus;
using System;
using System.Collections.Generic;
using Poggus.Enemies.BoomerangThrowerStates;
using System.Text;

namespace Poggus.Enemies
{
    public class Thrower : AbstractEnemy
    {
        ProjectileFactory projectiles;
        int wait = 0;
        int throwDelay = 4000;
        public Thrower(Point pos) : base(EnemyType.Thrower, pos, new Point(32, 32))
        {
            //Default a new thrower as a left thrower
            State = new ThrowerState(new Point(0, 1), Sprite, this);
            //Assign an arbitrary starting positon for the thrower
            //Pass the projectile handler in
            projectiles = ProjectileFactory.Instance;
            Health = EnemyConstants.throwerHealth;
        }

        public override void Update(GameTime gameTime)
        {
            int lastFrame = Sprite.CurrentFrame;

            oldPosition = DestRect.Location;
            Sprite.Update(gameTime);

            //Only update the sprite and movement if we are not waiting for the boomerang to return.
            if (wait <= 0)
            {
                if (lastFrame != Sprite.CurrentFrame)
                {
                    RandomMove();
                }
            }
            wait -= gameTime.ElapsedGameTime.Milliseconds;
            if (throwDelay <= 0)
            {
                Attack();
                wait = 3000; //Set the thrower to wait 3 seconds (the life of a boomerang)
                throwDelay = 4000;//Reset the delay
            }
            else
            {
                throwDelay -= gameTime.ElapsedGameTime.Milliseconds;
            }
        }

        private void RandomMove()
        {
            //Get a random number from 0 to 9
            Random rand = new Random();
            int value = rand.Next(10);

            //Change directions or move based on the random number
            if(value == 0)
            {
                State.TurnUp();
            }
            else if(value == 1)
            {
                State.TurnDown();
            }
            else if(value == 2)
            {
                State.TurnRight();
            }
            else if(value == 3)
            {
                State.TurnLeft();
            }
            else 
            {
                State.MoveForward();
            }

        }
        private void Attack()
        {
            //Create a new boomerang moving the direction given at 3 pixels per tick.
            projectiles.NewBoomerang(DestRect.Location, (3 * State.AttackDirection().ToVector2()).ToPoint());
        }


    }
}
