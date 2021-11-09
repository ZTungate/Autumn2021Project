using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Poggus
{
    class MouseController : IController
    {
        private MouseState oldState;
        private Game1 myGame;
        private Dictionary<Keys, ICommand> controllerMappings;

        public MouseController(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();

            myGame = game;

            setKeys();

        }
        private void setKeys()
        {
            this.controllerMappings.Add(Keys.D0, new Quit(myGame));

        }

        public void Update()
        {
            MouseState newState = Mouse.GetState();

            if (newState.RightButton == ButtonState.Released && oldState.RightButton == ButtonState.Pressed) { //quit tthe game
                controllerMappings[Keys.D0].Execute();
            }
            oldState = newState;
        }
    }
}
