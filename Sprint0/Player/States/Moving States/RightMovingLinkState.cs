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
            link.sprite = mySprite;
        }

        /*public void TakeDamage()
        {
            //Call on link to take damage. Does this need to be here? Might not be necesary in the state itself.
            link.TakeDamage();
        }*/

        public void Update(GameTime gameTime)
        {
            link.Move(new Point(LinkConstants.linkSpeed, 0));
        }

        public void UseItem(ProjectileTypes item)
        {
            //Change link to an item using state.
            link.state = new RightItemUsingLinkState(link, mySprite, item);
        }

        public void SwordAttack()
        {
            link.state = new RightSwordLinkState(link, mySprite);
        }
        public void Move(direction direction)
        {
            //This is already a moving state, change to an idle state if a direction change is desired, othewise do nothing.
            switch (direction)
            {
                case direction.down:
                    //Change to down idles tate if told to move down.
                    link.state = new DownIdleLinkState(link, mySprite);
                    break;
                case direction.right:
                    //Current movement direction, no change required.
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
        public void PickUp(AbstractItem item)
        {
            link.state = new PickUpLinkState(link, mySprite, item);
        }
    }
}