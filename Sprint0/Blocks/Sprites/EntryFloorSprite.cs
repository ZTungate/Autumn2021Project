using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.Blocks
{
    public class EntryFloorSprite : AbstractSprite
    {
        public EntryFloorSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(627, 982, 16, 16);
        }
        
    }
}