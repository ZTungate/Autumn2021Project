using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class DownThrower : IEnemyState
    {
        private ISprite mySprite;
        private IEnemy thrower;
        public DownThrower(ISprite sprite, IEnemy enemy)
        {
            mySprite = sprite;
            mySprite.Position = enemy.Position;
            thrower = enemy;
        }

        public void turnDown()
        {
            throw new NotImplementedException();
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
            thrower.State = new UpThrower(mySprite, thrower);
        }

        public void Update()
        {
        }
    }
}
