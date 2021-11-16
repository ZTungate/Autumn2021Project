using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Player
{
    public class UpIdleLinkSprite : AbstractSprite
    {

        ILink player;

        public UpIdleLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[1])
        {
            this.player = player;

            SourceRect[0] = new Rectangle(69, 11, 16, 16);  //Set the frame for right idle link
        }

    }
}
