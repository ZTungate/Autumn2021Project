using Microsoft.Xna.Framework;
using Poggus.Collisions;
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
        private Direction lastAttack;
        private Boolean attacking;

        public BladeTrap(Point position) : base(EnemyType.BladeTrap, position, EnemyConstants.bladeTrapSize)
        {
            link = Game1.instance.link;
            homePos = position;
            Health = EnemyConstants.bladeTrapHealth;
            
        }

        public override void Update(GameTime gameTime)
        {
            oldPosition = DestRect.Location;

            //Change positions if the movement vector is not zero.
            if (attacking)
            {
                if (attackTimer > 0)
                {//Move into the attack and decrement attackTimer
                    DestRect = new Rectangle(DestRect.Location + moveDir, DestRect.Size);
                    attackTimer -= gameTime.ElapsedGameTime.Milliseconds;
                }
                else if (returnTimer > 0)
                {//Move back towards home, and decrement returnTimer
                    moveDir = ReturnHome();
                    DestRect = new Rectangle(DestRect.Location + moveDir, DestRect.Size);
                    returnTimer -= gameTime.ElapsedGameTime.Milliseconds;
                }
                else
                {//Stop movement and reset the timers
                    moveDir = Point.Zero;
                    DestRect = new Rectangle(homePos, DestRect.Size);
                    attackTimer = 0;
                    returnTimer = 0;
                    attacking = false;
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
            homePos = DestRect.Location;
            Rectangle linkRectangle = link.DestRect;
            xTargeting = new Rectangle(//Rectangle to cover all X coordinates this blade trap sees
                (int)DestRect.X - EnemyConstants.roomLength,
                (int)DestRect.Y,
                EnemyConstants.roomLength * 2,
                (int)EnemyConstants.stdEnemySize.Width
                );

            yTargeting = new Rectangle(//Rectangle to cover all Y coords this blade trap sees.
                (int)DestRect.X,
                (int)DestRect.Y - EnemyConstants.roomHeight,
                (int)EnemyConstants.stdEnemySize.Width,
                EnemyConstants.roomHeight * 2
            ) ;
            
            if (Rectangle.Intersect(linkRectangle, xTargeting) != new Rectangle(0, 0, 0, 0))
            {
                //If link is within the Y dimensions of the blade trap, check if he's to the left or right.
                if (link.GetPosition().X < DestRect.X)
                {
                    //Link is to the left
                    moveDir = new Point(-EnemyConstants.bladeAttackSpeedHoriz, 0);
                    lastAttack = Direction.left;
                }
                else
                {
                    //Link is to the right
                    moveDir = new Point(EnemyConstants.bladeAttackSpeedHoriz, 0);
                    lastAttack = Direction.right;
                }
                attackTimer = EnemyConstants.horizBladeAttackTime;
                returnTimer = EnemyConstants.horizBladeReturnTime;
                attacking = true;
            }
            else if(Rectangle.Intersect(linkRectangle,yTargeting) != new Rectangle(0, 0, 0, 0))
            {
                //If link is within the X dimensions of the blade trap, check if he's above or below.
                if (link.GetPosition().Y < DestRect.Y)
                {
                    //Link is above, move upwards
                    moveDir = new Point(0, -EnemyConstants.bladeAttackSpeedVert);
                    lastAttack = Direction.up;
                }
                else
                {
                    //Link is below, move downwards
                    moveDir = new Point(0, EnemyConstants.bladeAttackSpeedVert);
                    lastAttack = Direction.down;
                }
                //Set movement timers and the attack direction boolean.
                attackTimer = EnemyConstants.vertBladeAttackTime;
                returnTimer = EnemyConstants.vertBladeReturnTime;
                attacking = true;
            }
            return moveDir;
        }

        private Point ReturnHome()
        {
            switch (lastAttack)
            {
                //Make the blade trap return in the oppisite direction it attacked.
                case Direction.up:
                    moveDir = new Point(0, EnemyConstants.bladeReturnSpeedVert);
                    break;
                case Direction.down:
                    moveDir = new Point(0, -EnemyConstants.bladeReturnSpeedVert);
                    break;
                case Direction.left:
                    moveDir = new Point(EnemyConstants.bladeReturnSpeedHoriz, 0);
                    break;
                case Direction.right:
                    moveDir = new Point(-EnemyConstants.bladeReturnSpeedHoriz, 0);
                    break;
            }
            return moveDir;
        }

        public override void TakeDamage(int damageAmount, ColDirections damageDirection)
        {
            //Blade traps do not take damage.
        }
    }
}
