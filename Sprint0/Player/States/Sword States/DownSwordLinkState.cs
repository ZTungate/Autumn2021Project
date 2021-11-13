using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
    public class DownSwordLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;

        private int stateTime;
        public DownSwordLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new DownSwordLinkSprite(sprite.Texture, Link);
            link.Sprite = mySprite;
            stateTime = LinkConstants.swordAttackTime;

            //Fire a sword beam if link is at full health
            if (link.FullHealth())
            {
                link.ProjectileFactory.NewSwordBeam(link.GetPosition(), Direction.down);
            }
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
                link.State = new DownIdleLinkState(link, mySprite);
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

        public void Move(Direction direction)
        {
            //No moving during attack
        }
        public void PickUp(AbstractItem item)
        {
            link.State = new PickUpLinkState(link, mySprite, item);
        }
    }
}