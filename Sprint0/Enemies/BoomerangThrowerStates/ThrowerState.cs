using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Enemies.BoomerangThrowerStates
{
    public class ThrowerState : IEnemyState
    {
        private Point direction;
        private IEnemy thrower;
        public ThrowerState(Point direction, ISprite sprite, IEnemy enemy)
        {
            this.direction = direction;
            thrower = enemy;
            thrower.Sprite = sprite;
        }

        public void TurnDown()
        {
            Texture2D texture = thrower.Sprite.Texture;
            thrower.Sprite = new DownThrowerSprite(texture);
            thrower.State = new ThrowerState(new Point(0,1), thrower.Sprite, thrower);
        }

        public void TurnLeft()
        {
            Texture2D texture = thrower.Sprite.Texture;
            thrower.Sprite = new LeftThrowerSprite(texture);
            thrower.State = new ThrowerState(new Point(-1, 0), thrower.Sprite, thrower);
        }

        public void TurnRight()
        {
            Texture2D texture = thrower.Sprite.Texture;
            thrower.Sprite = new RightThrowerSprite(texture);
            thrower.State = new ThrowerState(new Point(1, 0), thrower.Sprite, thrower);
        }

        public void TurnUp()
        {
            Texture2D texture = thrower.Sprite.Texture;
            thrower.Sprite = new UpThrowerSprite(texture);
            thrower.State = new ThrowerState(new Point(0, -1), thrower.Sprite, thrower);
        }
        public void MoveForward()
        {
            //Get the current position of the thrower
            Point newPos = thrower.DestRect.Location;
            //Move the thrower the relevant direction to the current state.
            newPos += new Point(direction.X * EnemyConstants.throwerMoveSpeed, direction.Y * EnemyConstants.throwerMoveSpeed);
            //Set the thrower's position to the new pos.
            thrower.DestRect = new Rectangle(newPos, thrower.DestRect.Size);
        }
        public Point AttackDirection()
        {
            //Return a vector pointing downwards
            return direction;
        }
    }
}
