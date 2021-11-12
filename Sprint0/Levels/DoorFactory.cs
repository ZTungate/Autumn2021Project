using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Poggus.Levels.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Poggus;

namespace Poggus.Levels
{
    public class DoorFactory
    {
        public static DoorFactory instance = new DoorFactory();
        Texture2D doorSpriteSheet;

        public Point doorSize, doorSizeScaled;

        public void LoadContent(ContentManager content)
        {
            doorSpriteSheet = content.Load<Texture2D>("DoorSpriteSheet");
            doorSize = new Point(32, 32);
        }
        public LevelDoor GetNewClosedDoor(Point pos, Point size, DoorDirectionEnum dir)
        {
            LevelDoor door = new LevelDoor(new DoorClosedSprite(doorSpriteSheet), dir, new Rectangle(pos,size));
            return door;
        }
        public LevelDoor GetNewOpenDoor(Point pos, Point size, DoorDirectionEnum dir)
        {
            LevelDoor door = new LevelDoor(new DoorOpenSprite(doorSpriteSheet), dir, new Rectangle(pos, size));
            return door;
        }
    }
}
