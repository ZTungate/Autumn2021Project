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
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Levels
{
    public class Level
    {
        ISprite backgroundSprite;
        Point location;
        Dictionary<Point, IBlock> blocks;
        List<IEnemy> enemies;
        List<AbstractItem> items;
        List<Rectangle> boundingBoxList;
        ILink link;
        public Level(ILink link, Point location)
        {
            backgroundSprite = LevelLoader.instance.GetNewBackgroundSprite();
            this.location = location;
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
            this.backgroundSprite.Draw(batch);

            foreach(KeyValuePair<Point,IBlock> entry in blocks)
            {
                entry.Value.Draw(batch);
            }
            foreach(IEnemy enemy in enemies)
            {
                enemy.Sprite.Draw(batch);
            }
            foreach(AbstractItem item in items)
            {
                item.Draw(batch);
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
