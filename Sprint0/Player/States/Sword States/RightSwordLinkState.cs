using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player;
using System;
using static Sprint0.Projectiles.ProjectileConstants;

namespace Sprint2.Player
{
	public class RightSwordLinkState : ILinkState
	{
        private ILink link;
        private ISprite mySprite;

        private int stateTime;
        public RightSwordLinkState(ILink Link, ISprite sprite)
		{
            link = Link;
            mySprite = new RightSwordLinkSprite(sprite.Texture, Link);
            //TODO: make sword beam only come out if link full health
            link.ProjectileFactory.NewSwordBeam(link.position, direction.right);

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
            if(stateTime > 0)
            {
                stateTime -= gameTime.ElapsedGameTime.Milliseconds;
            }
            else
            {
                //If the timer is up for this state, revert to an idle state for this direction
                link.state = new RightIdleLinkState(link,mySprite);
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
            //No moving during sword attack
        }
    }
}