using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Levels;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Poggus.UI.UIObjects;

namespace Poggus.UI
{
    public class MapUIHandler
    {
        bool visible = true;
        Dungeon dungeon;
        Dictionary<Point, ImageUI> levelLayout;
        ImageUI linkImage;
        Point initialPoint;
        Point initialLinkPoint;
        public MapUIHandler(Point initialPoint)
        {
            levelLayout = new Dictionary<Point, ImageUI>();
            this.initialPoint = initialPoint;
            this.linkImage = new ImageUI(HUDSpriteFactory.instance.GetNewGreenBlockSprite(), Point.Zero, new Point(3,3));
            UpdateDungeon();
        }
        int maxMapX = int.MinValue, maxMapY = int.MinValue, minMapX = int.MaxValue, minMapY = int.MaxValue;
        public void UpdateDungeon()
        {
            this.dungeon = Game1.instance.GetDungeon();
            levelLayout.Clear();

            foreach (KeyValuePair<Point, Level> entry in this.dungeon.GetLevelDictionary())
            {
                levelLayout.Add(entry.Key, new ImageUI(HUDSpriteFactory.instance.GetNewBlueBlockSprite(), initialPoint + entry.Key * new Point(38, -11), new Point(35, 8)));
            }

            foreach (KeyValuePair<Point, ImageUI> entry in levelLayout)
            {
                if (entry.Value.DestRect.Location.X > maxMapX)
                {
                    maxMapX = entry.Value.DestRect.Location.X;
                }
                if (entry.Value.DestRect.Location.Y > maxMapY)
                {
                    maxMapY = entry.Value.DestRect.Location.Y;
                }
            }
            foreach (KeyValuePair<Point, ImageUI> entry in levelLayout)
            {
                if (entry.Value.DestRect.Location.X < minMapX)
                {
                    minMapX = entry.Value.DestRect.Location.X;
                }
                if (entry.Value.DestRect.Location.Y < minMapY)
                {
                    minMapY = entry.Value.DestRect.Location.Y;
                }
            }
            if (minMapX < 0)
            {
                foreach (KeyValuePair<Point, ImageUI> entry in levelLayout)
                {
                    entry.Value.SetPosition(entry.Value.GetPosition() + new Point(-minMapX + 32, 0));
                }
                initialLinkPoint = new Point(-minMapX + 32, 0);
            }
            
        }
        public void UpdatePosition(Point pos)
        {
            this.initialPoint += pos;
            linkImage.SetPosition(linkImage.GetPosition() + pos);
            foreach (KeyValuePair<Point, ImageUI> entry in levelLayout)
            {
                entry.Value.SetPosition(entry.Value.GetPosition() + pos);
            }
        }
        public Point GetPosition()
        {
            return this.initialPoint;
        }
        public void Update(GameTime gameTime)
        {
            int totalDungeonWidth = (Game1.instance.GetDungeon().GetMaxDungeonSize().X - Game1.instance.GetDungeon().GetMinDungeonSize().X);
            int totalDungeonHeight = (Game1.instance.GetDungeon().GetMaxDungeonSize().Y - Game1.instance.GetDungeon().GetMinDungeonSize().Y);

            Point linkUIPos = new Point((int)(Game1.instance.link.GetPosition().X / (float)totalDungeonWidth * (maxMapX-minMapX)) - 5 - Game1.instance.GetDungeon().GetUnscaledLevelPoint().X, (int)(Game1.instance.link.GetPosition().Y / (float)totalDungeonHeight * (maxMapY - minMapY)) - 2 - Game1.instance.GetDungeon().GetUnscaledLevelPoint().Y);

            this.linkImage.DestRect = new Rectangle(linkUIPos + initialLinkPoint + initialPoint, this.linkImage.DestRect.Size);
        }
        public void Draw(SpriteBatch batch)
        {
            if (visible)
            {
                foreach(KeyValuePair<Point,ImageUI> entry in levelLayout)
                {
                    entry.Value.Draw(batch);
                }
                linkImage.Draw(batch);
            }
        }
        public void ToggleVisible()
        {
            visible = !visible;
        }
        public bool IsVisible()
        {
            return visible;
        }
    }
}
