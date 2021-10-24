using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.Blocks
{
    public class BoundingBox : IBlock
    {
        public Rectangle sourceRect { get; set; } //no source rectangle
        public Rectangle destRect { get; set; }


        public BoundingBox(Rectangle Destination) //This is an "invisable" block to mark wall and forbidden areas
        {

            destRect = Destination;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           //We don't actually draw this it just exists to set the wall bounds
        }

        public void Update(GameTime gameTime)
        {
            //Does nothing since a floor tile doesn't need updated
        }

    }
}