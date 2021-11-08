using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Player;

namespace Poggus.Player
{
    public class UpUseItemLinkSprite : AbstractSprite
    {
        ILink player;

        public UpUseItemLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[1])
        {
            this.player = player;
            SourceRect[0] = new Rectangle(141, 11, 16, 16);  //Set the frame for right idle link
        }

    }
}
