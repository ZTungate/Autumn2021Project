using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Poggus.Commands;

namespace Poggus
{
    class KeyboardController : IController
    {
        private Game1 myGame;
        private Dictionary<Keys, ICommand> controllerMappings;
        private List<Keys> movementKeys;

        public KeyboardController(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();

            myGame = game;


            SetKeys(myGame.link);

            //Create a new list to hold the keys relevant to movement.
            movementKeys = new List<Keys>
            {
                Keys.W,
                Keys.A,
                Keys.S,
                Keys.D,
                Keys.Up,
                Keys.Left,
                Keys.Down,
                Keys.Right
            };

        }
        private void SetKeys(Player.ILink link)
        {

            //Create commands to change sprites
            this.controllerMappings.Add(Keys.Q, new Quit(myGame));
            this.controllerMappings.Add(Keys.R, new ResetCommand(myGame));

            //Player Movement
            this.controllerMappings.Add(Keys.Up, new PlayerUpMoveCommand(myGame));
            this.controllerMappings.Add(Keys.W, new PlayerUpMoveCommand(myGame));
            this.controllerMappings.Add(Keys.Right, new PlayerRightMoveCommand(myGame));
            this.controllerMappings.Add(Keys.D, new PlayerRightMoveCommand(myGame));
            this.controllerMappings.Add(Keys.Left, new PlayerLeftMoveCommand(myGame));
            this.controllerMappings.Add(Keys.A, new PlayerLeftMoveCommand(myGame));
            this.controllerMappings.Add(Keys.Down, new PlayerDownMoveCommand(myGame));
            this.controllerMappings.Add(Keys.S, new PlayerDownMoveCommand(myGame));

            //Player Controls
            this.controllerMappings.Add(Keys.E, new PlayerTakeDamageCommand(myGame));
            this.controllerMappings.Add(Keys.D1, new PlayerUseRegBoomerangCommand(myGame));
            this.controllerMappings.Add(Keys.D2, new PlayerUseBlueBoomerangCommand(myGame));
            this.controllerMappings.Add(Keys.D3, new PlayerUseRegArrowCommand(myGame));
            this.controllerMappings.Add(Keys.D4, new PlayerUseBlueArrowCommand(myGame));
            this.controllerMappings.Add(Keys.D5, new PlayerUseBombCommand(myGame));
            this.controllerMappings.Add(Keys.D6, new PlayerUseFireCommand(myGame));
            this.controllerMappings.Add(Keys.N, new PlayerSwordCommand(myGame));
            this.controllerMappings.Add(Keys.Z, new PlayerSwordCommand(myGame));
            this.controllerMappings.Add(Keys.P, new PauseCommand(myGame));

            this.controllerMappings.Add(Keys.NumPad8, new SwitchLevelCommand(myGame, new Point(0, 1)));
            this.controllerMappings.Add(Keys.NumPad6, new SwitchLevelCommand(myGame, new Point(1, 0)));
            this.controllerMappings.Add(Keys.NumPad2, new SwitchLevelCommand(myGame, new Point(0, -1)));
            this.controllerMappings.Add(Keys.NumPad4, new SwitchLevelCommand(myGame, new Point(-1, 0)));
        }

        KeyboardState state;
        public void Update()
        {

            KeyboardState lastState = state;
            state = Keyboard.GetState();
            Keys[] pressedKeys = state.GetPressedKeys();
            if (!myGame.Paused())
            {
                checkPlayerIdle(lastState, state);

                foreach (Keys key in pressedKeys)
                {
                    if (controllerMappings.ContainsKey(key) && !lastState.IsKeyDown(key))
                    {
                        //If this key is bound to a command, and was not down last tick, execute the relevant command.
                        controllerMappings[key].Execute();
                    }
                    else if (controllerMappings.ContainsKey(key) && movementKeys.Contains(key))
                    {
                        //If this key is pressed, was pressed last tick, and is a movement key, execute the command.
                        controllerMappings[key].Execute();
                    }
                }
            }
            else
            {
                if (state.IsKeyDown(Keys.P) && !lastState.IsKeyDown(Keys.P))
                {
                    controllerMappings[Keys.P].Execute();
                }
            }
            //Checks if movement controls are released to play the idle animation & stop movement
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
                            ICommand leftIdleCommand = new PlayerLeftIdleCommand(myGame);
                            leftIdleCommand.Execute();
                        }
                        break;
                    case Keys.Down:
                        if (state.IsKeyUp(Keys.Down))
                        {
                            //DownIdleMoveSprite
                            ICommand downIdleCommand = new PlayerDownIdleCommand(myGame);
                            downIdleCommand.Execute();

                        }
                        break;


                    case Keys.W:
                        if (state.IsKeyUp(Keys.W))
                        {
                            //UpIdleMovesprite
                            ICommand UpIdleCommand = new PlayerUpIdleCommand(myGame);
                            UpIdleCommand.Execute();
                        }
                        break;
                    case Keys.D:
                        if (state.IsKeyUp(Keys.D))
                        {
                            //RightIdleMoveSprite
                            ICommand rightIdleCommand = new PlayerRightIdleCommand(myGame);
                            rightIdleCommand.Execute();
                        }
                        break;
                    case Keys.A:
                        if (state.IsKeyUp(Keys.A))
                        {
                            //LeftIdleMoveSprite
                            ICommand leftIdleCommand = new PlayerLeftIdleCommand(myGame);
                            leftIdleCommand.Execute();
                        }
                        break;
                    case Keys.S:
                        if (state.IsKeyUp(Keys.S))
                        {
                            //DownIdleMoveSprite
                            ICommand downIdleCommand = new PlayerDownIdleCommand(myGame);
                            downIdleCommand.Execute();

                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
