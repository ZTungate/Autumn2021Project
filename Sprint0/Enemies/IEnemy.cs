using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Helpers;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    //This probably needs to be somewhere else.
    public interface IEnemy
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch batch);

        public ISprite Sprite { get; set; }
        public EnemyTypes Type { get; }

        public Rectangle DestRect{ get; set; }

        public Point oldPosition { get; set; }

        public IEnemyState State { get; set; } //May not need this in interface if it only applies to 1 enemy

        public Point GetPosition();
        public void SetPosition(Point pos);
    }
}
