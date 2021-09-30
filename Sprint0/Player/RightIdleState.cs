﻿using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{
	public class RightIdleState : IPlayerState
	{

        ISprite playerSprite;
		public RightIdleState()
		{
            playerSprite = LinkSpriteFactory.Instance.RightIdleLinkSprite(); //Initialize game with link facing right, idle.
		}


        public void Draw(SpriteBatch spriteBatch, Position pos)
        {
            //Draw the destination rectangle
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}