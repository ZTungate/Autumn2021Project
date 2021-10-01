using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class NextEnemyCommand : ICommand
    {
        private Game1 game;
        public NextEnemyCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currentEnemy = CustomMath.MathMod(this.game.currentEnemy + 1, this.game.enemies.Count);
        }
    }
}
