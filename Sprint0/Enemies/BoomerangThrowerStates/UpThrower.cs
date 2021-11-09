using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public class UpThrower : IEnemyState
    {
        private IEnemy thrower;
        public UpThrower(ISprite sprite, IEnemy enemy)
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
            //Already facing up, no implementation required.
        }

        public void MoveForward()
        {
            //Get the current position of the thrower
            Point newPos = thrower.DestRect.Location;
            //Move the thrower the relevant direction to the current state.
            newPos.Y -= EnemyConstants.throwerMoveSpeed;
            //Set the thrower's position to the new pos.
            thrower.DestRect = new Rectangle(newPos, thrower.DestRect.Size);
        }
        public Point AttackDirection()
        {
            //Return a vector pointing up.
            return new Point(0, -1);
        }
    }
}
