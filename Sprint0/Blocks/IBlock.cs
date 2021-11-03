﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2.Blocks
{
    public interface IBlock
    {
        Rectangle DestRect { get; set; }
        
        bool Walkable { get; }
        bool Moveable { get; }
        ISprite Sprite { get; set; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);

        Point GetPosition();
        void SetPosition(Point point);

    }
}
