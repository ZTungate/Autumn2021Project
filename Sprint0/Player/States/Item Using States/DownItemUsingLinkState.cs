﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player;
using Sprint0.Projectiles;
using System;
using static Sprint0.Projectiles.ProjectileConstants;

namespace Sprint2.Player
{
    public class DownItemUsingLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;

        private int stateTime;
        public DownItemUsingLinkState(ILink Link, ISprite sprite, ProjectileTypes item)
        {
            link = Link;
            mySprite = new DownUseItemLinkSprite(sprite.Texture, Link);
            link.sprite = mySprite;
            stateTime = LinkConstants.itemUseTime;
            Attack(item);
        }

        public void TakeDamage()
        {
            //Call on link to take damage. Does this need to be here? Might not be necesary in the state itself.
            link.takeDamage();
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
            link.state = new DownSwordLinkState(link, mySprite);
        }

        public void Move(direction direction)
        {
            //Link can not move while throwing an item.
        }

        private void Attack(ProjectileTypes item)
        {
            Vector2 directionVector = new Vector2(0, 1);
            switch (item)
            {
                //Spawn the relevant projectile moving downwards.
                case ProjectileTypes.redArrow:
                    link.ProjectileFactory.NewRegArrow(link.position, direction.down);
                    break;
                case ProjectileTypes.blueArrow:
                    link.ProjectileFactory.NewBlueArrow(link.position, direction.down);
                    break;
                case ProjectileTypes.linkBoomerang:
                    link.ProjectileFactory.NewBoomerang(link.position, RegBoomerangVelocity * directionVector);
                    break;
                case ProjectileTypes.blueBoomerang:
                    link.ProjectileFactory.NewBlueBoomerang(link.position, BlueBoomerangVelocity * directionVector);
                    break;
                case ProjectileTypes.fire:
                    link.ProjectileFactory.NewFire(link.position, FireVelocity * directionVector);
                    break;
                case ProjectileTypes.bomb:
                    link.ProjectileFactory.NewBomb(new Vector2(link.position.X, link.position.Y + link.sprite.SourceRect[link.sprite.CurrentFrame].Height * 2));
                    break;
            }
        }
    }
}