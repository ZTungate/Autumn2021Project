using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Player;

namespace Poggus.Player
{
    public class LeftMovingLinkSprite : AbstractSprite
    {
        ILink player;
        public LeftMovingLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[2])
        {
            this.player = player;
            
            SourceRect[0] = new Rectangle(52, 11, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(35, 11, 16, 16);
            this.Interval = 128f;
            this.effects = SpriteEffects.FlipHorizontally;
            /*Position = pos;*/     //Sets the position to Link's position
        }

        public override void Update(GameTime gameTime)
        {
            // Implement animation changes here

            //player.Move(new Point(-LinkConstants.linkSpeed, 0));
            this.FrameStep(gameTime);
        }

    }
}
