using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using LevelCreator.LevelObjects;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using LevelCreator.Sprites;
using LevelCreator.Sprites.Factories;
using Microsoft.Xna.Framework.Input;

namespace LevelCreator.UI
{
    class PlaceLevelObjectUI : AbstractUIHandler
    {
        TextSprite objectNameText;
        List<LevelObject> placeableObjects;
        Point start;
        Point screenSize;
        public PlaceLevelObjectUI(Point start, Point screenSize)
        {
            this.start = start;
            this.screenSize = screenSize;
            this.objectNameText = new TextSprite(GeneralFactory.instance.GetFont(), "", Color.Black);
            placeableObjects = new List<LevelObject>();

            string path = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string[] fileNames = Directory.GetFiles(path + "\\Placeable");
            foreach(string s in fileNames)
            {
                StreamReader reader = File.OpenText(s);
                string nameString = reader.ReadLine();
                string typeString = reader.ReadLine();
                string spriteSheet = reader.ReadLine();
                string xString = reader.ReadLine();
                string yString = reader.ReadLine();
                string widthString = reader.ReadLine();
                string heightString = reader.ReadLine();
                AddNewObject(nameString, typeString, spriteSheet, xString, yString, widthString, heightString);
                reader.Close();
            }

        }
        public bool displayNameText;
        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            displayNameText = false;
            foreach(LevelObject levelObject in placeableObjects)
            {
                if(levelObject.IsPointOver(new Point(mouse.X, mouse.Y)))
                {
                    objectNameText.SetText(levelObject.GetInfo().GetName());
                    displayNameText = true;
                }
            }
        }
        public override void Draw(SpriteBatch batch)
        {
            if (!IsVisible()) return;
            foreach(LevelObject levelObject in placeableObjects)
            {
                levelObject.Draw(batch);
            }
            if (displayNameText)
            {
                objectNameText.Draw(batch, new Rectangle(start.X, start.Y, 0, 0));
            }
        }
        public Point GetPos()
        {
            return start;
        }
        public LevelObject GetLevelObject(Point p)
        {
            foreach (LevelObject obj in placeableObjects)
            {
                if (obj.IsPointOver(p))
                {
                    return obj;
                }
            }
            return null;
        }
        public void AddPlaceable(LevelObject levelObject)
        {
            levelObject.SetRectangle(new Rectangle((start.X + 1) + 52 * (placeableObjects.Count % 4), (start.Y + 30) + 52 * (placeableObjects.Count / 4), 48, 48));
            this.placeableObjects.Add(levelObject);
        }
        public void AddNewObject(string name, string type, string spriteSheet, string x, string y, string width, string height)
        {
            LevelObjectInfo newInfo = LevelObjectFactory.instance.CreateLevelObjectInfo(name, type, spriteSheet, x, y, width, height);
            LevelObjectFactory.instance.AddLevelObjectInfo(name, newInfo);

            AddPlaceable(LevelObjectFactory.instance.CreateNewLevelObject(name, new Rectangle(0, 0, 0, 0)));
        }
    }
}
