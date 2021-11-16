using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Player;

namespace Poggus.Player
{
    public class DownSwordLinkSprite : AbstractSprite
    {
        ILink player;
        public DownSwordLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[5])
        {
            this.player = player;
            SourceRect[0] = new Rectangle(1, 47, 16, 27);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(18, 47, 16, 27);
            SourceRect[2] = new Rectangle(35, 47, 16, 23);
            SourceRect[3] = new Rectangle(52, 47, 16, 19);
            SourceRect[4] = new Rectangle(1, 11, 16, 16);  //Set the frame for right idle link
            this.Interval = LinkConstants.swordAnimInterval;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }

    }
}
