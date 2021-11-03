using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public class UpMovingLinkSprite : AbstractSprite
    {
        ILink player;

        public UpMovingLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[2])
        {
            this.player = player;
            SourceRect[0] = new Rectangle(86, 11, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(69, 11, 16, 16);
            this.Interval = 128;
            /*Position = pos;*/     //Sets the position to Link's position
        }

        public override void Update(GameTime gameTime)
        {
            // Implement animation changes here

            player.Move(new Point(0, -LinkConstants.linkSpeed));
            this.FrameStep(gameTime);
        }

    }
}
