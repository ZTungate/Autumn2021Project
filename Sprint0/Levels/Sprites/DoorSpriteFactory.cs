using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Levels.Sprites
{
    class DoorSpriteFactory
    {
        public static int doorWidth, doorHeight;
        public static DoorSpriteFactory instance = new DoorSpriteFactory();
        Texture2D doorSpriteSheet;
        public void LoadContent(ContentManager content)
        {
            doorSpriteSheet = content.Load<Texture2D>("DoorSpriteSheet");
            doorWidth = 32;
            doorHeight = 32;
        }
        public DoorClosedSprite GetNewCloseDoor(Vector2 pos, float scaleX, float scaleY, DoorDirectionEnum dir)
        {
            DoorClosedSprite closedSprite = new DoorClosedSprite(doorSpriteSheet, pos, scaleX, scaleY);
            closedSprite.CurrentFrame = (int)dir;
            return closedSprite;
        }
        public DoorOpenSprite GetNewOpenDoor(Vector2 pos, float scaleX, float scaleY, DoorDirectionEnum dir)
        {
            DoorOpenSprite openSprite = new DoorOpenSprite(doorSpriteSheet, pos, scaleX, scaleY);
            openSprite.CurrentFrame = (int)dir;
            return openSprite;
        }
    }
}
