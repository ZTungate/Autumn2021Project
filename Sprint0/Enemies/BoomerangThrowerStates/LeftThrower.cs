using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class LeftThrower : IEnemyState
    {
        private ISprite mySprite;
        private IEnemy thrower;
        public LeftThrower(ISprite sprite, IEnemy enemy)
        {
            thrower = enemy;
        }

        public void turnDown()
        {
            throw new NotImplementedException();
        }

        public void turnLeft()
        {
            //No action required, already facing left.
        }

        public void turnRight()
        {
            thrower.State = new RightThrower(mySprite,thrower);
        }

        public void turnUp()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {

        }
    }
}
