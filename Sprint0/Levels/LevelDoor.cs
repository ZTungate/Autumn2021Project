using System;
using System.Collections.Generic;
using System.Text;
using Poggus;
using Poggus.Levels.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Levels
{
    public enum DoorType { Key, Hole, Open, Closed }
    public class LevelDoor
    {
        ISprite sprite;
        DoorDirectionEnum doorDirection;
        public Rectangle destRect;
        public bool isClosed;
        public DoorType doorType;
        
        public LevelDoor(DoorType doorType, ISprite sprite, DoorDirectionEnum direction, Rectangle dest)
        {
            this.doorType = doorType;
            if(doorType == DoorType.Closed || doorType == DoorType.Key || doorType == DoorType.Hole)
            {
                this.isClosed = true;
            }

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
            bool draw = true;
            if(doorType == DoorType.Hole && isClosed)
            {
                draw = false;
            }
            if (draw)
            {
                this.sprite.Draw(batch, destRect);
            }
        }
        public DoorDirectionEnum GetDirection()
        {
            return this.doorDirection;
        }
        public void OpenDoor()
        {
            this.doorType = DoorType.Open;
            this.sprite = new DoorOpenSprite(this.sprite.Texture);
            this.isClosed = false;
            SetDirection(doorDirection);
        }
        public void BlowUp()
        {
            this.doorType = DoorType.Hole;
            isClosed = false;
            this.sprite = new HoleDoorSprite(this.sprite.Texture);
            SetDirection(doorDirection);
        }
        
    }
}
