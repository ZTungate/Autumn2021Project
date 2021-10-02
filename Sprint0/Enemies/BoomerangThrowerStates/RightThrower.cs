using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class RightThrower : IEnemyState
    {
        private ISprite mySprite;
        private IEnemy thrower;
        public RightThrower(ISprite sprite, IEnemy enemy)
        {
            mySprite = sprite;
            mySprite.Position = enemy.Position;
        }

        public void turnDown()
        {
            thrower.State = new DownThrower(mySprite, thrower);
        }

        public void turnLeft()
        {
            thrower.State = new LeftThrower(mySprite, thrower);
        }

        public void turnRight()
        {
            //No implementation needed
        }

        public void turnUp()
        {
            thrower.State = new UpThrower(mySprite, thrower);
        }

        public void Update()
        {
        }
    }
}
