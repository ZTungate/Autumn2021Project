using Microsoft.Xna.Framework;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class BladeTrap : IEnemy
    {
        Vector2 currPos;
        ISprite mySprite;
        IEnemyState currState;
        ILink link;
        Vector2 homePos;
        Vector2 moveVector = new Vector2(0,0);
        int attackTimer = 0;
        int returnTimer = 0;
        direction attackDirection;
        Rectangle xTargeting;
        Rectangle yTargeting;

        public ISprite Sprite
        {
            get => mySprite;
            set => mySprite = value;
        }
        public EnemyTypes Type => EnemyTypes.BladeTrap;

        public Vector2 Position
        { get => currPos;
          set => currPos = value;
        }
        public Vector2 oldPosition { get; set; }

        public IEnemyState State 
        { 
            get => currState;
            set => currState = value;
        }

        public BladeTrap(ILink gameLink, Vector2 originPos)
        {
            link = gameLink;
            homePos = originPos;
            currPos = originPos;

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

        public void Update(GameTime gameTime)
        {

            oldPosition = currPos;

            //Change positions if the movement vector is not zero.
            if (!moveVector.Equals(new Vector2(0,0)))
            {
                if (attackTimer > 0)
                {//Move into the attack and decrement attackTimer
                    currPos += moveVector;
                    attackTimer -= gameTime.ElapsedGameTime.Milliseconds;
                }
                /*else if (returnTimer == EnemyConstants.horizBladeMoveTime * 2 || returnTimer == EnemyConstants.vertBladeMoveTime * 2)
                {//Set moveVector back towards home
                    returnTimer -= gameTime.ElapsedGameTime.Milliseconds;
                    moveVector = ReturnHome();
                }*/
                else if (returnTimer > 0)
                {//Move back towards home, and decrement returnTimer
                    moveVector = ReturnHome();
                    currPos += moveVector;
                    returnTimer -= gameTime.ElapsedGameTime.Milliseconds;
                }
                else
                {//Stop movement and reset the timers
                    moveVector = new Vector2(0, 0);
                    attackTimer = 0;
                    returnTimer = 0;
                }
            }
            else
            {
                //If moveVector is 0, try to attack
                moveVector = TryAttack();
            }
            mySprite.Position = currPos;
        }

        private Vector2 TryAttack()
        {
            Rectangle linkRectangle = new Rectangle((int)link.position.X, (int)link.position.Y, 32, 32);


            if (Rectangle.Intersect(linkRectangle, xTargeting) != new Rectangle(0, 0, 0, 0))
            {
                //If link is within the Y dimensions of the blade trap, check if he's to the left or right.
                if (link.position.X < currPos.X)
                {
                    moveVector = new Vector2(-EnemyConstants.bladeAttackSpeed, 0);
                    attackTimer = EnemyConstants.horizBladeMoveTime;
                    returnTimer = EnemyConstants.horizBladeMoveTime * 2;
                    attackDirection = direction.left;
                }
                else
                {
                    moveVector = new Vector2(EnemyConstants.bladeAttackSpeed, 0);
                    attackTimer = EnemyConstants.horizBladeMoveTime;
                    returnTimer = EnemyConstants.horizBladeMoveTime * 2;
                    attackDirection = direction.right;
                }

            }
            else if(Rectangle.Intersect(linkRectangle,yTargeting) != new Rectangle(0, 0, 0, 0))
            {
                //If link is within the X dimensions of the blade trap, check if he's above or below.
                if (link.position.Y < currPos.Y)
                {
                    //Link is above, move upwards and set timers
                    moveVector = new Vector2(0, -EnemyConstants.bladeAttackSpeed);
                    attackTimer = EnemyConstants.vertBladeMoveTime;
                    returnTimer = EnemyConstants.vertBladeMoveTime * 2;
                    attackDirection = direction.up;
                }
                else
                {
                    //Link is below, move downwards and set timers.
                    moveVector = new Vector2(0, EnemyConstants.bladeAttackSpeed);
                    attackTimer = EnemyConstants.vertBladeMoveTime;
                    returnTimer = EnemyConstants.vertBladeMoveTime * 2;
                    attackDirection = direction.down;
                }
            }
            return moveVector;
        }

        private Vector2 ReturnHome()
        {
            Vector2 dist = homePos - currPos;
            moveVector = dist / (returnTimer/10); //TODO:Figure out an appropriate return speed.
            return moveVector;
        }
    }
}
