using Microsoft.Xna.Framework;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public interface IEnemyState
    {
        public void TurnUp();
        public void TurnDown();
        public void TurnLeft();
        public void TurnRight();
        public void MoveForward();
        public Point AttackDirection();
    }
}
