using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
    public class DeadLinkState : ILinkState
    {
        private ILink link;
        public DeadLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            ISprite newSprite = new DeadLinkSprite(sprite.Texture, link);
            link.Sprite = newSprite;
        }

        public void TakeDamage()
        {
            //Link is dead, no implementation needed.
        }

        public void Update(GameTime gameTime)
        {
            //Link is dead, no implementation needed.
        }

        public void UseItem(ProjectileTypes item)
        {
            //Link is dead, no implementation needed.
        }
        public void SwordAttack()
        {
            //Link is dead, no implementation needed.
        }

        public void Move(Direction direction)
        {
            //Link is dead, no implementation needed.
        }

        public void Idle()
        {
            //Link is dead, no implementation needed.
        }

        public void Die()
        {
            //Link is already dead, no implementation needed.
        }

        public void PickUp(AbstractItem item)
        {
            //Link is dead, no implementation needed.
        }
    }
}