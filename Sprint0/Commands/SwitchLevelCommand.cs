using System;
using System.Collections.Generic;
using System.Text;
using Poggus;
using Microsoft.Xna.Framework;

namespace Poggus
{
    public class SwitchLevelCommand : ICommand
    {
        private Game1 game;
        private Point direction;
        public SwitchLevelCommand(Game1 game, Point direction)
        {
            this.game = game;
            this.direction = direction;
        }
        public void Execute()
        {
            if (game.GetDungeon().HasDungeonAtNextDirection(direction) && !Main.Camera.main.IsMoving())
            {
                Main.Camera.main.BeginMoveTo(game.GetDungeon().GetCurrentLevel().GetPosition() + new Point(direction.X, -direction.Y) * game.GetDungeon().GetLevelSize(), 10);
                game.GetDungeon().SwitchLevel(direction);
                Rectangle linkRect = game.GetDungeon().GetCurrentLevel().GetLink().DestRect;

                Point linkNewPos = Point.Zero;
                if (direction == new Point(0, 1))
                {
                    Levels.LevelDoor oppositeDoor = game.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(0, -1));
                    linkNewPos = new Point(oppositeDoor.destRect.X + oppositeDoor.destRect.Width / 2 - linkRect.Width / 2, oppositeDoor.destRect.Y - (linkRect.Height));
                }
                if (direction == new Point(1, 0))
                {
                    Levels.LevelDoor oppositeDoor = game.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(-1, 0));
                    linkNewPos = new Point(oppositeDoor.destRect.X + oppositeDoor.destRect.Width, oppositeDoor.destRect.Y + oppositeDoor.destRect.Height / 2 - linkRect.Height / 2);
                }
                if (direction == new Point(0, -1))
                {
                    Levels.LevelDoor oppositeDoor = game.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(0, 1));
                    linkNewPos = new Point(oppositeDoor.destRect.X + oppositeDoor.destRect.Width / 2 - linkRect.Width / 2, oppositeDoor.destRect.Y + oppositeDoor.destRect.Height);
                }
                if (direction == new Point(-1, 0))
                {
                    Levels.LevelDoor oppositeDoor = game.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(1, 0));
                    linkNewPos = new Point(oppositeDoor.destRect.X - (linkRect.Width), oppositeDoor.destRect.Y + oppositeDoor.destRect.Height / 2 - linkRect.Height / 2);
                }
                game.GetDungeon().GetCurrentLevel().GetLink().SetPosition(linkNewPos);
            }
        }
    }
}
