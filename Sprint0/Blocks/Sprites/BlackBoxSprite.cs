using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Blocks.Sprites
{
    public class BlackBoxSprite : AbstractSprite
    {
        public BlackBoxSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(33, 387, 16, 16);
        }
        
    }
}