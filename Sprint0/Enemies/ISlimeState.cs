using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public interface ISlimeState
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
