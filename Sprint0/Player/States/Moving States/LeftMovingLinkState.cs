using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
    public class LeftMovingLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;
        public LeftMovingLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new LeftMovingLinkSprite(sprite.Texture, link);
            mySprite.Color = sprite.Color;
            link.Sprite = mySprite;
        }
        public void Update(GameTime gameTime)
        {
            link.Move(new Point(-LinkConstants.linkSpeed, 0));
        }

        public void UseItem(ProjectileTypes item)
        {
            //Change link to an item using state.
            link.State = new LeftItemUsingLinkState(link, mySprite, item);
        }

        public void SwordAttack()
        {
            link.State = new LeftSwordLinkState(link, mySprite);
        }
        public void Move(Direction direction)
        {
            //This is already a moving state, change to an idle state if a direction change is desired, othewise do nothing.
            switch (direction)
            {
                case Direction.down:
                    //Change to down idles tate if told to move down.
                    link.State = new DownIdleLinkState(link, mySprite);
                    break;
                case Direction.right:
                    //Change to a right idle state if told to move right.
                    link.State = new RightIdleLinkState(link, mySprite);
                    break;
                case Direction.left:
                    //Current movement direction. Do nothing.
                    break;
                case Direction.up:
                    //Change to an up idle state if told to move up.
                    link.State = new UpIdleLinkState(link, mySprite);
                    break;
            }
        }
        public void Idle()
        {
            //Change link to an idle state in the current direction.
            link.State = new LeftIdleLinkState(link, mySprite);
        }

        public void Die()
        {
            //Change link to a dead state
            link.State = new DeadLinkState(link, mySprite);
        }
        public void PickUp(AbstractItem item)
        {
            link.State = new PickUpLinkState(link, mySprite, item);
        }
    }
}