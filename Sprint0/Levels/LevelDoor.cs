using System;
using System.Collections.Generic;
using System.Text;
using Poggus;
using Poggus.Levels.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Levels
{
    public enum DoorType { Key, Hole, Open, Closed, RoomClear }
    public class LevelDoor
    {
        ISprite sprite;
        DoorDirectionEnum doorDirection;
        public Rectangle destRect, collider;
        public bool isClosed;
        public DoorType doorType;
        public bool openOnRoomClear = false;
        
        public LevelDoor(DoorType doorType, ISprite sprite, DoorDirectionEnum direction, Rectangle dest)
        {
            this.doorType = doorType;
            if(doorType == DoorType.Closed || doorType == DoorType.Key || doorType == DoorType.Hole || doorType == DoorType.RoomClear)
            {
                this.isClosed = true;
            }
            if(doorType == DoorType.RoomClear)
            {
                this.openOnRoomClear = true;
            }

            this.sprite = sprite;
            this.sprite.CurrentFrame = (int)direction;

            this.doorDirection = direction;
            this.destRect = dest;
        }
        public void Update(GameTime gameTime)
        {
            if (openOnRoomClear && Game1.instance.GetDungeon().GetCurrentLevel().GetEnemyList().Count == 0)
            {
                OpenDoor();
            }
            if (!isClosed)
            {
                collider = new Rectangle(destRect.Location + new Point(18, 18), destRect.Size + new Point(-36, -36));
            }
            else
            {
                collider = destRect;
            }
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
