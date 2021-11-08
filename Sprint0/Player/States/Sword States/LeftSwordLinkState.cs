using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
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
            //TODO: make sword beam only come out if link full health
            link.ProjectileFactory.NewSwordBeam(link.GetPosition(), direction.left);
            link.sprite = mySprite;
            stateTime = LinkConstants.swordAttackTime;
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
                link.state = new LeftIdleLinkState(link, mySprite);
            }
        }

        public void UseItem(ProjectileTypes item)
        {
            //Link is already attacking, do nothing.
        }

        public void SwordAttack()
        {
            //Link can not stab while already stabbing.
        }

        public void Move(direction direction)
        {
            //no moving during attack
        }
        public void PickUp(AbstractItem item)
        {
            link.state = new PickUpLinkState(link, mySprite, item);
        }
    }
}