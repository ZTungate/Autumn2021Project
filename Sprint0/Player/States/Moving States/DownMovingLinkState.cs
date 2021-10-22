﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint3.Player
{
    public class DownMovingLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;
        public DownMovingLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new DownMovingLinkSprite(sprite.Texture, link);
            link.sprite = mySprite;
            link.facing = direction.down;
        }

        public void TakeDamage()
        {
            //Call on link to take damage. Does this need to be here? Might not be necesary in the state itself.
            link.takeDamage();
        }

        public void Update(GameTime gameTime)
        {
            //Nothing needs updated in an idle state?
        }

        public void UseItem()
        {
            //Change link to an item using state.
            link.state = new DownItemUsingLinkState(link, mySprite);
        }

        public void Move(direction direction)
        {
            //This is already a moving state, change to an idle state if a direction change is desired, othewise do nothing.
            switch (direction)
            {
                case direction.down:
                    //Current movement direction. Do nothing.
                    break;
                case direction.right:
                    //Change to a right idle state if told to move right.
                    link.state = new RightIdleLinkState(link, mySprite);
                    break;
                case direction.left:
                    //Change to a left idle state if told to move left.
                    link.state = new LeftIdleLinkState(link, mySprite);
                    break;
                case direction.up:
                    //Change to an up idle state if told to move up.
                    link.state = new UpIdleLinkState(link, mySprite);
                    break;
            }
        }
    }
}