using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{
	public class RightState : ILinkState
	{
        private ILink link;
		public RightState(ILink Link)
		{
            this.link = Link;
 
            //playerSprite = LinkSpriteFactory.Instance.RightIdleLinkSprite(position); //Initialize game with link facing right, idle.
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // Does the state need a Draw() function?
            throw new NotImplementedException();
        }

        public void takeDamage()
        {
            throw new NotImplementedException();
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