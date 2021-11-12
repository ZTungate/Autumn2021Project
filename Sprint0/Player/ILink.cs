using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items;
using Poggus.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
    public enum direction { up, down, left, right };

    public interface ILink
    {
        public ILinkState state { get; set; }
        public Rectangle DestRect { get; set; }
        public Point oldPosition { get; set; }
        public ISprite sprite { get; set; }
        public ProjectileFactory ProjectileFactory { get;  set; }

        enum Direction { };
        void TakeDamage();
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
