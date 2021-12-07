namespace Poggus
{
    public class MenuBackCommand : ICommand
    {
        Game1 game;
        public MenuBackCommand(Game1 game1)
        {
            this.game = game1;
        }
        public void Execute()
        {
            if (game.Paused())
            {
                if (game.menuHandler.options)
                {
                    game.menuHandler.toggleOptions();
                }
            }

        }
    }
}