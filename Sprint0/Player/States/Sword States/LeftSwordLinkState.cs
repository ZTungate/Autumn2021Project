using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;
using Poggus.Helpers;
using Poggus.Projectiles;

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
            mySprite.Color = sprite.Color;
            link.Sprite = mySprite;
            stateTime = LinkConstants.swordAttackTime;

            link.ProjectileFactory.NewStab(LocationHelpers.GetLocationCenteredSpawnLeft(link.DestRect, ProjectileConstants.horizSwordBeamSize), Direction.left);

            //Fire a sword beam if link is at full health
            if (link.FullHealth())
            {
                link.ProjectileFactory.NewSwordBeam(LocationHelpers.GetLocationCenteredSpawnLeft(link.DestRect, ProjectileConstants.horizSwordBeamSize), Direction.left);
                link.SoundManager.sound.playSwordCombined();
            }
            else {
                link.SoundManager.sound.playSwordSlash();
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
                link.State = new LeftIdleLinkState(link, mySprite);
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
            //no moving during attack
        }

        public void Idle()
        {
            //Link can not force an idle transition in a sword state
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