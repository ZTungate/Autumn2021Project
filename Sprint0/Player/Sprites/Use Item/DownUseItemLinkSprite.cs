using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Player;

namespace Sprint2.Player
{
    public class DownUseItemLinkSprite : AbstractSprite
    {
        ILink player;

        public DownUseItemLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[1])
        {
            this.player = player;
            SourceRect[0] = new Rectangle(107, 11, 16, 16);
        }

    }
}
