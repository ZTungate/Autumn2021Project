using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace Sprint2.Player
{
	public interface ILinkState //Trying to implement using state pattern, NOT state machine
						   //http://web.cse.ohio-state.edu/~boggus.2/3902/slides/GoombaStateExample.cs
	{
		void Update(GameTime gameTime);
		void takeDamage();
		void useItem(Game1 game);

		/*
		 * void turnLeft();
		 * void turnRight();
		 * void turnUp();
		 * void turnDown(); for what
		 * void RegBoomerangAttack();
	     * void BlueBoomerangAttack();
         * void RegArrowAttack();
         * void BlueArrowAttack();
         * void BombAttack();
         * void FireAttack();
		 */
		//Damage should be implemented as a decorator on the player, not the state (look at notes on cse3902 homepage)
	}
}