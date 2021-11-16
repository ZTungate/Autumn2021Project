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
        int throwDelay = EnemyConstants.throwerAttackDelay;
        const int RANDMOVE = 20;
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
            if (StunTimer <= 0)
            {
                int lastFrame = Sprite.CurrentFrame;

                oldPosition = DestRect.Location;
                Sprite.Update(gameTime);

                //Try to move the thrower
                TryRandomMove(lastFrame);

                wait -= gameTime.ElapsedGameTime.Milliseconds;
                if (throwDelay <= 0)
                {
                    //Attack and reset the delays
                    Attack();
                    wait = ProjectileConstants.boomerangLife; 
                    throwDelay = EnemyConstants.throwerAttackDelay;
                }
                else
                {
                    throwDelay -= gameTime.ElapsedGameTime.Milliseconds;
                }
            }
            else
            {
                //If stunned, decrement stun timer
                StunTimer -= gameTime.ElapsedGameTime.Milliseconds;
            }
        }

        private void TryRandomMove(int lastFrame)
        {
            //Move only if not waiting and the sprite frame changed.
            if (wait <= 0 && lastFrame != Sprite.CurrentFrame)
            {
                //Get a random number from 0 to 19
                Random rand = new Random();
                int value = rand.Next(RANDMOVE);

                //Change directions or move based on the random number
                if (value == 0)
                {
                    State.TurnUp();
                }
                else if (value == 1)
                {
                    State.TurnDown();
                }
                else if (value == 2)
                {
                    State.TurnRight();
                }
                else if (value == 3)
                {
                    State.TurnLeft();
                }
                else
                {
                    State.MoveForward();
                }
            }
        }
        private void Attack()
        {
            //Create a new boomerang moving the direction given at standard boomerang speed.
            projectiles.NewBoomerang(DestRect.Location, State.AttackDirection() * ProjectileConstants.RegBoomerangVelocity);
        }


    }
}
