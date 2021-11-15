using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Poggus
{
    public interface ISprite
    {
        int CurrentFrame { get; set; }

        int FrameCount { get; }

        Texture2D Texture { get; set; }

        Rectangle[] SourceRect { get; set; }

        bool IsUISprite { get; set; }

        Color Color { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Rectangle rect);
    }
}
