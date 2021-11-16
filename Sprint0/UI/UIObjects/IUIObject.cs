using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poggus.UI.UIObjects
{
    public interface IUIObject
    {
        Rectangle DestRect { get; set; }
        bool Visible { get; set; }
        void Draw(SpriteBatch batch);
        void Update(GameTime gameTime);

        Point GetPosition();
        void SetPosition(Point pos);
    }
}
