using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Blocks.Sprites
{
    public class RightStatueSprite : AbstractSprite
    {
        public RightStatueSprite(Texture2D spriteSheet) :base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(611, 934, 16, 16);
        }
        
    }
}