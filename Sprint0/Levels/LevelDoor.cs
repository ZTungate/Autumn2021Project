using System;
using System.Collections.Generic;
using System.Text;
using Poggus;
using Poggus.Levels.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Levels
{
    public class LevelDoor
    {
        ISprite sprite;
        DoorDirectionEnum doorDirection;
        public Rectangle destRect;
        public LevelDoor(ISprite sprite, DoorDirectionEnum direction, Rectangle dest)
        {
            this.sprite = sprite;
            this.sprite.CurrentFrame = (int)direction;

            this.doorDirection = direction;
            this.destRect = dest;
        }
        public void SetDirection(DoorDirectionEnum direction)
        {
            this.doorDirection = direction;
            this.sprite.CurrentFrame = (int)direction;
        }
        public void Draw(SpriteBatch batch)
        {
            this.sprite.Draw(batch, destRect);
        }
        public DoorDirectionEnum GetDirection()
        {
            return this.doorDirection;
        }
    }
}
