using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Blocks.Sprites
{
    public class FloorSprite : AbstractSprite
    {
        public FloorSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(290, 33, 16, 16);
        }
        
    }
}