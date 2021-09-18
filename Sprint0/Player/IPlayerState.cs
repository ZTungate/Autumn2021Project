using System;
namespace Player
{
	interface IPlayerState //Trying to implement using state pattern, NOT state machine
						   //http://web.cse.ohio-state.edu/~boggus.2/3902/slides/GoombaStateExample.cs
	{
		void ChangeDirection();
		void ChangeWalkingState(); // Meant to switch to/from "idling" (standing still) and walking
		void Update();
		//Damage should be implemented as a decorator on the player, not the state (look at notes on cse3902 homepage)
	}
}