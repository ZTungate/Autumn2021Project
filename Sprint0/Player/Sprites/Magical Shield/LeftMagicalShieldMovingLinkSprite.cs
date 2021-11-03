﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public class LeftMagicalShieldMovingLinkSprite : AbstractSprite
    {
        public LeftMagicalShieldMovingLinkSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            SourceRect[0] = new Rectangle(340, 11, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(323, 11, 16, 16);
            this.Interval = 128f;
        }

        public override void Update(GameTime gameTime)
        {
            // Implement animation changes here
            this.FrameStep(gameTime);
        }

    }
}
