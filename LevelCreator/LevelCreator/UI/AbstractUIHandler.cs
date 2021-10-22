using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LevelCreator.UI
{
    class AbstractUIHandler
    {
        protected bool visible = false;

        public bool IsVisible()
        {
            return visible;
        }
        public void SetVisible(bool visible)
        {
            this.visible = visible;
        }
        public virtual void Update(GameTime gameTime)
        {
            //no-op
        }
        public virtual void Draw(SpriteBatch batch)
        {
            if (!visible) return;
        }
    }
}
