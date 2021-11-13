using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
    public class InitialLinkState : ILinkState
    {
        private ILink link;
        public InitialLinkState(ILink Link, ISprite sprite)
        {
            /* 
             * This state is for first initialization where no textures are loaded for sprites yet.
             * This state replaces itself with rightIdleState at first update (after textures are loaded and Link gets a default sprite).
             */
            link = Link;
        }

        public void TakeDamage()
        {
            //This state lasts no longer than 1 tick, no time for it to be damaged.
            //No implementation needed.
        }

        public void Update(GameTime gameTime)
        {
            //Replace this state with a right idle state. By now, a sprite has been passed to link during LoadContent().
            link.State = new RightIdleLinkState(link, link.Sprite);
        }

        public void UseItem(ProjectileTypes item)
        {
            //This state lasts no longer than 1 tick, no time for it to use items.
            //No implementation needed
        }
        public void SwordAttack()
        {
            //No Implementation needed.
        }

        public void Move(Direction direction)
        {
            //This state does not require movement code.
        }
        public void Idle()
        {
            //No implementation needed
        }

        public void Die()
        {
            //No implementation needed
        }

        public void PickUp(AbstractItem item)
        {
            //No Implementation needed.
        }
    }
}