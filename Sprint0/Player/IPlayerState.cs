using System;
namespace Player
{
	interface IPlayerState
	{
		void ChangeDirection();
		void ChangeWalkingState(); // Meant to switch to/from "idling" (standing still) and walking
		void Update();
	}
}