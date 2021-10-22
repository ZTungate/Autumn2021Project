using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint3.Blocks;
using Sprint3.Enemies;
using Sprint3.Items;
using Sprint3.Player;
using Sprint3.Projectiles;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3.Levels
{
    class Level
    {
        Point location;
        Dictionary<Point, IBlocks> blocks;
        List<IEnemy> enemies;
        List<IItem> items;
        ILink link;
        public Level(ILink link, Point location)
        {
            this.location = location;
            blocks = new Dictionary<Point, IBlocks>();
            enemies = new List<IEnemy>();
            items = new List<IItem>();
            this.link = link;
        }
        public void Draw(SpriteBatch batch)
        {
            foreach(KeyValuePair<Point,IBlocks> entry in blocks)
            {
                entry.Value.Draw(batch);
            }
        }
        public bool AddBlock(Point p, IBlocks block)
        {
            return blocks.TryAdd(p, block);
        }
        public void AddEnemy(IEnemy enemy)
        {
            enemies.Add(enemy);
        }
    }
}
