using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            mySprite = sprite;
        }

        public void turnDown()
        {
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new DownThrowerSprite(texture);
            thrower.State = new DownThrower(mySprite, thrower);
        }

        public void turnLeft()
        {
            //No action required, already facing left.
        }

        public void turnRight()
        {
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new RightThrowerSprite(texture);
            thrower.State = new RightThrower(mySprite, thrower);
        }

        public void turnUp()
        {
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new UpThrowerSprite(texture);
            thrower.State = new UpThrower(mySprite, thrower);
        }
        public void moveForward()
        {
            //Get the current position of the thrower
            Vector2 newPos = thrower.Position;
            //Move the thrower the relevant direction to the current state.
            newPos.X -= 5;
            //Set the thrower's position to the new pos.
            thrower.Position = newPos;
        }

        public void Update(GameTime gameTime, ISprite enemySprite)
        {
            //mySprite = enemySprite;
        }
    }
}
