using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Sprint0.Projectiles.ProjectileConstants;

namespace Sprint2.Player
{
    public class LeftMovingLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;
        public LeftMovingLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new LeftMovingLinkSprite(sprite.Texture, link);
            link.sprite = mySprite;
            link.facing = direction.left;
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
            link.state = new LeftItemUsingLinkState(link, mySprite, item);
        }

        public void SwordAttack()
        {
            link.state = new LeftSwordLinkState(link, mySprite);
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
                    //Current movement direction. Do nothing.
                    break;
                case direction.up:
                    //Change to an up idle state if told to move up.
                    link.state = new UpIdleLinkState(link, mySprite);
                    break;
            }
        }
    }
}