﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Sprint0.Projectiles.ProjectileConstants;

namespace Sprint2.Player
{
    public class DownSwordLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;

        private int stateTime;
        public DownSwordLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new DownSwordLinkSprite(sprite.Texture, Link);
            link.sprite = mySprite;
            stateTime = 300; //300 miliseconds of time to be throwing the projectile
            link.facing = direction.down;
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
            //Link is already attacking, do nothing.
        }

        public void SwordAttack()
        {
            //Link can not stab while already stabbing.
        }

        public void Move(direction direction)
        {
            //No moving during attack
        }
    }
}