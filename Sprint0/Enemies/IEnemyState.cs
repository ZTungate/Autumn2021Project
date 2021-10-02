using Microsoft.Xna.Framework;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public interface IEnemyState
    {
            public void turnUp();
            public void turnDown();
            public void turnLeft();
            public void turnRight();
            public void moveForward();
            public void Update(GameTime gameTime, ISprite sprite);
    }
}
