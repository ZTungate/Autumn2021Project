using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Player;

namespace Poggus.Player
{
    public class RightMovingLinkSprite : AbstractSprite
    {
        ILink player;

        public RightMovingLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[2])
        {
            this.player = player;
            
            SourceRect[0] = new Rectangle(52, 11, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(35, 11, 16, 16);
            this.Interval = LinkConstants.movementAnimInterval;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }

    }
}
