using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint3.Blocks
{
    public interface IBlocks
    {
        Texture2D Texture { get; set; }

        Rectangle sourceRect { get; set; }

        Rectangle destRect { get; set; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);

    }
}
