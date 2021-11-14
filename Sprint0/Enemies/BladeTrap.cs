using Microsoft.Xna.Framework;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public class BladeTrap : AbstractEnemy
    {
        ILink link;

        Point homePos;
        Point moveDir = Point.Zero;
        int attackTimer = 0;
        int returnTimer = 0;
        Rectangle xTargeting;
        Rectangle yTargeting;

        public BladeTrap(ILink gameLink, Point position) : base(EnemyType.BladeTrap, position, new Point(32, 32))
        {
            link = gameLink;
            homePos = position;

            xTargeting = new Rectangle(//Rectangle to cover all X coordinates this blade trap sees
                0,
                (int)homePos.Y,
                1000,
                (int)(EnemyConstants.stdEnemySize.Width * EnemyConstants.scaleY)
                );

            yTargeting = new Rectangle(//Rectangle to cover all Y coords this blade trap sees.
                (int)homePos.X,
                0,
                (int)(EnemyConstants.stdEnemySize.Width * EnemyConstants.scaleX),
                1000
            );
        }

        public override void Update(GameTime gameTime)
        {
            oldPosition = DestRect.Location;

            //Change positions if the movement vector is not zero.
            if (moveDir != Point.Zero)
            {
                if (attackTimer > 0)
                {//Move into the attack and decrement attackTimer
                    DestRect = new Rectangle(DestRect.Location + moveDir, DestRect.Size);
                    attackTimer -= gameTime.ElapsedGameTime.Milliseconds;
                }
                /*else if (returnTimer == EnemyConstants.horizBladeMoveTime * 2 || returnTimer == EnemyConstants.vertBladeMoveTime * 2)
                {//Set moveVector back towards home
                    returnTimer -= gameTime.ElapsedGameTime.Milliseconds;
                    moveVector = ReturnHome();
                }*/
                else if (returnTimer > 0)
                {//Move back towards home, and decrement returnTimer
                    moveDir = ReturnHome();
                    DestRect = new Rectangle(DestRect.Location + moveDir, DestRect.Size);
                    returnTimer -= gameTime.ElapsedGameTime.Milliseconds;
                }
                else
                {//Stop movement and reset the timers
                    moveDir = Point.Zero;
                    attackTimer = 0;
                    returnTimer = 0;
                }
            }
            else
            {
                //If moveVector is 0, try to attack
                moveDir = TryAttack();
            }
        }

        private Point TryAttack()
        {
            Rectangle linkRectangle = link.DestRect;


            if (Rectangle.Intersect(linkRectangle, xTargeting) != new Rectangle(0, 0, 0, 0))
            {
                //If link is within the Y dimensions of the blade trap, check if he's to the left or right.
                if (link.GetPosition().X < DestRect.X)
                {
                    moveDir = new Point(-EnemyConstants.bladeAttackSpeed, 0);
                    attackTimer = EnemyConstants.horizBladeMoveTime;
                    returnTimer = EnemyConstants.horizBladeMoveTime * 2;
                }
                else
                {
                    moveDir = new Point(EnemyConstants.bladeAttackSpeed, 0);
                    attackTimer = EnemyConstants.horizBladeMoveTime;
                    returnTimer = EnemyConstants.horizBladeMoveTime * 2;
                }

            }
            else if(Rectangle.Intersect(linkRectangle,yTargeting) != new Rectangle(0, 0, 0, 0))
            {
                //If link is within the X dimensions of the blade trap, check if he's above or below.
                if (link.GetPosition().Y < DestRect.Y)
                {
                    //Link is above, move upwards and set timers
                    moveDir = new Point(0, -EnemyConstants.bladeAttackSpeed);
                    attackTimer = EnemyConstants.vertBladeMoveTime;
                    returnTimer = EnemyConstants.vertBladeMoveTime * 2;
                }
                else
                {
                    //Link is below, move downwards and set timers.
                    moveDir = new Point(0, EnemyConstants.bladeAttackSpeed);
                    attackTimer = EnemyConstants.vertBladeMoveTime;
                    returnTimer = EnemyConstants.vertBladeMoveTime * 2;
                }
            }
            return moveDir;
        }

        private Point ReturnHome()
        {
            Point dist = homePos - DestRect.Location;
            int returnSpeed = returnTimer / 10;
            moveDir = new Point(dist.X / returnSpeed, dist.Y / returnSpeed); //TODO:Figure out an appropriate return speed.
            return moveDir;
        }
    }
}
