﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint3.Player
{
    public class LeftSwordLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;

        private int stateTime;
        public LeftSwordLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new LeftSwordLinkSprite(sprite.Texture, Link);
            link.sprite = mySprite;
            stateTime = 300; //300 miliseconds of time to be throwing the projectile
            link.facing = direction.left;
            link.canAttack = false; //disable link's attack
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
                link.canAttack = true; //re-enable link attack
                link.state = new LeftIdleLinkState(link, mySprite);
            }
        }

        public void UseItem()
        {
            //Create a new item using state if an item is used before this one is done.
            link.state = new LeftItemUsingLinkState(link, mySprite);
        }

        public void Move(direction direction)
        {
            //no moving during attack
            /*switch (direction)
            {
                case direction.down:
                    //Change to down idles tate if told to move down.
                    link.state = new DownIdleLinkState(link, mySprite);
                    break;
                case direction.right:
                    //Change to a right idle state if told to move right.
                    link.state = new RightIdleLinkState(link, mySprite);
                    break;
                case direction.left:
                    //Change to a left moving state if told to move left.
                    link.state = new LeftMovingLinkState(link, mySprite);
                    break;
                case direction.up:
                    //Change to an up idle state if told to move up.
                    link.state = new UpIdleLinkState(link, mySprite);
                    break;
            }*/
        }
    }
}