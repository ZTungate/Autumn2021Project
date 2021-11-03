using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class InitialThrower : IEnemyState
    {
        private ISprite mySprite;
        private IEnemy thrower;
        public InitialThrower(ISprite sprite, IEnemy enemy)
        {
            thrower = enemy;
            mySprite = sprite;
        }

        public void TurnDown()
        {
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new DownThrowerSprite(texture);
            thrower.State = new DownThrower(mySprite, thrower);
        }

        public void TurnLeft()
        {
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new LeftThrowerSprite(texture);
            thrower.State = new LeftThrower(mySprite, thrower);
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
