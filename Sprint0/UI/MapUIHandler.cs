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
        bool visible;
        Dungeon dungeon;
        Dictionary<Point, ImageUI> levelLayout;
        public MapUIHandler()
        {
            levelLayout = new Dictionary<Point, ImageUI>();
            UpdateDungeon();
        }
        public void UpdateDungeon()
        {
            this.dungeon = Game1.instance.GetDungeon();
            levelLayout.Clear();
            foreach(KeyValuePair<Point,Level> entry in this.dungeon.GetLevelDictionary())
            {
                levelLayout.Add(entry.Key, new ImageUI(HUDSpriteFactory.instance.GetNewBlueBlockSprite(), entry.Key, new Point(10,5)));
            }
        }
        public void Draw(SpriteBatch batch)
        {
            if (visible)
            {
                foreach(KeyValuePair<Point,ImageUI> entry in levelLayout)
                {
                    entry.Value.Draw(batch);
                }
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
