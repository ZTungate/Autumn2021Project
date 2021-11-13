﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
    public class LeftIdleLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;
        public LeftIdleLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new LeftIdleLinkSprite(sprite.Texture, link);
            link.Sprite = mySprite;
        }

        public void Update(GameTime gameTime)
        {
            //Nothing needs updated in an idle state?
        }

        public void UseItem(ProjectileTypes item)
        {
            link.State = new LeftItemUsingLinkState(link, mySprite, item);
        }

        public void SwordAttack()
        {
            link.State = new LeftSwordLinkState(link, mySprite);
        }

        public void Move(Direction direction)
        {
            //If told to move in the direction this state is facing, switch to a moving state. Otherwise, switch to an idle state in that direction.
            switch (direction)
            {
                case Direction.down:
                    //Change to down idle if told to move down.
                    link.State = new DownIdleLinkState(link, mySprite);
                    break;
                case Direction.right:
                    //Change to a right idle state if told to move right
                    link.State = new RightIdleLinkState(link, mySprite);
                    break;
                case Direction.left:
                    //Change to a left moving state if told to move left
                    link.State = new LeftMovingLinkState(link, mySprite);
                    break;
                case Direction.up:
                    //Change to an up idle state if told to move up
                    link.State = new UpIdleLinkState(link, mySprite);
                    break;
            }
        }
        public void Idle()
        {
            //Already idle, no implementation needed
        }
        public void Die()
        {
            //Chane link to a dead state
            link.State = new DeadLinkState(link, mySprite);
        }
        public void PickUp(AbstractItem item)
        {
            //No Implementation needed.
        }
    }
}