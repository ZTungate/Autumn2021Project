using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class BombSprite : AbstractSprite
    {
        public Vector2 Position { get; set; }

        public int counter = 0;
        public BombSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            //Set the source rectangle for the bomb sprite
            SourceRect[0] = new Rectangle(129, 185, 8, 16);
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }
}
