﻿using System;
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
        Dictionary<Point, DoorType> doorConditions;

        List<LevelDoor> doors;
        ISprite backgroundSprite;
        Point location;
        Dictionary<Point, IBlock> blocks;
        List<IEnemy> enemies;
        List<AbstractItem> items;
        List<Rectangle> boundingBoxList;
        ILink link;

        public bool enemySpawnAnimation = true;

        Rectangle backgroundRectangle;
        public Level(ILink link, Point location)
        {
            this.doorConditions = new Dictionary<Point, DoorType>();
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
        public void ConstructLevelBounds()
        {
            boundingBoxList.Clear();
            int minX = int.MaxValue, minY = int.MaxValue, maxX = int.MinValue, maxY = int.MinValue;
            foreach(KeyValuePair<Point,IBlock> entry in blocks)
            {
                if ((entry.Value.GetPosition().X + entry.Value.DestRect.Size.X) > maxX)
                {
                    maxX = entry.Value.GetPosition().X + entry.Value.DestRect.Size.X;
                }
                if ((entry.Value.GetPosition().Y + entry.Value.DestRect.Size.Y) > maxY)
                {
                    maxY = entry.Value.GetPosition().Y + entry.Value.DestRect.Size.Y;
                }
            }
            foreach (KeyValuePair<Point, IBlock> entry in blocks)
            {
                if (entry.Value.GetPosition().X < minX)
                {
                    minX = entry.Value.GetPosition().X;
                }
                if (entry.Value.GetPosition().Y < minY)
                {
                    minY = entry.Value.GetPosition().Y;
                }
            }
            maxX -= location.X;
            maxY -= location.Y;

            minX -= location.X;
            minY -= location.Y;
            Rectangle upBound = new Rectangle(location + new Point(0, 0), new Point(backgroundRectangle.Width, minY - 4));
            Rectangle downBound = new Rectangle(location + new Point(0, maxY + 15), new Point(backgroundRectangle.Width, backgroundRectangle.Height - (maxY + 1)));

            Rectangle leftBound = new Rectangle(location + new Point(0, 0), new Point(minX - 4, backgroundRectangle.Height));
            Rectangle rightBound = new Rectangle(location + new Point(maxX + 4, 0), new Point(backgroundRectangle.Width - (maxX + 1), backgroundRectangle.Height));

            boundingBoxList.Add(upBound);
            boundingBoxList.Add(downBound);
            boundingBoxList.Add(leftBound);
            boundingBoxList.Add(rightBound);
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

            ConstructLevelBounds();
        }
        public void Update(GameTime gameTime)
        {
            if(enemySpawnAnimation)
            {
                if(spawnAnimationProjectile != null && spawnAnimationProjectile.Life < 0)
                {
                    enemySpawnAnimation = false;
                    spawnAnimationProjectile = null;
                }
            }
            foreach (KeyValuePair<Point, IBlock> entry in blocks)
            {
                entry.Value.Update(gameTime);
            }
            if (!enemySpawnAnimation)
            {
                foreach (IEnemy enemy in enemies)
                {
                    enemy.Update(gameTime);
                }
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
            if (!enemySpawnAnimation)
            {
                foreach (IEnemy enemy in enemies)
                {
                    enemy.Draw(batch);
                }
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
        public IProjectile spawnAnimationProjectile;
        public void DoEnemySpawnAnimation()
        {
            enemySpawnAnimation = true;
            foreach(IEnemy enemy in enemies)
            {
                spawnAnimationProjectile = Game1.instance.projectileFactory.NewEnemyPoof(enemy.DestRect.Location, enemy.DestRect.Size);
            }
        }
        public void ResetEnemySpawnAnimation()
        {
            enemySpawnAnimation = true;
            spawnAnimationProjectile = null;
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
        public void AddDoorCondition(Point doorDirection, DoorType doorType)
        {
            this.doorConditions.Add(doorDirection, doorType);
        }
        public DoorType GetDoorCondition(Point dir)
        {
            DoorType outType;
            if(!this.doorConditions.TryGetValue(dir, out outType))
            {
                outType = DoorType.Open;
            }
            return outType;
        }
    }
}
