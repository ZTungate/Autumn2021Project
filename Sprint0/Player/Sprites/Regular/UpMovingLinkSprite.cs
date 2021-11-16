using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Player
{
    public class UpMovingLinkSprite : AbstractSprite
    {
        ILink player;

        public UpMovingLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[2])
        {
            this.player = player;
            SourceRect[0] = new Rectangle(86, 11, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(69, 11, 16, 16);
            this.Interval = LinkConstants.movementAnimInterval;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }

    }
}
