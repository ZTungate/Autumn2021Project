using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Items
{
    public interface IItem
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch batch);
    }
}
