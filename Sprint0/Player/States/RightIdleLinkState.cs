using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{
	public class RightIdleLinkState : ILinkState
	{
        private ILink link;
        private ISprite sprite;
        public RightIdleLinkState(ILink Link, ISprite sprite)
		{
            this.link = Link;
            this.sprite = sprite;
        }

        public void takeDamage()
        {
            //Call on link to take damage. Does this need to be here? Might not be necesary in the state itself.
            link.takeDamage();
        }

        public void Update(GameTime gameTime)
        {
            //What needs to be updated in the State?

        }

        public void useItem(Game1 game)
        {
            game.link.sprite = game.linkSpriteFactory.RightUseItemLinkSprite(game.link);
        }
    }
}