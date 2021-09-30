using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Sprint2.Commands;

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

            //Create commands to change sprites
            this.controllerMappings.Add(Keys.D0, new Quit(myGame));
            this.controllerMappings.Add(Keys.D1, new DisplayNonAniNonMovSprite(myGame));
            this.controllerMappings.Add(Keys.D2, new DisplayAniNonMovSprite(myGame));
            this.controllerMappings.Add(Keys.D3, new DisplayNonAniMovSprite(myGame));
            this.controllerMappings.Add(Keys.D4, new DisplayAniMovSprite(myGame));

            this.controllerMappings.Add(Keys.U, new PreviousItemCommand(myGame));
            this.controllerMappings.Add(Keys.I, new NextItemCommand(myGame));
        }

        KeyboardState state;
        public void Update()
        {
            KeyboardState lastState = state;
            state = Keyboard.GetState();
            Keys[] pressedKeys = state.GetPressedKeys();

            foreach (Keys key in pressedKeys) {
                if (controllerMappings.ContainsKey(key) && !lastState.IsKeyDown(key))
                {
                    controllerMappings[key].Execute();
                }
            }
        }
    }
}
