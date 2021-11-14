﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;
using Poggus.Projectiles;
using Poggus.Helpers;

namespace Poggus.Player
{
    public class UpItemUsingLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;

        private int stateTime;
        public UpItemUsingLinkState(ILink Link, ISprite sprite, ProjectileTypes item)
        {
            link = Link;
            mySprite = new UpUseItemLinkSprite(sprite.Texture, Link);
            link.Sprite = mySprite;
            stateTime = LinkConstants.itemUseTime;
            Attack(item);
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
                link.State = new UpIdleLinkState(link, mySprite);
            }
        }

        public void UseItem(ProjectileTypes item)
        {
            //Link is already using an item, do nothing.
        }

        public void SwordAttack()
        {
            link.State = new UpSwordLinkState(link, mySprite);
        }

        public void Move(Direction direction)
        {
            //Link can not move while throwing an item.
        }

        private void Attack(ProjectileTypes item)
        {
            Vector2 directionVector = new Vector2(0, -1);
            switch (item)
            {
                //Spawn the relevant projectile moving downwards.
                case ProjectileTypes.redArrow:
                    link.ProjectileFactory.NewRegArrow(LocationHelpers.GetLocationCenteredSpawnUp(link.DestRect, ProjectileConstants.HorizArrowSize), Direction.up);
                    break;
                case ProjectileTypes.blueArrow:
                    link.ProjectileFactory.NewBlueArrow(LocationHelpers.GetLocationCenteredSpawnUp(link.DestRect, ProjectileConstants.HorizArrowSize), Direction.up);
                    break;
                case ProjectileTypes.linkBoomerang:
                    link.ProjectileFactory.LinkBoomerang(LocationHelpers.GetLocationCenteredSpawnUp(link.DestRect, ProjectileConstants.boomerangSize), (RegBoomerangVelocity * directionVector).ToPoint(), link);
                    break;
                case ProjectileTypes.blueBoomerang:
                    link.ProjectileFactory.LinkBlueBoomerang(LocationHelpers.GetLocationCenteredSpawnUp(link.DestRect, ProjectileConstants.boomerangSize), (BlueBoomerangVelocity * directionVector).ToPoint(), link);
                    break;
                case ProjectileTypes.fire:
                    link.ProjectileFactory.NewFire(LocationHelpers.GetLocationCenteredSpawnUp(link.DestRect, ProjectileConstants.fireSize), (FireVelocity * directionVector).ToPoint());
                    break;
                case ProjectileTypes.bomb:
                    link.ProjectileFactory.NewBomb(LocationHelpers.GetLocationCenteredSpawnUp(link.DestRect, ProjectileConstants.BombSize) + directionVector.ToPoint());
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

        public void PickUp(AbstractItem item)
        {
            //No Implementation needed.
        }

    }
}