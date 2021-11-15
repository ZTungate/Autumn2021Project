using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
	public class RightMovingLinkState : ILinkState
	{
        private ILink link;
        private ISprite mySprite;
        public RightMovingLinkState(ILink Link, ISprite sprite)
		{
            link = Link;
            mySprite = new RightMovingLinkSprite(sprite.Texture, link);
            mySprite.Color = sprite.Color;
            link.Sprite = mySprite;
        }
        public void Update(GameTime gameTime)
        {
            link.Move(new Point(LinkConstants.linkSpeed, 0));
        }

        public void UseItem(ProjectileTypes item)
        {
            //Change link to an item using state.
            link.State = new RightItemUsingLinkState(link, mySprite, item);
        }

        public void SwordAttack()
        {
            link.State = new RightSwordLinkState(link, mySprite);
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
                    //Current movement direction, no change required.
                    break;
                case Direction.left:
                    //Change to a left idle state if told to move left.
                    link.State = new LeftIdleLinkState(link, mySprite);
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
            link.State = new RightIdleLinkState(link, mySprite);
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