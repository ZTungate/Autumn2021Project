using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;
using Poggus.Items;
using Poggus.Player;

namespace Poggus.Commands
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
            if(myItem is TriforcePieceItem)
            {
                game.toggleWin();
            }
            //game.link.LinkInventory.AddItem(myItem); might work?
        }
    }
}
