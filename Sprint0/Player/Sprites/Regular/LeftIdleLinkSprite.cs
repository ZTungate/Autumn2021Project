using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Player;

namespace Poggus.Player
{
    public class LeftIdleLinkSprite : AbstractSprite
    {

        ILink player;

        public Color[] colors;
        int numColors = 2;

        public LeftIdleLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[1])
        {
            this.player = player;
            Texture = spriteSheet;  //Set the texture2D to the provided spriteSheet (already initialized by factory)
            SourceRect = new Rectangle[1];

            colors = new Color[numColors];
            colors[0] = Color.White;
            colors[1] = Color.Red;

            SourceRect[0] = new Rectangle(35, 11, 16, 16);  //Set the frame for left idle link
            this.effects = SpriteEffects.FlipHorizontally;
        }
    }
}
