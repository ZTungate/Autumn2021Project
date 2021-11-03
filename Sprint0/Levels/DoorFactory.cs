using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Sprint0.Levels.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2;

namespace Sprint0.Levels
{
    public class DoorFactory
    {
        public static DoorFactory instance = new DoorFactory();
        Texture2D doorSpriteSheet;

        ISprite closedDoorSprite, openDoorSprite, holeDoorSprite, keyDoorSprite;
        public Point doorSize;

        public void LoadContent(ContentManager content)
        {
            doorSpriteSheet = content.Load<Texture2D>("DoorSpriteSheet");
            doorSize = new Point(32, 32);

            closedDoorSprite = new DoorClosedSprite(doorSpriteSheet);
            openDoorSprite = new DoorOpenSprite(doorSpriteSheet);
            holeDoorSprite = new HoleDoorSprite(doorSpriteSheet);
            keyDoorSprite = new KeyDoorSprite(doorSpriteSheet);
        }
        public LevelDoor GetNewClosedDoor(Point pos, DoorDirectionEnum dir)
        {
            LevelDoor door = new LevelDoor(closedDoorSprite, dir, new Rectangle(pos,doorSize));
            return door;
        }
        public LevelDoor GetNewOpenDoor(Point pos, DoorDirectionEnum dir)
        {
            LevelDoor door = new LevelDoor(openDoorSprite, dir, new Rectangle(pos, doorSize));
            return door;
        }
    }
}
