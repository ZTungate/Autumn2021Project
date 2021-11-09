using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public class DownThrower : IEnemyState
    {
        private IEnemy thrower;
        public DownThrower(ISprite sprite, IEnemy enemy)
        {
            thrower = enemy;
            thrower.Sprite = sprite;
        }

        public void TurnDown()
        {
            //No implementation needed
        }

        public void TurnLeft()
        {
            Texture2D texture = thrower.Sprite.Texture;
            thrower.Sprite = new LeftThrowerSprite(texture);
            thrower.State = new LeftThrower(thrower.Sprite, thrower);
        }

        public void TurnRight()
        {
            Texture2D texture = thrower.Sprite.Texture;
            thrower.Sprite = new RightThrowerSprite(texture);
            thrower.State = new RightThrower(thrower.Sprite, thrower);
        }

        public void TurnUp()
        {
            Texture2D texture = thrower.Sprite.Texture;
            thrower.Sprite = new UpThrowerSprite(texture);
            thrower.State = new UpThrower(thrower.Sprite, thrower);
        }
        public void MoveForward()
        {
            //Get the current position of the thrower
            Point newPos = thrower.DestRect.Location;
            //Move the thrower the relevant direction to the current state.
            newPos.Y += EnemyConstants.throwerMoveSpeed;
            //Set the thrower's position to the new pos.
            thrower.DestRect = new Rectangle(newPos, thrower.DestRect.Size);
        }
        public Point AttackDirection()
        {
            //Return a vector pointing downwards
            return new Point(0, 1);
        }
    }
}
