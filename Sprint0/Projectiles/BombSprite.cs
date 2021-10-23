﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class BombSprite : AbstractSprite
    {
        public Vector2 Position { get; set; }

        public int counter = 0;
        public BombSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[4])
        {
            //Set the two frames for the bat animation
            SourceRect[0] = new Rectangle(129, 185, 8, 16);
            SourceRect[1] = new Rectangle(138, 185, 16, 16);
            SourceRect[2] = new Rectangle(155, 185, 16, 16);
            SourceRect[3] = new Rectangle(172, 185, 16, 16);
            this.Interval = 100;
        }

        public override void Update(GameTime gameTime)
        {
            //Animate the sprites (pulled from animatedStillSprite.cs)
            this.FrameStep(gameTime);
        }
        /*public void Draw(SpriteBatch spriteBatch)
        {
            //Draw projectile at its position at twice its source size.
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width * 2, SourceRect[CurrentFrame].Height * 2);
            spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);
        }*/
    }
}
