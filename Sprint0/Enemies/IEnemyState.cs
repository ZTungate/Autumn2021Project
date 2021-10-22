using Microsoft.Xna.Framework;
using Sprint3;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Enemies
{
    public interface IEnemyState
    {
            public void TurnUp();
            public void TurnDown();
            public void TurnLeft();
            public void TurnRight();
            public void MoveForward();
            public Vector2 AttackDirection();
        public void Update(GameTime gameTime, ISprite sprite);
    }
}
