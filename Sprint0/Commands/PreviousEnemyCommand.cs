using System;
using System.Collections.Generic;
using System.Text;
using Sprint3.Helpers;
namespace Sprint3.Commands
{
    public class PreviousEnemyCommand : ICommand
    {
        private Game1 game;
        public PreviousEnemyCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currentEnemy = CustomMath.MathMod(this.game.currentEnemy - 1, this.game.enemies.Count);
        }
    }
}
