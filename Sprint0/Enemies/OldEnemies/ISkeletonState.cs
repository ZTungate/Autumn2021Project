using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Enemies
{
    public interface ISkeletonState
    {
        //Skeleton moves aimlessly, this should be the only movement method needed
        Vector2 RandomMove();
        void Update(GameTime gameTime);

    }
}
