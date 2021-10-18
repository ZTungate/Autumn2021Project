﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{
    public class LeftItemUsingLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;

        private int stateTime;
        public LeftItemUsingLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new LeftUseItemLinkSprite(sprite.Texture, Link);
            link.sprite = mySprite;
            stateTime = 300; //300 miliseconds of time to be throwing the projectile
        }

        public void takeDamage()
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
                link.state = new LeftIdleLinkState(link, mySprite);
            }
        }

        public void useItem(Game1 game)
        {
            game.link.sprite = game.linkSpriteFactory.RightUseItemLinkSprite(game.link);
        }
    }
}