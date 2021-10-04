using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public interface ILink
    {
        public IPlayerState state { get; set; }
        public Vector2 position { get; set; }
        public ISprite sprite { get; set; }

        public Color color {get;set;}
        void takeDamage();
        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);

        void move(Vector2 moveDirection);
        /*void moveUp(float speed);
        void moveRight(float speed);
        void moveLeft(float speed);
        void moveDown(float speed);*/

    }
}
