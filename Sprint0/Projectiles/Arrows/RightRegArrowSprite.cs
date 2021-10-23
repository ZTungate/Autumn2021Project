﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class RightRegArrowSprite : AbstractSprite
    {
        public Vector2 Position { get; set; }

        public int scale = 2;

        public int TotalFrames = 0;

        public bool incFrame = true;

        public RightRegArrowSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            SourceRect[0] = new Rectangle(10, 185, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(53, 185, 8, 16);
            this.Interval = 500f;
        }

        public override void Update(GameTime gameTime)
        {
            // Implement animation changes here
            this.FrameStep(gameTime);
        }
        /*public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame % FrameCount].Width * scale, SourceRect[CurrentFrame % FrameCount].Height * scale);
            spriteBatch.Draw(Texture, Position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 1);

        }*/
    }

}
