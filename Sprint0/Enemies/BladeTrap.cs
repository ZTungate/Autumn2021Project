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
        Vector2 moveVector;

        public ISprite Sprite
        {
            get => mySprite;
            set => mySprite = value;
        }
        public EnemyTypes Type => EnemyTypes.SpikeTrap;

        public Vector2 Position
        { get => currPos;
          set => currPos = value;
        }
        public IEnemyState State 
        { 
            get => currState;
            set => currState = value;
        }

        public BladeTrap(ILink gameLink, Vector2 originPos)
        {
            link = gameLink;
            homePos = originPos; 
        }

        public void Update(GameTime gameTime)
        {
            //Change positions if the movement vector is not zero.
            if (!moveVector.Equals(new Vector2(0,0)))
            {
                currPos += moveVector;
            }
            else
            {
                //If moveVector is 0, try to attack
                moveVector = TryAttack();
            }
        }

        private Vector2 TryAttack()
        {
            if(currPos.X < link.position.X && link.position.X < (currPos.X + EnemyConstants.stdEnemySize.Width))
            {//If link is within the X dimensions of the blade trap, check if he's above or below.
                if (link.position.Y < currPos.Y)
                {
                    //Link is above, move upwards
                    moveVector = new Vector2(0, -EnemyConstants.bladeAttackSpeed);
                }
                else
                {
                    //Link is below.
                    moveVector = new Vector2(0, EnemyConstants.bladeAttackSpeed);
                }
            }
            else if(currPos.Y < link.position.Y && link.position.Y < (currPos.Y + EnemyConstants.stdEnemySize.Width))
            {//If link is within the Y dimensions of the blade trap, check if he's to the left or right.
                if (link.position.X < currPos.X)
                {
                    moveVector = new Vector2(-EnemyConstants.bladeAttackSpeed, 0);
                }
                else
                {
                    moveVector = new Vector2(EnemyConstants.bladeAttackSpeed, 0);
                }
            }
            return moveVector;
        }



    }
}
