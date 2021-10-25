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
        public Dictionary<Point, IBlock> blocks;
        List<IEnemy> enemies;
        List<IItem> items;
        ILink link;
        public Level(ILink link, Point location)
        {
            backgroundSprite = LevelLoader.instance.GetNewBackgroundSprite();
            this.location = location;
            blocks = new Dictionary<Point, IBlock>();
            enemies = new List<IEnemy>();
            items = new List<IItem>();
            this.link = link;
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
        }
        public Point GetPosition()
        {
            return this.location;
        }
        public bool AddBlock(Point p, IBlock block)
        {
            return blocks.TryAdd(p, block);
        }
        public void AddEnemy(IEnemy enemy)
        {
            enemies.Add(enemy);
        }
        public void AddItem(IItem item)
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
        public List<IItem> GetItemList()
        {
            return this.items;
        }
    }
}
