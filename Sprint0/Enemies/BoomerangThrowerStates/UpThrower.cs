using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class UpThrower : IEnemyState
    {
        private ISprite mySprite;
        private IEnemy thrower;
        public UpThrower(ISprite sprite, IEnemy enemy)
        {
            mySprite = sprite;
            mySprite.Position = enemy.Position;
            thrower = enemy;
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
            thrower.State = new RightThrower(mySprite, thrower);
        }

        public void turnUp()
        {
            //Already facing up, no implementation required.
        }

        public void Update()
        {
        }
    }
}
