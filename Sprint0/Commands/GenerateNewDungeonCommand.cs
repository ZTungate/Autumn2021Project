using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;
namespace Poggus.Commands
{
    public class GenerateNewDungeonCommand : ICommand
    {
        private Game1 game;
        public GenerateNewDungeonCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.TempGenerateNewDungeon();
        }
    }
}
