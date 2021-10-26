using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2.Blocks
{
    public interface IBlock
    {
        Rectangle sourceRect { get; set; }

        Rectangle destRect { get; set; }
        
        bool Walkable { get; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);

        

        //Texture and sourceRect replace with Sprite?
    }
}
