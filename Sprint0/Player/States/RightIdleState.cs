using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{
	public class RightIdleState : IPlayerState
	{

		public RightIdleState()
		{
            //playerSprite = LinkSpriteFactory.Instance.RightIdleLinkSprite(position); //Initialize game with link facing right, idle.
		}


        public void Draw(SpriteBatch spriteBatch)
        {
            // Does the state need a Draw() function?
            throw new NotImplementedException();
        }

        public void Update()
        {
            //What needs to be updated in the State?
            throw new NotImplementedException();
        }
    }
}