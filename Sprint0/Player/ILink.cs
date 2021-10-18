using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public enum direction { up, down, left, right };

    public interface ILink
    {
        public ILinkState state { get; set; }
        public Vector2 position { get; set; }
        public ISprite sprite { get; set; }
        public Color color {get;set;}
        public direction facing { get; set; }
        enum Direction { };
        void takeDamage();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void move(Vector2 moveDirection);


        void RegBoomerangAttack();
        void BlueBoomerangAttack();
        void RegArrowAttack();
        void BlueArrowAttack();
        void BombAttack();
        void FireAttack();
        /*void moveUp(float speed);
        void moveRight(float speed);
        void moveLeft(float speed);
        void moveDown(float speed);*/

    }
}
