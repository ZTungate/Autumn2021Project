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

            //Player Movement
            this.controllerMappings.Add(Keys.Up, new PlayerUpMoveCommand(myGame));
            this.controllerMappings.Add(Keys.Right, new PlayerRightMoveCommand(myGame));
            this.controllerMappings.Add(Keys.Left, new PlayerLeftMoveCommand(myGame));
            this.controllerMappings.Add(Keys.Down, new PlayerDownMoveCommand(myGame));


            //Item Swapping
            this.controllerMappings.Add(Keys.U, new PreviousItemCommand(myGame));
            this.controllerMappings.Add(Keys.I, new NextItemCommand(myGame));

            //Enemy Swapping
            this.controllerMappings.Add(Keys.O, new PreviousEnemyCommand(myGame));
            this.controllerMappings.Add(Keys.P, new NextEnemyCommand(myGame));
        }

        KeyboardState state;
        public void Update()
        {
            KeyboardState lastState = state;
            state = Keyboard.GetState();
            Keys[] pressedKeys = state.GetPressedKeys();

            foreach (Keys key in pressedKeys) {
                if (controllerMappings.ContainsKey(key) && !lastState.IsKeyDown(key)) //commented out this section to test link movement
                {
                    controllerMappings[key].Execute();
                    
                    


                }
            }

            //Checks if movement controls are released to play the idle animation & stop movement
            checkPlayerIdle(lastState, state);


        }

        void checkPlayerIdle(KeyboardState lastState, KeyboardState state)
        {
            Keys[] oldPressedKeys = lastState.GetPressedKeys();
            foreach (Keys oldKey in oldPressedKeys)
            {
                switch (oldKey)
                {
                    case Keys.Up:
                        if (state.IsKeyUp(Keys.Up))
                        {
                            //UpIdleMovesprite
                            ICommand UpIdleCommand = new PlayerUpIdleCommand(myGame);
                            UpIdleCommand.Execute();
                        }
                        break;
                    case Keys.Right:
                        if (state.IsKeyUp(Keys.Right))
                        {
                            //RightIdleMoveSprite
                            ICommand rightIdleCommand = new PlayerRightIdleCommand(myGame);
                            rightIdleCommand.Execute();
                        }
                        break;
                    case Keys.Left:
                        if (state.IsKeyUp(Keys.Left))
                        {
                            //LeftIdleMoveSprite
                        }
                        break;
                    case Keys.Down:
                        if (state.IsKeyUp(Keys.Down))
                        {
                            //DownIdleMoveSprite
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
