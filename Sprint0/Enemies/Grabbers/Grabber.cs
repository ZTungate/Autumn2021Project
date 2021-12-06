using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Enemies;
using Poggus.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public class Grabber : AbstractEnemy
    {
        const int RANDMOVE = 4;
        private bool vertical;
        private enum state { emerging, retracting, overSliding, underSliding };
        private state currState;
        private int stateTime;

        private Point velocity;

        public Grabber(Point pos) : base(EnemyType.Grabber, pos, EnemyConstants.stdEnemySize.Size)
        {
            Health = EnemyConstants.grabberHealth;
            currState = state.emerging;
            stateTime = EnemyConstants.grabberStateTime;
            velocity = new Point(0, 0);
        }
        public override void Update(GameTime gameTime)
        {
            oldPosition = DestRect.Location;
            if (StunTimer <= 0)
            {
                int lastFrame = Sprite.CurrentFrame;
                Sprite.Update(gameTime);

                stateTime -= gameTime.ElapsedGameTime.Milliseconds;

                if (stateTime <= 0) {
                    ChangeState();
                }
                else
                {
                    Point pos = GetPosition();
                    pos += velocity;
                    DestRect = new Rectangle(pos, DestRect.Size);

                }

                //Decrement the invincibility timer if there is time on it
                if (InvincibilityTimer > 0)
                {
                    InvincibilityTimer -= gameTime.ElapsedGameTime.Milliseconds;
                }
                ColliderRect = new Rectangle(DestRect.Location + new Point(4, (int)(DestRect.Height / 2f) - 4), new Point(DestRect.Width - 4, (int)(DestRect.Height / 2f)));

            }
            else if (StunTimer == EnemyConstants.grabberFlipTrigger)
            {
                //If given a specific stunTime, flip movement axis
                vertical = !vertical;
                StunTimer = 0;
            }
            else
            {
                StunTimer -= gameTime.ElapsedGameTime.Milliseconds;
            }
        }
        private void ChangeState()
        {
            switch (currState)
            {
                case state.emerging:
                    //Set the grabber's state to sliding across the surface, give it velocity to do so.
                    currState = state.overSliding;
                    stateTime = EnemyConstants.grabberStateTime;
                    velocity = new Point(EnemyConstants.grabberSlideVelocity, 0);
                    break;
                case state.overSliding:
                    //Set the grabber's state to retracting, and set its velocity for retraction.
                    currState = state.retracting;
                    stateTime = EnemyConstants.grabberStateTime;
                    velocity = new Point(0, -EnemyConstants.grabberEmergeVelocity);
                    break;
                case state.underSliding:
                    //Set teh grabber's state to emerging and set its velocity for emergence.
                    currState = state.emerging;
                    stateTime = EnemyConstants.grabberStateTime;
                    velocity = new Point(0, EnemyConstants.grabberEmergeVelocity);
                    break;
                case state.retracting:
                    //Set the grabber's velocity and state
                    currState = state.underSliding;
                    stateTime = EnemyConstants.grabberStateTime;
                    velocity = new Point(-EnemyConstants.grabberSlideVelocity, 0);
                    break;
            }
        }
    }
}
