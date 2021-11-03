using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Items;
using Sprint2.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;
using static Sprint0.Projectiles.ProjectileConstants;

namespace Sprint2.Player
{
    public enum direction { up, down, left, right };

    public interface ILink
    {
        public ILinkState state { get; set; }
        public Rectangle DestRect { get; set; }
        public Point oldPosition { get; set; }
        public ISprite sprite { get; set; }
        public Color color {get;set;}
        public ProjectileFactory ProjectileFactory { get;  set; }

        enum Direction { };
        void takeDamage();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void Move(Point moveDirection);
        void UseItem(ProjectileTypes item);
        void SwordAttack();
        void PickUp(AbstractItem item);
        Point GetPosition();
        void SetPosition(Point pos);
    }
}
