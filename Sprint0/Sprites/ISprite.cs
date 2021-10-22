using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint3
{
    public interface ISprite
    {
        int CurrentFrame { get; set; }

        int FrameCount { get; }

        float SpriteSpeed { get; set; }

        Texture2D Texture { get; set; }

        Rectangle[] SourceRect { get; set; }

        Vector2 Position { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
