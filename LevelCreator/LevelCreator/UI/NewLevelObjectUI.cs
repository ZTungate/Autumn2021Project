using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LevelCreator.LevelObjects;
using LevelCreator.Sprites.Factories;
using Microsoft.Xna.Framework.Input;
using LevelCreator.Sprites;
using System.IO;

namespace LevelCreator.UI
{
    class NewLevelObjectUI :AbstractUIHandler
    {
        PlaceLevelObjectUI placeUI;
        TextField spriteSheetField;
        TextField locationXField, locationYField;
        TextField widthField, heightField;
        TextField nameField;
        TextField typeField;
        Button addButton;

        Point start;
        Point screenSize;

        List<TextField> textFields;

        public NewLevelObjectUI(Point start,Point screenSize, PlaceLevelObjectUI placeUI)
        {
            this.start = start;
            this.screenSize = screenSize;

            this.spriteSheetField = new TextField(new Rectangle(start.X,start.Y, 200, 50), GeneralFactory.instance.GetTextFieldSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "", Color.White));

            this.locationXField = new TextField(new Rectangle(start.X, start.Y + 75, 100, 50), GeneralFactory.instance.GetTextFieldSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "", Color.White));
            this.locationYField = new TextField(new Rectangle(start.X + 110, start.Y + 75, 100, 50), GeneralFactory.instance.GetTextFieldSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "", Color.White));

            this.widthField = new TextField(new Rectangle(start.X, start.Y + 150, 100, 50), GeneralFactory.instance.GetTextFieldSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "", Color.White));
            this.heightField = new TextField(new Rectangle(start.X + 110, start.Y + 150, 100, 50), GeneralFactory.instance.GetTextFieldSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "", Color.White));

            this.nameField = new TextField(new Rectangle(start.X, start.Y + 225, 200, 50), GeneralFactory.instance.GetTextFieldSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "", Color.White));
            this.typeField = new TextField(new Rectangle(start.X, start.Y + 300, 200, 50), GeneralFactory.instance.GetTextFieldSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "", Color.White));

            this.addButton = new Button(new Rectangle(start.X, start.Y + 375, 100, 50), GeneralFactory.instance.GetButtonSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "Create", Color.White));

            textFields = new List<TextField>();
            textFields.Add(spriteSheetField);
            textFields.Add(locationXField);
            textFields.Add(locationYField);
            textFields.Add(widthField);
            textFields.Add(heightField);
            textFields.Add(nameField);
            textFields.Add(typeField);

            this.placeUI = placeUI;
        }
        MouseState state;
        public override void Update(GameTime gameTime)
        {
            MouseState lastState = state;
            state = Mouse.GetState();
            if (state.LeftButton == ButtonState.Pressed && lastState.LeftButton != ButtonState.Pressed)
            {
                Point mousePos = new Point(state.X, state.Y);
                foreach(TextField field in textFields)
                {
                    if (field.GetTextFieldRectangle().Contains(mousePos))
                    {
                        field.SetClickedOn(true);
                    }
                    else
                    {
                        field.SetClickedOn(false);
                    }
                }
                if (addButton.IsPointOver(mousePos))
                {
                    placeUI.AddNewObject(nameField.GetText(), typeField.GetText(), spriteSheetField.GetText(), locationXField.GetText(), locationYField.GetText(), widthField.GetText(), heightField.GetText());

                    WriteObject(nameField.GetText(), typeField.GetText(), spriteSheetField.GetText(), locationXField.GetText(), locationYField.GetText(), widthField.GetText(), heightField.GetText());
                    foreach (TextField field in textFields)
                    {
                        field.ClearText();
                    }
                }
            }
            foreach (TextField field in textFields)
            {
                field.Update(gameTime);
            }
            addButton.Update(gameTime);
        }
        public Point GetPos()
        {
            return start;
        }
        public override void Draw(SpriteBatch batch)
        {
            if (!visible) return;
            foreach(TextField field in textFields)
            {
                field.Draw(batch);
            }
            addButton.Draw(batch);
        }
        public void WriteObject(string name, string type, string spriteSheet, string x, string y, string width, string height)
        {
            StreamWriter writer = File.CreateText(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "\\Placeable\\" + name + ".data");
            writer.WriteLine(name);
            writer.WriteLine(type);
            writer.WriteLine(spriteSheet);
            writer.WriteLine(x);
            writer.WriteLine(y);
            writer.WriteLine(width);
            writer.WriteLine(height);
            writer.Close();
        }
    }
}
