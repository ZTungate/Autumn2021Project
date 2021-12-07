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
        private enum state { RightSlide, LeftSlide, UpSlide, DownSlide };
        private state currState;
        private int stateTime;

        private Point velocity;


        public Grabber(Point pos) : base(EnemyType.Grabber, pos, EnemyConstants.stdEnemySize.Size)
        {
            Health = EnemyConstants.grabberHealth;
            currState = state.RightSlide;
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
            //Set state time and delay the grabber's movement start.
            stateTime = EnemyConstants.grabberStateTime;
            RandomDelay();
            switch (currState)
            {
                case state.RightSlide:
                    //Set the grabber's state to sliding across the surface, give it velocity to do so.
                    currState = state.UpSlide;
                    velocity = new Point(EnemyConstants.grabberSlideVelocity, 0);//Move to the right
                    break;
                case state.UpSlide:
                    //Set the grabber's state to retracting, and set its velocity for retraction.
                    currState = state.LeftSlide;
                    velocity = new Point(0, -EnemyConstants.grabberEmergeVelocity);//Move up
                    break;
                case state.DownSlide:
                    //Set teh grabber's state to emerging and set its velocity for emergence.
                    currState = state.RightSlide;
                    velocity = new Point(0, EnemyConstants.grabberEmergeVelocity);//Move down
                    break;
                case state.LeftSlide:
                    //Set the grabber's velocity and state
                    currState = state.DownSlide;
                    velocity = new Point(-EnemyConstants.grabberSlideVelocity, 0);//Move Left
                    break;
            }
        }

        //Stuns the grabber breifly to randomize their movement.
        private void RandomDelay()
        {
            Random r = new Random();
            StunTimer = r.Next(EnemyConstants.grabberMaxDelay);
        }

        public void SetStartingState(Point dir)
        {
            if (dir == new Point(0, -1))//Up
            {
                currState = state.UpSlide;
            }
            else if (dir == new Point(0, 1))//Down
            {
                currState = state.DownSlide;
            }
            else if (dir == new Point(-1, 0))//Left
            {
                currState = state.LeftSlide;

            }
            else//Right
            {
                currState = state.RightSlide;
            }
        }
    }
}
