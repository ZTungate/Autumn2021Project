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
        public LevelDoor GetNewDoor(DoorType doorType, Point pos, Point size, DoorDirectionEnum dir)
        {
            if(doorType == DoorType.Closed)
            {
                return GetNewClosedDoor(pos, size, dir);
            }
            if(doorType == DoorType.RoomClear)
            {
                return GetNewRoomClearDoor(pos, size, dir);
            }
            if(doorType == DoorType.Key)
            {
                return GetNewKeyDoor(pos, size, dir);
            }
            if(doorType == DoorType.Hole)
            {
                return GetNewHoleDoor(pos, size, dir);
            }
            return GetNewOpenDoor(pos, size, dir);
        }
        public AbstractSprite GetNewOverlaySprite(DoorDirectionEnum dir)
        {
            AbstractSprite overlaySprite = new DoorOverlaySprite(doorSpriteSheet);
            overlaySprite.CurrentFrame = (int)dir;
            return overlaySprite;
        }
        public LevelDoor GetNewClosedDoor(Point pos, Point size, DoorDirectionEnum dir)
        {
            LevelDoor door = new LevelDoor(DoorType.Closed,new DoorClosedSprite(doorSpriteSheet), dir, new Rectangle(pos,size));
            return door;
        }
        public LevelDoor GetNewRoomClearDoor(Point pos, Point size, DoorDirectionEnum dir)
        {
            LevelDoor door = new LevelDoor(DoorType.RoomClear, new DoorClosedSprite(doorSpriteSheet), dir, new Rectangle(pos, size));
            return door;
        }
        public LevelDoor GetNewOpenDoor(Point pos, Point size, DoorDirectionEnum dir)
        {
            LevelDoor door = new LevelDoor(DoorType.Open,new DoorOpenSprite(doorSpriteSheet), dir, new Rectangle(pos, size));
            return door;
        }
        public LevelDoor GetNewHoleDoor(Point pos, Point size, DoorDirectionEnum dir)
        {
            LevelDoor door = new LevelDoor(DoorType.Hole,new HoleDoorSprite(doorSpriteSheet), dir, new Rectangle(pos, size));
            return door;
        }
        public LevelDoor GetNewKeyDoor(Point pos, Point size, DoorDirectionEnum dir)
        {
            LevelDoor door = new LevelDoor(DoorType.Key,new KeyDoorSprite(doorSpriteSheet), dir, new Rectangle(pos, size));
            return door;
        }
    }
}
