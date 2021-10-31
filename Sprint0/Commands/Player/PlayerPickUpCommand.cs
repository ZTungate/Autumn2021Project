using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;
using Sprint2.Items;
using Sprint2.Player;

namespace Sprint2.Commands
{
    public class PlayerPickUpCommand : ICommand
    {
        private Game1 game;
        private AbstractItem myItem;
        public PlayerPickUpCommand(Game1 game, AbstractItem item)
        {
            this.game = game;
            myItem = item;
        }
        public void Execute()
        {
            game.link.PickUp(myItem);
        }
    }
}
