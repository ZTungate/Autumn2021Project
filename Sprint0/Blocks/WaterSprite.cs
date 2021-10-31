using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.Blocks
{
    public class WaterSprite : IBlock
    {
        private Texture2D Texture { get; set; }
        public Rectangle sourceRect { get; set; }
        public Rectangle destRect { get; set; }

        public bool Walkable { get; }
        public WaterSprite(Texture2D spriteSheet, Vector2 Destination)
        {
            Walkable = false;
            Texture = spriteSheet;
            sourceRect = new Rectangle(563, 49, 16, 16);
            destRect = new Rectangle((int)Destination.X, (int)Destination.Y, sourceRect.Width * 2, sourceRect.Height * 2); //height adjustment just for visability
        }
        public void Draw(SpriteBatch spriteBatch) //TODO figure out where I want to actually draw this
        {
            
            spriteBatch.Draw(Texture, destRect, sourceRect, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //Does nothing since a floor tile doesn't need updated
        }
        
    }
}