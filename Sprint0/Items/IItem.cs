using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Items
{
    public interface IItem
    {
        Rectangle rect { get; set; }
        void CreateSprite();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch batch);

        Point GetPosition();
        void SetPosition(Point pos);
    }
}
