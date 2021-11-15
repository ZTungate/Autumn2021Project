using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Poggus.Blocks;
using Poggus.Enemies;
using Poggus.Items;
using Poggus.Player;
using Poggus.Projectiles;
using Poggus;
using Poggus.Levels.Sprites;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Levels
{
    public class Level
    {
        List<LevelDoor> doors;
        ISprite backgroundSprite;
        Point location;
        Dictionary<Point, IBlock> blocks;
        List<IEnemy> enemies;
        List<AbstractItem> items;
        List<Rectangle> boundingBoxList;
        ILink link;

        Rectangle backgroundRectangle;
        public Level(ILink link, Point location)
        {
            backgroundSprite = LevelLoader.instance.GetNewBackgroundSprite();
            this.location = location;
            doors = new List<LevelDoor>();
            blocks = new Dictionary<Point, IBlock>();
            enemies = new List<IEnemy>();
            items = new List<AbstractItem>();
            boundingBoxList = new List<Rectangle>();
            this.link = link;
            backgroundRectangle = new Rectangle(0,0,Game1.instance._graphics.PreferredBackBufferWidth, (int)(Game1.instance._graphics.PreferredBackBufferHeight * Game1.heightScalar));
        }
        public LevelDoor GetDoorFromDirection(Point direction)
        {
            foreach(LevelDoor door in doors)
            {
                if(door.GetDirection() == Dungeon.doorDir[direction])
                {
                    return door;
                }
            }
            return null;
        }
        public ILink GetLink()
        {
            return this.link;
        }
        public LevelDoor[] GetDoorListAsArray()
        {
            return this.doors.ToArray();
        }
        public Rectangle[] GetBoundsAsArray()
        {
            return this.boundingBoxList.ToArray();
        }
        public void UpdateContentPosition(Point p)
        {
            this.location = p;

            this.backgroundRectangle.Location = this.backgroundRectangle.Location + p;

            foreach (LevelDoor door in doors)
            {
                door.destRect = new Rectangle(door.destRect.Location + p, door.destRect.Size);
            }

            foreach (KeyValuePair<Point, IBlock> entry in blocks)
            {
                entry.Value.DestRect = new Rectangle(entry.Value.DestRect.X + p.X, entry.Value.DestRect.Y + p.Y, entry.Value.DestRect.Width, entry.Value.DestRect.Height);
            }
            foreach (IEnemy enemy in enemies)
            {
                enemy.DestRect = new Rectangle(enemy.DestRect.Location + p, enemy.DestRect.Size);
            }
            foreach (AbstractItem item in items)
            {
                item.SetRectangle(new Rectangle(item.GetRectangle().X + p.X, item.GetRectangle().Y + p.Y, item.GetRectangle().Width, item.GetRectangle().Height));
            }

        }
        public void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<Point, IBlock> entry in blocks)
            {
                entry.Value.Update(gameTime);
            }
            foreach (IEnemy enemy in enemies)
            {
                enemy.Update(gameTime);
            }
            foreach (AbstractItem item in items)
            {
                item.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch batch)
        {
            this.backgroundSprite.Draw(batch, this.backgroundRectangle);

            foreach(KeyValuePair<Point,IBlock> entry in blocks)
            {
                entry.Value.Draw(batch);
            }
            foreach(IEnemy enemy in enemies)
            {
                enemy.Draw(batch);
            }
            foreach(AbstractItem item in items)
            {
                item.Draw(batch);
            }
            foreach (LevelDoor door in doors)
            {
                door.Draw(batch);
            }
        }
        public void DrawLayoutOnly(SpriteBatch batch)
        {
            this.backgroundSprite.Draw(batch, this.backgroundRectangle);

            foreach (KeyValuePair<Point, IBlock> entry in blocks)
            {
                entry.Value.Draw(batch);
            }
            foreach (LevelDoor door in doors)
            {
                door.Draw(batch);
            }
        }
        public Point GetPosition()
        {
            return this.location;
        }
        public void AddNewBoundingBox(Point p1, Point p2)
        {
            int width = p2.X - p1.X;
            int height = p2.Y - p1.Y;
            if(width == 0)
            {
                width = 5;
            }
            if (height == 0)
            {
                height = 5;
            }
            if(width < 0)
            {
                p1 = p2;
                width = -width;
            }
            if(height < 0)
            {
                p1 = p2;
                height = -height;
            }
            this.boundingBoxList.Add(new Rectangle(p1.X, p1.Y, width, height));
        }
        public void AddDoor(LevelDoor door, DoorDirectionEnum dir)
        {
            doors.Add(door);
            door.SetDirection(dir);
        }
        public bool AddBlock(Point p, IBlock block)
        {
            return blocks.TryAdd(p, block);
        }
        public void AddEnemy(IEnemy enemy)
        {
            enemies.Add(enemy);
        }
        public void AddItem(AbstractItem item)
        {
            items.Add(item);
        }

        public void RemoveItem(AbstractItem item)
        {
            items.Remove(item);
        }

        public void RemoveEnemy(IEnemy enemy)
        {
            enemies.Remove(enemy);
        }
        public IBlock GetBlock(Point p)
        {
            IBlock outBlock;
            this.blocks.TryGetValue(p, out outBlock);
            return outBlock;
        }
        public IBlock[] GetBlockArray()
        {
            IBlock[] blockArray = new IBlock[this.blocks.Count];
            this.blocks.Values.CopyTo(blockArray, 0);
            return blockArray;
        }
        public List<IEnemy> GetEnemyList()
        {
            return this.enemies;
        }
        public List<AbstractItem> GetItemList()
        {
            return this.items;
        }
    }
}
