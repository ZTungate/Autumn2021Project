using System;
using System.Collections.Generic;
using System.Text;
using Poggus;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poggus.UI.UIObjects
{
    public class ImageUI : IUIObject
    {
        public Rectangle DestRect { get; set; }
        public bool Visible { get; set; }

        ISprite sprite;
        public ImageUI(ISprite sprite, Point location, Point size)
        {
            this.sprite = sprite;
            DestRect = new Rectangle(location, size);
        }
        public void Draw(SpriteBatch batch)
        {
            sprite.Draw(batch, DestRect);
        }
        public void Update(GameTime gameTime)
        {
            //no-op
        }
        public void SetPosition(Point pos)
        {
            this.DestRect = new Rectangle(pos, DestRect.Size);
        }
        public Point GetPosition()
        {
            return this.DestRect.Location;
        }
    }
}
