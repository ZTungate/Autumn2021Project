using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{
	public class RightIdleLinkState : ILinkState
	{
        private ILink link;
        private ISprite mySprite;
        public RightIdleLinkState(ILink Link, ISprite sprite)
		{
            link = Link;
            mySprite = new RightIdleLinkSprite(sprite.Texture, link);
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

        public void UseItem()
        {
            //Change link to an item using state.
            link.state = new RightItemUsingLinkState(link, mySprite);
        }
    }
}