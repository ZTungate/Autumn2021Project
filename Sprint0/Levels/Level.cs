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
        List<AbstractSprite> doorOverlaySprites = new List<AbstractSprite>();

        Dictionary<Point, DoorType> doorConditions;
        public bool hasCustomSpawn = false;
        public Point customSpawnLocation = Point.Zero;

        public Point returnLevelPoint;
        public Point returnSpawn = Point.Zero;

        public List<MoveableFloorBlock> moveableBlockList = new List<MoveableFloorBlock>();
        public List<TextSprite> textList = new List<TextSprite>();
        List<LevelDoor> doors;
        ISprite backgroundSprite;
        Point location;
        Dictionary<Point, IBlock> blocks;
        List<IEnemy> enemies;
        List<AbstractItem> items;
        List<Rectangle> boundingBoxList;
        ILink link;

        public bool displayInMinimap = true;
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
        public void AddMoveableBlock(MoveableFloorBlock block)
        {
            this.moveableBlockList.Add(block);
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

            LevelDoor door;

            //UP BOUND
            if((door = GetDoorFromDirection(new Point(0, 1))) != null)
            {
                Rectangle upBound1 = new Rectangle(location + new Point(0, 0), new Point(door.destRect.X - location.X, minY - 4));
                Rectangle upBound2 = new Rectangle(upBound1.Location + new Point(upBound1.Width + door.destRect.Width,0), upBound1.Size);

                boundingBoxList.Add(upBound1);
                boundingBoxList.Add(upBound2);
            }
            else
            {
                Rectangle upBound = new Rectangle(location + new Point(0, 0), new Point(backgroundRectangle.Width, minY - 4));
                boundingBoxList.Add(upBound);
            }

            //DOWN BOUND
            if ((door = GetDoorFromDirection(new Point(0, -1))) != null)
            {
                Rectangle downBound1 = new Rectangle(location + new Point(0, maxY + 5), new Point(door.destRect.X - location.X, backgroundRectangle.Height - (maxY + 1)));
                Rectangle downBound2 = new Rectangle(downBound1.Location + new Point(downBound1.Width + door.destRect.Width, 0), downBound1.Size);


                boundingBoxList.Add(downBound1);
                boundingBoxList.Add(downBound2);
            }
            else
            {
                Rectangle downBound = new Rectangle(location + new Point(0, maxY + 5), new Point(backgroundRectangle.Width, backgroundRectangle.Height - (maxY + 1)));
                boundingBoxList.Add(downBound);
            }

            //LEFT BOUND
            if ((door = GetDoorFromDirection(new Point(-1, 0))) != null)
            {
                Rectangle leftBound1 = new Rectangle(location + new Point(0, 0), new Point(minX - 4, door.destRect.Y - location.Y));
                Rectangle leftBound2 = new Rectangle(leftBound1.Location + new Point(0,leftBound1.Height + door.destRect.Height), leftBound1.Size);

                boundingBoxList.Add(leftBound1);
                boundingBoxList.Add(leftBound2);
            }
            else
            {
                Rectangle leftBound = new Rectangle(location + new Point(0, 0), new Point(minX - 4, backgroundRectangle.Height));
                boundingBoxList.Add(leftBound);
            }

            //RIGHT BOUND
            if ((door = GetDoorFromDirection(new Point(1, 0))) != null)
            {
                Rectangle rightBound1 = new Rectangle(location + new Point(maxX + 4, 0), new Point(backgroundRectangle.Width - (maxX + 1), door.destRect.Y - location.Y));
                Rectangle rightBound2 = new Rectangle(rightBound1.Location + new Point(0, rightBound1.Height + door.destRect.Height), rightBound1.Size);

                boundingBoxList.Add(rightBound1);
                boundingBoxList.Add(rightBound2);
            }
            else
            {
                Rectangle rightBound = new Rectangle(location + new Point(maxX + 4, 0), new Point(backgroundRectangle.Width - (maxX + 1), backgroundRectangle.Height));
                boundingBoxList.Add(rightBound);
            }
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
            foreach(MoveableFloorBlock block in moveableBlockList)
            {
                block.DestRect = new Rectangle(block.DestRect.X + p.X, block.DestRect.Y + p.Y, block.DestRect.Width, block.DestRect.Height);
            }
            foreach (IEnemy enemy in enemies)
            {
                enemy.DestRect = new Rectangle(enemy.DestRect.Location + p, enemy.DestRect.Size);
            }
            foreach (AbstractItem item in items)
            {
                item.SetRectangle(new Rectangle(item.GetRectangle().X + p.X, item.GetRectangle().Y + p.Y, item.GetRectangle().Width, item.GetRectangle().Height));
            }
            foreach(TextSprite textSprite in textList)
            {
                textSprite.SetPosition(textSprite.GetPosition() + p);
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
            foreach (LevelDoor door in doors)
            {
                door.Update(gameTime);
            }
            foreach (KeyValuePair<Point, IBlock> entry in blocks)
            {
                entry.Value.Update(gameTime);
            }
            foreach(MoveableFloorBlock block in moveableBlockList)
            {
                block.Update(gameTime);
            }
            if (!enemySpawnAnimation)
            {
                foreach (IEnemy enemy in enemies)
                {
                    enemy.interactable = true;
                    enemy.Update(gameTime);
                }
            }
            else
            {
                foreach (IEnemy enemy in enemies)
                {
                    enemy.interactable = false;
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

            foreach (LevelDoor door in doors)
            {
                door.Draw(batch);
            }

            foreach (KeyValuePair<Point,IBlock> entry in blocks)
            {
                entry.Value.Draw(batch);
            }
            foreach (MoveableFloorBlock block in moveableBlockList)
            {
                block.Draw(batch);
            }

            foreach (AbstractItem item in items)
            {
                item.Draw(batch);
            }
            if (!enemySpawnAnimation)
            {
                foreach (IEnemy enemy in enemies)
                {
                    enemy.Draw(batch);
                }
            }
            foreach (TextSprite text in textList)
            {
                text.Draw(batch);
            }

        }
        public IProjectile spawnAnimationProjectile;
        public void DoEnemySpawnAnimation()
        {
            enemySpawnAnimation = true;
            foreach(IEnemy enemy in enemies)
            {
                if (spawnAnimationProjectile == null)
                {
                    spawnAnimationProjectile = Game1.instance.projectileFactory.NewEnemyPoof(enemy.DestRect.Location, enemy.DestRect.Size);
                }
                else
                {
                    Game1.instance.projectileFactory.NewEnemyPoof(enemy.DestRect.Location, enemy.DestRect.Size);
                }
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
        public void DrawDoorOverlay(SpriteBatch batch)
        {
            foreach (DoorOverlaySprite sprite in doorOverlaySprites)
            {
                DoorDirectionEnum dirEnum = (DoorDirectionEnum)sprite.CurrentFrame;
                LevelDoor door;
                if ((door = GetDoorFromDirection(Dungeon.doorPointFromDir[dirEnum])) != null)
                {
                    sprite.Draw(batch, door.destRect);
                }
            }
        }
        public Point GetPosition()
        {
            return this.location;
        }
        public void SetPosition(Point pos)
        {
            this.location = pos;
        }
        public void AddDoor(LevelDoor door, DoorDirectionEnum dir)
        {
            doors.Add(door);
            door.SetDirection(dir);

            //Overlay so link is under door when going through
            doorOverlaySprites.Add(DoorFactory.instance.GetNewOverlaySprite(dir));
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
            if (!this.doorConditions.ContainsKey(doorDirection))
            {
                this.doorConditions.Add(doorDirection, doorType);
            }
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
