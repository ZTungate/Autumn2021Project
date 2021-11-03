using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Player;

namespace Sprint2.Player
{
    public class DownIdleLinkSprite : AbstractSprite
    {
        public Color[] colors;
        int numColors = 2;

        ILink player;

        public DownIdleLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[1])
        {
            this.player = player;
            colors = new Color[numColors];
            colors[0] = Color.White;
            colors[1] = Color.Red;
    
            SourceRect[0] = new Rectangle(1, 11, 16, 16);
            this.Interval = 40;
        }

    }
}
