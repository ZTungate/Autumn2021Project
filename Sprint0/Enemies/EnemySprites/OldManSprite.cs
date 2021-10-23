using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class OldManSprite : AbstractSprite
    {
        public OldManSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(1,11,16,16);

            //Dummy Position, will be replaced later.
            //Position = new Vector2(500,100);
        }
    }
}
