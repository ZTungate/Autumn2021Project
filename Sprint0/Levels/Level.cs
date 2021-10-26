using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Blocks;
using Sprint2.Enemies;
using Sprint2.Items;
using Sprint2.Player;
using Sprint2.Projectiles;
using Sprint2;
using Sprint0.Levels.Sprites;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Levels
{
    public class Level
    {
        List<ISprite> doorSprites;
        ISprite backgroundSprite;
        Point location;
        public Dictionary<Point, IBlock> blocks;
        List<IEnemy> enemies;
        List<AbstractItem> items;
        List<Rectangle> boundingBoxList;
        ILink link;
        public Level(ILink link, Point location)
        {
            backgroundSprite = LevelLoader.instance.GetNewBackgroundSprite();
            this.location = location;
            doorSprites = new List<ISprite>();
            blocks = new Dictionary<Point, IBlock>();
            enemies = new List<IEnemy>();
            items = new List<AbstractItem>();
            boundingBoxList = new List<Rectangle>();
            this.link = link;
        }
        public Rectangle[] GetBoundsAsArray()
        {
            return this.boundingBoxList.ToArray();
        }
        public void UpdateContentPosition(Point p)
        {
            this.location = p;

            this.backgroundSprite.Position = this.backgroundSprite.Position + new Vector2(p.X, p.Y);

            foreach (KeyValuePair<Point, IBlock> entry in blocks)
            {
                entry.Value.destRect = new Rectangle(entry.Value.destRect.X + p.X, entry.Value.destRect.Y + p.Y, entry.Value.destRect.Width, entry.Value.destRect.Height);
            }
            foreach (IEnemy enemy in enemies)
            {
                enemy.Position = new Vector2(enemy.Position.X + p.X, enemy.Position.Y + p.Y);
            }
            foreach (IItem item in items)
            {
                item.rect = new Rectangle(item.rect.X + p.X, item.rect.Y + p.Y, item.rect.Width, item.rect.Height);
            }

            foreach(ISprite sprite in doorSprites)
            {
                sprite.Position = new Vector2(sprite.Position.X + p.X, sprite.Position.Y + p.Y);
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
            foreach (IItem item in items)
            {
                item.Update(gameTime);
            }
        }
        public void Draw(SpriteBatch batch)
        {
            this.backgroundSprite.Draw(batch);

            foreach(KeyValuePair<Point,IBlock> entry in blocks)
            {
                entry.Value.Draw(batch);
            }
            foreach(IEnemy enemy in enemies)
            {
                enemy.Sprite.Draw(batch);
            }
            foreach(IItem item in items)
            {
                item.Draw(batch);
            }
            foreach (ISprite sprite in doorSprites)
            {
                sprite.Draw(batch);
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
        public void AddDoor(ISprite door, DoorDirectionEnum dir)
        {
            doorSprites.Add(door);
            door.CurrentFrame = (int)dir;
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
