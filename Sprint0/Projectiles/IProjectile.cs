﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint3;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Projectiles
{
    public interface IProjectile
    {
        public ISprite Sprite { get; set; }
        
        public Vector2 Position { get; set; }

        public Vector2 Velocity { get; set; }

        public int Life { get;}
        public void Update(GameTime gameTime);
    }
}
