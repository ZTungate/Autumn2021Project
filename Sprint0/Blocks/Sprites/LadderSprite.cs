using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Blocks.Sprites
{
    public class LadderSprite : AbstractSprite
    {
        public LadderSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(49, 1, 16, 16);
        }
        
    }
}