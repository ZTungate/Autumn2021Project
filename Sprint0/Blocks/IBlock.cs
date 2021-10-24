using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2.Blocks
{
    public interface IBlock //rename to IBlock?
    {
        Texture2D Texture { get; set; } //may have this as a private field (does it need to be externally referenced?)

        Rectangle sourceRect { get; set; }

        Rectangle destRect { get; set; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);

        //Texture and sourceRect replace with Sprite?
    }
}
