using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint3
{
    interface IAnimatedSprite : ISprite
    {
        float Timer { get; set; }

        float Interval { get; set; }
    }
}
