using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
    public class PickUpLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;

        private int stateTime;
        public PickUpLinkState(ILink Link, ISprite sprite, AbstractItem item)
        {
            link = Link;
            mySprite = new PickUpLinkSprite(sprite.Texture, Link, item);
            mySprite.Color = sprite.Color;
            link.Sprite = mySprite;
            stateTime = LinkConstants.itemUseTime;
            link.SoundManager.sound.playFanfare();
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
            //Link is already using an item, do nothing.
        }

        public void SwordAttack()
        {
        }

        public void Move(Direction direction)
        {
            //Link can not move while throwing an item.
        }

        public void PickUp(AbstractItem item)
        {
            //No Implementation needed.
        }

        public void Idle()
        {
            //Link is busy, can't change to idle.
        }
        public void Die()
        {
            //Change link to a dead state
            link.State = new DeadLinkState(link, mySprite);
        }
    }
}