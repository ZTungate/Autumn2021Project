using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Poggus.Commands;
using Poggus.Items;

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
            };

        }
        private void SetKeys(Player.ILink link)
        {

            //Create commands to change sprites
            this.controllerMappings.Add(Keys.Q, new Quit(myGame));
            this.controllerMappings.Add(Keys.R, new ResetCommand(myGame));
            this.controllerMappings.Add(Keys.J, new GenerateNewDungeonCommand(myGame));

            //Player Movement
            
            this.controllerMappings.Add(Keys.W, new PlayerUpMoveCommand(myGame));
            
            this.controllerMappings.Add(Keys.D, new PlayerRightMoveCommand(myGame));
            
            this.controllerMappings.Add(Keys.A, new PlayerLeftMoveCommand(myGame));
            
            this.controllerMappings.Add(Keys.S, new PlayerDownMoveCommand(myGame));

            //Player Controls


            /* Debug commands
            this.controllerMappings.Add(Keys.E, new PlayerTakeDamageCommand(myGame));
            this.controllerMappings.Add(Keys.D1, new PlayerUseRegBoomerangCommand(myGame));
            this.controllerMappings.Add(Keys.D2, new PlayerUseBlueBoomerangCommand(myGame));
            this.controllerMappings.Add(Keys.D3, new PlayerUseRegArrowCommand(myGame));
            this.controllerMappings.Add(Keys.D4, new PlayerUseBlueArrowCommand(myGame));
            this.controllerMappings.Add(Keys.D5, new PlayerUseBombCommand(myGame));
            this.controllerMappings.Add(Keys.D6, new PlayerUseFireCommand(myGame));
            */
            this.controllerMappings.Add(Keys.NumPad8, new SwitchLevelCommand(myGame, new Point(0, 1)));
            this.controllerMappings.Add(Keys.NumPad6, new SwitchLevelCommand(myGame, new Point(1, 0)));
            this.controllerMappings.Add(Keys.NumPad2, new SwitchLevelCommand(myGame, new Point(0, -1)));
            this.controllerMappings.Add(Keys.NumPad4, new SwitchLevelCommand(myGame, new Point(-1, 0)));
            
            this.controllerMappings.Add(Keys.Tab, new HUDToggleCommand(myGame));
            
            //GAME CONTROLS
            this.controllerMappings.Add(Keys.P, new PauseCommand(myGame));
            this.controllerMappings.Add(Keys.M, new ToggleSoundCommand(myGame));
            this.controllerMappings.Add(Keys.Left, new MenuLeftCommand(myGame));
            this.controllerMappings.Add(Keys.Down, new MenuDownCommand(myGame));
            this.controllerMappings.Add(Keys.Right, new MenuRightCommand(myGame));
            this.controllerMappings.Add(Keys.Up, new MenuUpCommand(myGame));
            this.controllerMappings.Add(Keys.Enter, new MenuEnterCommand(myGame));
            this.controllerMappings.Add(Keys.Back, new MenuBackCommand(myGame));
            
        }

        KeyboardState state;
        public void Update()
        {
            KeyboardState lastState = state;
            state = Keyboard.GetState();
            Keys[] pressedKeys = state.GetPressedKeys();


            if (!myGame.Paused() && !myGame.inventoryOpen) {
                if (!myGame.link.movingTo) {
                    checkPlayerIdle(lastState, state);

                    foreach (Keys key in pressedKeys) {
                        if (controllerMappings.ContainsKey(key) && !lastState.IsKeyDown(key)) {
                            //If this key is bound to a command, and was not down last tick, execute the relevant command.
                            controllerMappings[key].Execute();
                        }
                        else if (controllerMappings.ContainsKey(key) && movementKeys.Contains(key)) {
                            //If this key is pressed, was pressed last tick, and is a movement key, execute the command.
                            controllerMappings[key].Execute();
                        }
                        if (state.IsKeyDown(Keys.Z) && !lastState.IsKeyDown(Keys.Z)) {
                            executeItem(myGame.link.LinkInventory.getSlotA());
                        }
                        if (state.IsKeyDown(Keys.X) && !lastState.IsKeyDown(Keys.X)) {
                            executeItem(myGame.link.LinkInventory.getSlotB());
                        }
                    }
                }
                else {
                    if (state.IsKeyDown(Keys.P) && !lastState.IsKeyDown(Keys.P)) {
                        controllerMappings[Keys.P].Execute();
                    }
                    if (state.IsKeyDown(Keys.Tab) && !lastState.IsKeyDown(Keys.Tab)) {
                        controllerMappings[Keys.Tab].Execute();
                    }
                }
            }
            else {
                if (myGame.Paused()) {
                    if (state.IsKeyDown(Keys.P) && !lastState.IsKeyDown(Keys.P)) {
                        controllerMappings[Keys.P].Execute();
                    }
                    if (state.IsKeyDown(Keys.Tab) && !lastState.IsKeyDown(Keys.Tab)) {
                        controllerMappings[Keys.Tab].Execute();
                    }
                    if (state.IsKeyDown(Keys.Up) && !lastState.IsKeyDown(Keys.Up)) {
                        controllerMappings[Keys.Up].Execute();
                    }
                    if (state.IsKeyDown(Keys.Down) && !lastState.IsKeyDown(Keys.Down)) {
                        controllerMappings[Keys.Down].Execute();
                    }
                    if (state.IsKeyDown(Keys.Right) && !lastState.IsKeyDown(Keys.Right)) {
                        controllerMappings[Keys.Right].Execute();
                    }
                    if (state.IsKeyDown(Keys.Left) && !lastState.IsKeyDown(Keys.Left)) {
                        controllerMappings[Keys.Left].Execute();
                    }
                    if (state.IsKeyDown(Keys.Enter) && !lastState.IsKeyDown(Keys.Enter)) {
                        controllerMappings[Keys.Enter].Execute();
                    }
                    if (state.IsKeyDown(Keys.Back) && !lastState.IsKeyDown(Keys.Back)) {
                        controllerMappings[Keys.Back].Execute();
                    }
                    if (state.IsKeyDown(Keys.Q) && !lastState.IsKeyDown(Keys.Q)) {
                        controllerMappings[Keys.Q].Execute();
                    }
                }
                if (myGame.inventoryOpen) {
                    if (state.IsKeyDown(Keys.W) && !lastState.IsKeyDown(Keys.W)) {
                        new InventoryUpCommand(myGame).Execute();
                    }
                    if (state.IsKeyDown(Keys.S) && !lastState.IsKeyDown(Keys.S)) {
                        new InventoryDownCommand(myGame).Execute();
                    }
                    if (state.IsKeyDown(Keys.D) && !lastState.IsKeyDown(Keys.D)) {
                        new InventoryRightCommand(myGame).Execute();
                    }
                    if (state.IsKeyDown(Keys.A) && !lastState.IsKeyDown(Keys.A)) {
                        new InventoryLeftCommand(myGame).Execute();
                    }
                    if (state.IsKeyDown(Keys.X) && !lastState.IsKeyDown(Keys.X)) {
                        new InventorySelectCommand(myGame).Execute();
                    }
                }
            }
                
            //Checks if movement controls are released to play the idle animation & stop movement
        }
        private void executeItem(AbstractItem item)
        {
            if (item is SwordItem) {
                new PlayerSwordCommand(myGame).Execute();
            }
            else if (item is BombItem) {
                new PlayerUseBombCommand(myGame).Execute();
            }
            else if (item is BowItem) {
                new PlayerUseRegArrowCommand(myGame).Execute();
            }
            else if (item is BoomerangItem) {
                new PlayerUseRegBoomerangCommand(myGame).Execute();
            }
        }
        void checkPlayerIdle(KeyboardState lastState, KeyboardState state)
        {
            Keys[] oldPressedKeys = lastState.GetPressedKeys();
            foreach (Keys oldKey in oldPressedKeys)
            {
                switch (oldKey)
                {


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
