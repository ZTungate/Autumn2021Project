using System;
using System.Collections.Generic;
using System.Text;
using Poggus;
using Microsoft.Xna.Framework;

namespace Poggus
{
    public class SwitchLevelCommand : ICommand
    {
        private Game1 game;
        private Point direction;
        public SwitchLevelCommand(Game1 game, Point direction)
        {
            this.game = game;
            this.direction = direction;
        }
        public void Execute()
        {
            game.GetDungeon().SwitchLevel(direction);
        }
    }
}
