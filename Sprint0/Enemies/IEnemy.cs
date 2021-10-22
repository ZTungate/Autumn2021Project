using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint3.Helpers;
using Sprint3;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Enemies
{
    //This probably needs to be somewhere else.
    public interface IEnemy
    {
        public void Update(GameTime gameTime);

        public ISprite Sprite { get; set; }

        public EnemyTypes Type { get;}

        public Vector2 Position { get; set; }

        public IEnemyState State { get; set; }
        
        //public void Draw(SpriteBatch spriteBatch);
    }
}
