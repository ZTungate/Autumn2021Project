using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.Blocks
{
    public class BlackBoxSprite : AbstractSprite
    {
        public BlackBoxSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[1] = new Rectangle(33, 387, 16, 16);
        }
        
    }
}