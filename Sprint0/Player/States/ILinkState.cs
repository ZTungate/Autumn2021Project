using Microsoft.Xna.Framework.Graphics;
using System;
namespace Sprint2.Player
{
	public interface ILinkState //Trying to implement using state pattern, NOT state machine
						   //http://web.cse.ohio-state.edu/~boggus.2/3902/slides/GoombaStateExample.cs
	{
		void Update();
		void takeDamage();

		void useItem(Game1 game);
		//Damage should be implemented as a decorator on the player, not the state (look at notes on cse3902 homepage)
	}
}