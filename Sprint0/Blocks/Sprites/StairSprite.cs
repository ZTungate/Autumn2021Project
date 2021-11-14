using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Blocks.Sprites
{
    public class StairSprite : AbstractSprite
    {
        public StairSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(386, 81, 16, 16);
        }
        
    }
}