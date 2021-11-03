using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public interface ISprite
    {
        int CurrentFrame { get; set; }

        int FrameCount { get; }

        Texture2D Texture { get; set; }

        Rectangle[] SourceRect { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Rectangle rect);
    }
}
