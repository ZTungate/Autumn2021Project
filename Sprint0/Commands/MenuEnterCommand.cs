namespace Poggus
{
    public class MenuEnterCommand : ICommand
    {
        Game1 game;
        public MenuEnterCommand(Game1 game1)
        {
            this.game = game1;
        }
        public void Execute()
        {
            if (game.Paused())
            {
                game.menuHandler.executeButton();
            }

        }
    }
}