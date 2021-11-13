using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
    public class DownMovingLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;
        public DownMovingLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new DownMovingLinkSprite(sprite.Texture, link);
            link.Sprite = mySprite;
        }

/*        public void TakeDamage()
        {
            //Call on link to take damage. Does this need to be here? Might not be necesary in the state itself.
            link.TakeDamage();
        }*/

        public void Update(GameTime gameTime)
        {
            //Move link down
            link.Move(new Point(0, LinkConstants.linkSpeed));
        }

        public void UseItem(ProjectileTypes item)
        {
            //Change link to an item using state.
            link.State = new DownItemUsingLinkState(link, mySprite,item);
        }

        public void SwordAttack()
        {
            link.State = new DownSwordLinkState(link, mySprite);
        }

        public void Move(Direction direction)
        {
            //This is already a moving state, change to an idle state if a direction change is desired, othewise do nothing.
            switch (direction)
            {
                case Direction.down:
                    //Current movement direction. Do nothing.
                    break;
                case Direction.right:
                    //Change to a right idle state if told to move right.
                    link.State = new RightIdleLinkState(link, mySprite);
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
        public void PickUp(AbstractItem item)
        {
            link.State = new PickUpLinkState(link, mySprite, item);
        }
    }
}