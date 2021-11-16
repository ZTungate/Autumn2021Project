using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Player;

namespace Poggus.Player
{
    public class RightSwordLinkSprite : AbstractSprite
    {
        ILink player;
        public RightSwordLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[5])
        {
            this.player = player;
            SourceRect[0] = new Rectangle(1, 77, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(18, 77, 27, 16);
            SourceRect[2] = new Rectangle(46, 77, 23, 16);
            SourceRect[3] = new Rectangle(70, 77, 19, 16);
            SourceRect[4] = new Rectangle(35, 11, 16, 16);  //Set the frame for right idle link
            this.Interval = LinkConstants.swordAnimInterval;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }

    }
}
