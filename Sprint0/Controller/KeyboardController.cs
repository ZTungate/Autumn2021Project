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


            setKeys(myGame.link);

        }
        private void setKeys(Player.ILink link)
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
            this.controllerMappings.Add(Keys.D1, new PlayerRightUseItemCommand(myGame));
            this.controllerMappings.Add(Keys.N, new PlayerRightSwordCommand(myGame));


            //Item Swapping
            this.controllerMappings.Add(Keys.U, new PreviousItemCommand(myGame));
            this.controllerMappings.Add(Keys.I, new NextItemCommand(myGame));

            //Enemy Swapping
            this.controllerMappings.Add(Keys.O, new PreviousEnemyCommand(myGame));
            this.controllerMappings.Add(Keys.P, new NextEnemyCommand(myGame));

            //Block Swapping
            this.controllerMappings.Add(Keys.T, new PreviousBlockCommand(myGame));
            this.controllerMappings.Add(Keys.Y, new NextBlockCommand(myGame));
        }

        KeyboardState state;
        public void Update()
        {
            KeyboardState lastState = state;
            state = Keyboard.GetState();
            Keys[] pressedKeys = state.GetPressedKeys();

            checkPlayerIdle(lastState, state);

            foreach (Keys key in pressedKeys) {
                if (controllerMappings.ContainsKey(key) && !lastState.IsKeyDown(key)) //commented out this section to test link movement
                {
                    controllerMappings[key].Execute();
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
