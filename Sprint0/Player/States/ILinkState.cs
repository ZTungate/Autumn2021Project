using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace Sprint2.Player
{
	public interface ILinkState //Trying to implement using state pattern, NOT state machine
						   //http://web.cse.ohio-state.edu/~boggus.2/3902/slides/GoombaStateExample.cs
	{
		void Update(GameTime gameTime);
		void TakeDamage();
		void UseItem();

		//void ChangeDirection(direction direction);

		/*
		 * These will be used to change between the link states
		 * void moveForward();
		 * void standStill();
		 */
		//Damage should be implemented as a decorator on the player, not the state (look at notes on cse3902 homepage)
	}
}