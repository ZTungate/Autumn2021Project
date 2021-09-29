using System;
namespace Sprint2.Player
{
	public interface IPlayerState //Trying to implement using state pattern, NOT state machine
						   //http://web.cse.ohio-state.edu/~boggus.2/3902/slides/GoombaStateExample.cs
	{
 // Meant to switch to/from "idling" (standing still) and walking
		void Update();
		void Draw();
		//Damage should be implemented as a decorator on the player, not the state (look at notes on cse3902 homepage)
	}
}