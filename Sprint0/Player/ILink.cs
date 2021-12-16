using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items;
using Poggus.Projectiles;
using Poggus.PlayerInventory;
using System;
using System.Collections.Generic;
using System.Text;
using static Poggus.Projectiles.ProjectileConstants;
using Poggus.Sound;
using Poggus.Collisions;

namespace Poggus.Player
{
    public enum Direction { up, down, left, right };

    public interface ILink
    {
        public ILinkState State { get; set; }
        public Rectangle DestRect { get; set; }
        public Rectangle ColliderRect { get; set; }
        public Point OldPosition { get; set; }
        public ISprite Sprite { get; set; }
        public ProjectileFactory ProjectileFactory { get;  set; }
        public SoundManager SoundManager { get; set; }
        public int Health { get; set; }
        public int maxHealth { get; set; }
        public bool collideWithBounds { get; set; }
        public bool movingTo { get; set; }

        public bool hasPickedUpBombs { get; set; }
        public Inventory LinkInventory { get;}
        void TakeDamage(int damageAmount, ColDirections damageDir);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void Move(Point moveDirection);
        void UseItem(ProjectileTypes item);
        void SwordAttack();
        void PickUp(AbstractItem item);
        Point GetPosition();
        void SetPosition(Point pos);
        bool FullHealth();
        void StartMoveToNewRoom(Point pos);

        void Reset();

    }
}
