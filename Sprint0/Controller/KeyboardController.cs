using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Sprint2
{
    class KeyboardController : IController
    {
        private Game1 myGame;
        private Dictionary<Keys, ICommand> controllerMappings;

        public KeyboardController(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();

            myGame = game;

            setKeys();

        }
        private void setKeys()
        {
            this.controllerMappings.Add(Keys.D0, new Quit(myGame));
            this.controllerMappings.Add(Keys.D1, new DisplayNonAniNonMovSprite(myGame));
            this.controllerMappings.Add(Keys.D2, new DisplayAniNonMovSprite(myGame));
            this.controllerMappings.Add(Keys.D3, new DisplayNonAniMovSprite(myGame));
            this.controllerMappings.Add(Keys.D4, new DisplayAniMovSprite(myGame));

        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys) {
                if (controllerMappings.ContainsKey(key)) {
                    controllerMappings[key].Execute();
                }
            }
        }
    }
}
