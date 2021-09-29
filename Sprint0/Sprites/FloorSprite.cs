using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.Blocks
{
    public class FloorSprite : IBlocks
    {
        public Texture2D Texture { get; set; }
        public Rectangle sourceRect { get; set; }
        public Vector2 Position { get; set; }


        public FloorSprite(Texture2D spriteSheet)
        {
            Texture = spriteSheet;
            sourceRect = new Rectangle(290, 33, 16, 16);
            Position = new Vector2(400, 30);
        }
        public void Draw(SpriteBatch spriteBatch) //TODO figure out where I want to actually draw this
        {
            throw new System.NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            //Does nothing since a floor tile doesn't need updated
        }
        
    }
}