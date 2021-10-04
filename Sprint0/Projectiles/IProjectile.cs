using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Projectiles
{
    public interface IProjectile
    {
        public ISprite Sprite { get; set; }
        
        public Vector2 Position { get; set; }

        public Vector2 Velocity { get; set; }

        public double Life { get;}
        public void Update(GameTime gameTime);
    }
}
