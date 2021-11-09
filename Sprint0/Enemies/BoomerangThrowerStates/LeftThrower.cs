using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public class LeftThrower : IEnemyState
    {
        private IEnemy thrower;
        public LeftThrower(ISprite sprite, IEnemy enemy)
        {
            //Get the sprite and enemy passed in, and the position of the enemy
            thrower = enemy;
            thrower.Sprite = sprite;
        }

        public void TurnDown()
        {
            Texture2D texture = thrower.Sprite.Texture;
            thrower.Sprite = new DownThrowerSprite(texture);
            thrower.State = new DownThrower(thrower.Sprite, thrower);
        }

        public void TurnLeft()
        {
            //No action required, already facing left.
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
            newPos.X -= EnemyConstants.throwerMoveSpeed;
            //Set the thrower's position to the new pos.
            thrower.DestRect = new Rectangle(newPos, thrower.DestRect.Size);
        }
        public Point AttackDirection()
        {
            //Return a vector pointing left
            return new Point(-1, 0);
        }
    }
}
