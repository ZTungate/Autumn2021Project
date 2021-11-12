using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Inventory;
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
        public Vector2 position { get; set; }
        public Vector2 oldPosition { get; set; }
        public ISprite sprite { get; set; }
        public Color color {get;set;}
        public ProjectileFactory ProjectileFactory { get;  set; }

        public Inventory inventory { get; set; }

        enum Direction { };
        void takeDamage();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void Move(Vector2 moveDirection);
        void UseItem(ProjectileTypes item);
        void SwordAttack();
        void PickUp(AbstractItem item);
    }
}
