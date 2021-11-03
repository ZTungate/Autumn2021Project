using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class LeftThrower : IEnemyState
    {
        private ISprite mySprite;
        private IEnemy thrower;
        public LeftThrower(ISprite sprite, IEnemy enemy)
        {
            //Get the sprite and enemy passed in, and the position of the enemy
            mySprite = sprite;
            thrower = enemy;
            //Set the enemy's sprite to this state's sprite.
            thrower.Sprite = mySprite;
        }

        public void TurnDown()
        {
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new DownThrowerSprite(texture);
            thrower.State = new DownThrower(mySprite, thrower);
        }

        public void TurnLeft()
        {
            //No action required, already facing left.
        }

        public void TurnRight()
        {
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new RightThrowerSprite(texture);
            thrower.State = new RightThrower(mySprite, thrower);
        }

        public void TurnUp()
        {
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new UpThrowerSprite(texture);
            thrower.State = new UpThrower(mySprite, thrower);
        }
        public void MoveForward()
        {
            //Get the current position of the thrower
            Point newPos = thrower.DestRect.Location;
            //Move the thrower the relevant direction to the current state.
            newPos.X -= EnemyConstants.throwerMoveSpeed;
            //Set the thrower's position to the new pos.
            thrower.DestRect = new Rectangle(newPos, thrower.DestRect.Size);
        }
        public Point AttackDirection()
        {
            //Return a vector pointing left
            return new Point(-1, 0);
        }
        public void Update(GameTime gameTime, ISprite enemySprite)
        {
            //mySprite = enemySprite;
        }
    }
}
