﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Player;

namespace Sprint2.Player
{
    public class RightIdleLinkSprite : AbstractSprite
    {
        ILink player;

        public RightIdleLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[1])
        {
            this.player = player;
            SourceRect[0] = new Rectangle(35, 11, 16, 16);  //Set the frame for right idle link
            this.Interval = 40;
            /*Position = pos;*/     //Sets the position to Link's position
        }

    }
}
