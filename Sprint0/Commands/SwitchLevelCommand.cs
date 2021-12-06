using System;
using System.Collections.Generic;
using System.Text;
using Poggus;
using Microsoft.Xna.Framework;

namespace Poggus
{
    public class SwitchLevelCommand : ICommand
    {
        private Game1 myGame;
        private Point dir;
        public SwitchLevelCommand(Game1 game, Point direction)
        {
            this.myGame = game;
            this.dir = direction;
        }
        public void Execute()
        {
            if (myGame.GetDungeon().HasDungeonAtNextDirection(dir) && !Main.Camera.main.IsMoving())
            {
                Main.Camera.main.BeginMoveTo(myGame.GetDungeon().GetCurrentLevel().GetPosition() + new Point(dir.X, -dir.Y) * myGame.GetDungeon().GetLevelSize(), 10);
                myGame.GetDungeon().SwitchLevel(dir);
                Rectangle linkRect = myGame.GetDungeon().GetCurrentLevel().GetLink().DestRect;

                Point linkNewPos = Point.Zero;
                Levels.LevelDoor oppositeDoor = null;
                if (dir == new Point(0, 1))
                {
                    oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(0, -1));
                    linkNewPos = new Point(oppositeDoor.destRect.X + oppositeDoor.destRect.Width / 2 - linkRect.Width / 2, oppositeDoor.destRect.Y - (linkRect.Height));
                }
                if (dir == new Point(1, 0))
                {
                    oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(-1, 0));
                    linkNewPos = new Point(oppositeDoor.destRect.X + oppositeDoor.destRect.Width, oppositeDoor.destRect.Y + oppositeDoor.destRect.Height / 2 - linkRect.Height / 2);
                }
                if (dir == new Point(0, -1))
                {
                    oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(0, 1));
                    linkNewPos = new Point(oppositeDoor.destRect.X + oppositeDoor.destRect.Width / 2 - linkRect.Width / 2, oppositeDoor.destRect.Y + oppositeDoor.destRect.Height - linkRect.Height/2 + 5);
                }
                if (dir == new Point(-1, 0))
                {
                    oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(1, 0));
                    linkNewPos = new Point(oppositeDoor.destRect.X - (linkRect.Width), oppositeDoor.destRect.Y + oppositeDoor.destRect.Height / 2 - linkRect.Height / 2);
                }
                myGame.GetDungeon().GetCurrentLevel().GetLink().SetPosition(linkNewPos);
            }
        }
    }
}
