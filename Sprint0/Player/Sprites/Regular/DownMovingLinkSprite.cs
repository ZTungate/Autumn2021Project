using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Player;

namespace Poggus.Player
{
    public class DownMovingLinkSprite : AbstractSprite
    {
        public Color[] colors;
        int numColors = 2;

        ILink player;
        public DownMovingLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[2])
        {
            this.player = player;

            colors = new Color[numColors];
            colors[0] = Color.White;
            colors[1] = Color.Red;
            
            SourceRect[0] = new Rectangle(18, 11, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(1, 11, 16, 16);
            this.Interval = LinkConstants.movementAnimInterval;
        }

        public override void Update(GameTime gameTime)
        {
           // player.Move(new Point(0, LinkConstants.linkSpeed));

            this.FrameStep(gameTime);
        }

    }
}
