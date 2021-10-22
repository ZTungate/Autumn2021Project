using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{
    public class DownItemUsingLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;

        private int stateTime;
        public DownItemUsingLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new DownUseItemLinkSprite(sprite.Texture, Link);
            link.sprite = mySprite;
            stateTime = 300; //300 miliseconds of time to be throwing the projectile
            link.facing = direction.down;
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
                link.state = new DownIdleLinkState(link, mySprite);
            }
        }

        public void UseItem()
        {
            //Link is already using an item, do nothing.
        }

        public void SwordAttack()
        {
            link.state = new DownSwordLinkState(link, mySprite);
        }

        public void Move(direction direction)
        {
            //Link can not move while throwing an item.
        }
    }
}