using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Poggus.Blocks;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using Poggus;
using Microsoft.Xna.Framework.Content;
using Poggus.Items;
using Poggus.Enemies;
using Poggus.Enemies.Sprites;
using Poggus.Player;

namespace Poggus.Levels
{
    public class LevelLoader
    {
        public static LevelLoader instance = new LevelLoader();
        private Texture2D blockSpriteSheet;
        private Dictionary<string, Level> levels = new Dictionary<string, Level>();
        public void LoadAllLevels(ContentManager content)
        {
            levels.Clear();
            blockSpriteSheet = content.Load<Texture2D>("BlockSpriteSheet");

            BackgroundSprite defaultBackground = new BackgroundSprite(blockSpriteSheet);

            string dir = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string[] fileNames = Directory.GetFiles(dir + "\\Levels");
            XmlReaderSettings settings = new XmlReaderSettings();

            Game1.gameScaleX = (float)Game1.instance._graphics.PreferredBackBufferWidth / defaultBackground.SourceRect[0].Width;
            Game1.gameScaleY = (float)(Game1.instance._graphics.PreferredBackBufferHeight / defaultBackground.SourceRect[0].Height) * Game1.heightScalar;

            foreach (string fileName in fileNames)
            {
                Level newLevel = new Level(Game1.instance.link, Point.Zero);

                XmlReader reader = XmlReader.Create(File.OpenRead(fileName), settings);
                reader.ReadToDescendant("root");
                string levelName = reader.GetAttribute("xmlns");

                while (reader.Read())
                {
                    if (reader.IsStartElement() && reader.Name == "Block")
                    {
                        reader.ReadToDescendant("Object");
                        string blockName = reader.ReadElementContentAsString();

                        reader.ReadToDescendant("Location");
                        reader.MoveToContent();
                        string location = reader.ReadElementContentAsString();
                        int commaLoc = location.IndexOf(",");
                        string xString = location.Substring(0, commaLoc);
                        string yString = location.Substring(commaLoc + 1);
                        int x = int.Parse(xString);
                        int y = int.Parse(yString);

                        reader.ReadToDescendant("Conditions");
                        reader.MoveToContent();
                        string conditions = reader.ReadElementContentAsString();

                        Object[] objectParams = new Object[1];
                        objectParams[0] = new Point((int)(x * Game1.gameScaleX), (int)(y * Game1.gameScaleY));
                        Type objectType = Type.GetType("Poggus.Blocks." + blockName);
                        if(blockName == "MoveableFloorBlock")
                        {
                            objectType = Type.GetType("Poggus.Blocks.Floor");
                            MoveableFloorBlock moveable = new MoveableFloorBlock((Point)(objectParams[0]));
                            moveable.CreateSprite();

                            newLevel.AddMoveableBlock(moveable);
                        }
                        object instance = Activator.CreateInstance(objectType, objectParams);
                        AbstractBlock newBlock = (AbstractBlock)instance;
                        newBlock.CreateSprite();
                        
                        //create sprite

                        newLevel.AddBlock(new Point(x,y), newBlock);
                    }
                    if (reader.IsStartElement() && reader.Name == "Item")
                    {
                        reader.ReadToDescendant("Object");
                        string itemName = reader.ReadElementContentAsString();
                        itemName += "Item";

                        reader.ReadToDescendant("Location");
                        reader.MoveToContent();
                        string location = reader.ReadElementContentAsString();
                        int commaLoc = location.IndexOf(",");
                        string xString = location.Substring(0, commaLoc);
                        string yString = location.Substring(commaLoc + 1);
                        int x = int.Parse(xString);
                        int y = int.Parse(yString);

                        reader.ReadToDescendant("Conditions");
                        reader.MoveToContent();
                        string conditions = reader.ReadElementContentAsString();

                        Object[] objectParams = new Object[1];
                        objectParams[0] = new Point((int)(x * Game1.gameScaleX), (int)(y * Game1.gameScaleY));
                        Type itemType = Type.GetType("Poggus.Items." + itemName);
                        object instance = Activator.CreateInstance(itemType, objectParams);
                        AbstractItem item = (AbstractItem)instance;
                        if (conditions == "RoomClear")
                        {
                            item.spawnOnRoomClear = true;
                        }
                        item.CreateSprite();

                        newLevel.AddItem(item);
                    }
                    if (reader.IsStartElement() && reader.Name == "Enemy")
                    {
                        reader.ReadToDescendant("Object");
                        string enemyName = reader.ReadElementContentAsString();

                        reader.ReadToDescendant("Location");
                        reader.MoveToContent();
                        string location = reader.ReadElementContentAsString();
                        int commaLoc = location.IndexOf(",");
                        string xString = location.Substring(0, commaLoc);
                        string yString = location.Substring(commaLoc + 1);
                        int x = int.Parse(xString);
                        int y = int.Parse(yString);

                        reader.ReadToDescendant("Conditions");
                        reader.MoveToContent();

                        string conditions = reader.ReadElementContentAsString();
                        int commaIndex = conditions.IndexOf(",");
                        int xDir = 0, yDir = 0;
                        if(commaIndex != -1)
                        {
                            string xDirString = conditions.Substring(0, commaIndex);
                            string yDirString = conditions.Substring(commaIndex + 1);
                            xDir = int.Parse(xDirString);
                            yDir = int.Parse(yDirString);
                        }

                        Object[] objectParams = new Object[1];
                        objectParams[0] = new Point((int)(x * Game1.gameScaleX), (int)(y* Game1.gameScaleY));
                        Type enemyType = Type.GetType("Poggus.Enemies." + enemyName);
                        object instance = Activator.CreateInstance(enemyType, objectParams);
                        AbstractEnemy enemy = (AbstractEnemy)instance;

                        if(commaIndex != -1 && enemy is Grabber)
                        {
                            Grabber grabber = (Grabber)enemy;
                            grabber.SetStartingState(new Point(xDir, yDir));
                        }
                        enemy.CreateSprite();

                        newLevel.AddEnemy(enemy);
                    }
                    reader.MoveToElement();
                }
                levels.Add(levelName, newLevel);
            }
        }

        public void ResetLevels()
        {
            levels.Clear();
        }
        public Level GetLevel(string name)
        {
            Level outLevel;
            levels.TryGetValue(name, out outLevel);
            return outLevel;
        }
        public void DrawLevels(SpriteBatch batch)
        {
            foreach(KeyValuePair<string, Level> entry in levels)
            {
                entry.Value.Draw(batch);
            }
        }
        public ISprite GetNewBackgroundSprite()
        {
            return new BackgroundSprite(blockSpriteSheet);
        }
    }
}
