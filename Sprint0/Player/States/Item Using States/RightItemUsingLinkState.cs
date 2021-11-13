﻿using Microsoft.Xna.Framework;
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
            link.Sprite = mySprite;
            stateTime = LinkConstants.itemUseTime;
            Attack(item);
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
                link.State = new RightIdleLinkState(link,mySprite);
            }
        }

        public void UseItem(ProjectileTypes item)
        {
            //Link is already using an item, do nothing.
        }
        public void SwordAttack()
        {
            link.State = new RightSwordLinkState(link, mySprite);
        }
        public void Move(Direction direction)
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
                    link.ProjectileFactory.NewRegArrow(link.GetPosition(), Direction.right);
                    break;
                case ProjectileTypes.blueArrow:
                    link.ProjectileFactory.NewBlueArrow(link.GetPosition(), Direction.right);
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
        public void Idle()
        {
            //Link is busy, can not force change to idle.
        }

        public void Die()
        {
            //Change link to a dead state
            link.State = new DeadLinkState(link, mySprite);
        }
    }
}