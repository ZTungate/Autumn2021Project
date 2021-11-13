using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
	public interface ILinkState //Trying to implement using state pattern, NOT state machine
						   //http://web.cse.ohio-state.edu/~boggus.2/3902/slides/GoombaStateExample.cs
	{
		void Update(GameTime gameTime);
		//void TakeDamage();
		void UseItem(ProjectileTypes item);
		void SwordAttack();
		void Move(Direction direction);
		void Idle();
		void Die();
		void PickUp(AbstractItem item);

		//Damage should be implemented as a decorator on the player, not the state (look at notes on cse3902 homepage)
	}
}