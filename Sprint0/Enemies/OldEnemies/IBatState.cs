using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Enemies
{
    public interface IBatState
    {
        void Update(GameTime gameTime);
        
    }
}
