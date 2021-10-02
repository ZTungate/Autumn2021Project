using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Helpers;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    //This probably needs to be somewhere else.
    public interface IStateEnemy
    {
        public void Update(GameTime gameTime);

        public ISprite Sprite { get; set; }

        public EnemyTypes Type { get; }

        public Vector2 Position { get; set; }

        public IBoomerangThrowerState State
        {
            get;
            set;
        }

        //public void Draw(SpriteBatch spriteBatch);
    }
}
