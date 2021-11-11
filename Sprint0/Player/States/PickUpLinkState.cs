using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
    public class PickUpLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;

        private int stateTime;
        public PickUpLinkState(ILink Link, ISprite sprite, AbstractItem item)
        {
            link = Link;
            mySprite = new PickUpLinkSprite(sprite.Texture, Link, item);
            link.sprite = mySprite;
            stateTime = LinkConstants.itemUseTime;
        }

        public void TakeDamage()
        {
            //Call on link to take damage. Does this need to be here? Might not be necesary in the state itself.
            link.TakeDamage();
        }

        public void Update(GameTime gameTime)
        {
            //What needs to be updated in the State?
            if (stateTime > 0)
            {
                stateTime -= gameTime.ElapsedGameTime.Milliseconds;
            }
            else
            {
                //If the timer is up for this state, revert to an idle state for this direction.
                link.state = new DownIdleLinkState(link, mySprite);
            }
        }

        public void UseItem(ProjectileTypes item)
        {
            //Link is already using an item, do nothing.
        }

        public void SwordAttack()
        {
            link.state = new UpSwordLinkState(link, mySprite);
        }

        public void Move(direction direction)
        {
            //Link can not move while throwing an item.
        }

        public void PickUp(AbstractItem item)
        {
            //No Implementation needed.
        }

        private void Attack(ProjectileTypes item)
        {
            Vector2 directionVector = new Vector2(0, -1);
            switch (item)
            {
                //Spawn the relevant projectile moving downwards.
                case ProjectileTypes.redArrow:
                    link.ProjectileFactory.NewRegArrow(link.GetPosition(), direction.up);
                    break;
                case ProjectileTypes.blueArrow:
                    link.ProjectileFactory.NewBlueArrow(link.GetPosition(), direction.up);
                    break;
                case ProjectileTypes.linkBoomerang:
                    link.ProjectileFactory.LinkBoomerang(link.GetPosition(), (RegBoomerangVelocity * directionVector).ToPoint());
                    break;
                case ProjectileTypes.blueBoomerang:
                    link.ProjectileFactory.LinkBlueBoomerang(link.GetPosition(), (BlueBoomerangVelocity * directionVector).ToPoint());
                    break;
                case ProjectileTypes.fire:
                    link.ProjectileFactory.NewFire(link.GetPosition(), (FireVelocity * directionVector).ToPoint());
                    break;
                case ProjectileTypes.bomb:
                    link.ProjectileFactory.NewBomb(link.GetPosition() + directionVector.ToPoint());
                    break;
            }
        }

    }
}