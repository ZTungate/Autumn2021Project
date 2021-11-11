using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
	public class RightItemUsingLinkState : ILinkState
	{
        private ILink link;
        private ISprite mySprite;

        private int stateTime;
        public RightItemUsingLinkState(ILink Link, ISprite sprite, ProjectileTypes item)
        {
            link = Link;
            mySprite = new RightUseItemLinkSprite(sprite.Texture, Link);
            link.sprite = mySprite;
            stateTime = LinkConstants.itemUseTime;
            Attack(item);
        }

        public void TakeDamage()
        {
            //Call on link to take damage. Does this need to be here? Might not be necesary in the state itself.
            link.TakeDamage();
        }

        public void Update(GameTime gameTime)
        {
            //What needs to be updated in the State?
            if(stateTime > 0)
            {
                stateTime -= gameTime.ElapsedGameTime.Milliseconds;
            }
            else
            {
                //If the timer is up for this state, revert to an idle state for this direction.
                link.state = new RightIdleLinkState(link,mySprite);
            }
        }

        public void UseItem(ProjectileTypes item)
        {
            //Link is already using an item, do nothing.
        }
        public void SwordAttack()
        {
            link.state = new RightSwordLinkState(link, mySprite);
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
            Vector2 directionVector = new Vector2(1, 0);
            switch (item)
            {
                //Spawn the relevant projectile moving downwards.
                case ProjectileTypes.redArrow:
                    link.ProjectileFactory.NewRegArrow(link.GetPosition(), direction.right);
                    break;
                case ProjectileTypes.blueArrow:
                    link.ProjectileFactory.NewBlueArrow(link.GetPosition(), direction.right);
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