using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
    public class UpMovingLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;
        public UpMovingLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new UpMovingLinkSprite(sprite.Texture, link);
            link.sprite = mySprite;
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

        public void UseItem(ProjectileTypes item)
        {
            //Change link to an item using state.
            link.state = new UpItemUsingLinkState(link, mySprite, item);
        }

        public void SwordAttack()
        {
            link.state = new UpSwordLinkState(link, mySprite);
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
                    //Change to a right idle state if told to move right.
                    link.state = new RightIdleLinkState(link, mySprite);
                    break;
                case direction.left:
                    //Change to a left idle state if told to move left.
                    link.state = new LeftIdleLinkState(link, mySprite);
                    break;
                case direction.up:
                    //Current movement direction. No change required.
                    break;
            }
        }
        public void PickUp(AbstractItem item)
        {
            link.state = new PickUpLinkState(link, mySprite, item);
        }
    }
}