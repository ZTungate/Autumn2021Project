using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LevelCreator.LevelObjects;
using LevelCreator.Sprites;
using LevelCreator.Sprites.Factories;

namespace LevelCreator.UI
{
    class LevelCreatorUIHandler : AbstractUIHandler
    {
        Point screenSize;
        public Button addObjectButton;
        public Button placeObjectButton;
        public Button newLevelButton;
        public Button exportLevelButton;
        public NewLevelObjectUI newObjectUI;
        public PlaceLevelObjectUI placeObjectUI;
        public ISprite background;

        public LevelCreatorUIHandler(Point screenSize)
        {
            this.screenSize = screenSize;

            background = GeneralFactory.instance.GetBackground();

            placeObjectButton = new Button(new Rectangle(screenSize.X - 250, 0, 125, 50), GeneralFactory.instance.GetButtonSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "Place Object", Color.Black));
            addObjectButton = new Button(new Rectangle(screenSize.X - 125, 0, 125, 50), GeneralFactory.instance.GetButtonSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "Add Object", Color.Black));

            exportLevelButton = new Button(new Rectangle(screenSize.X - 125, screenSize.Y - 50, 125, 50), GeneralFactory.instance.GetButtonSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "Export Level", Color.Black));

            placeObjectUI = new PlaceLevelObjectUI(new Point(screenSize.X - 250, 50), screenSize);
            newObjectUI = new NewLevelObjectUI(new Point(screenSize.X - 250, 50), screenSize, placeObjectUI);

            placeObjectUI.SetVisible(true);
        }
        LevelObject placing;
        MouseState state;
        public override void Update(GameTime gameTime)
        {
            newObjectUI.Update(gameTime);
            placeObjectUI.Update(gameTime);

            MouseState lastState = state;
            state = Mouse.GetState();
            Point mousePos = new Point(state.X, state.Y);
            if (state.LeftButton == ButtonState.Pressed && lastState.LeftButton != ButtonState.Pressed)
            {
                if(placing != null && mousePos.X < placeObjectUI.GetPos().X)
                {
                    Point middleMousePos = mousePos - new Point(placing.GetRectangle().Width / 2, placing.GetRectangle().Height / 2);
                    if (placing.GetInfo().GetLevelObjectType() == LevelObjectType.Block)
                    {
                        int size = placing.GetRectangle().Width;
                        Point placePos = new Point((mousePos.X / size) * size, (mousePos.Y / size) * size);
                        LevelObject newLevelObject = new LevelObject(placing);
                        newLevelObject.SetPos(placePos);
                        LevelCreator.instace.currentLevel.AddBlock(placePos, newLevelObject);
                    }
                    if (placing.GetInfo().GetLevelObjectType() == LevelObjectType.Item)
                    {
                        Point placePos = new Point(middleMousePos.X, middleMousePos.Y);
                        LevelObject newLevelObject = new LevelObject(placing);
                        newLevelObject.SetPos(placePos);
                        LevelCreator.instace.currentLevel.AddItem(newLevelObject);
                    }
                    if (placing.GetInfo().GetLevelObjectType() == LevelObjectType.Enemy)
                    {
                        Point placePos = new Point(middleMousePos.X, middleMousePos.Y);
                        LevelObject newLevelObject = new LevelObject(placing);
                        newLevelObject.SetPos(placePos);
                        LevelCreator.instace.currentLevel.AddEnemy(newLevelObject);
                    }
                }

                if (placeObjectButton.IsPointOver(mousePos))
                {
                    placeObjectUI.SetVisible(true);
                    newObjectUI.SetVisible(false);
                }
                if (addObjectButton.IsPointOver(mousePos))
                {
                    placeObjectUI.SetVisible(false);
                    newObjectUI.SetVisible(true);
                }

                if(placeObjectUI.IsVisible() && mousePos.X >= placeObjectUI.GetPos().X && mousePos.Y >= placeObjectUI.GetPos().Y)
                {
                    LevelObject clickedObj = placeObjectUI.GetLevelObject(mousePos);
                    if (clickedObj != null)
                    {
                        placing = new LevelObject(clickedObj);
                    }
                    else
                    {
                        placing = null;
                    }
                    if (exportLevelButton.IsPointOver(mousePos))
                    {
                        LevelCreator.instace.currentLevel.GenerateLevelXml();
                    }
                }
                else if (newObjectUI.IsVisible() && mousePos.X >= newObjectUI.GetPos().X && mousePos.Y >= newObjectUI.GetPos().Y)
                {

                }
            }
            if (state.RightButton == ButtonState.Pressed && lastState.RightButton != ButtonState.Pressed)
            {
                if(!LevelCreator.instace.currentLevel.RemoveEnemy(mousePos))
                {
                    if (!LevelCreator.instace.currentLevel.RemoveItem(mousePos))
                    {
                        KeyValuePair<Point, LevelObject> entry = LevelCreator.instace.currentLevel.GetEntryContainingPosition(mousePos);
                        if (entry.Value != null)
                        {
                            LevelCreator.instace.currentLevel.RemoveBlock(entry.Key);
                        }
                    }
                }
            }
            if (placing != null) placing.SetPos(mousePos - new Point(placing.GetRectangle().Width / 2, placing.GetRectangle().Height/2));
        }
        public override void Draw(SpriteBatch batch)
        {
            background.Draw(batch, new Rectangle(0, 0, 256*3, 176*3), 0.0f);
            placeObjectButton.Draw(batch);
            addObjectButton.Draw(batch);

            exportLevelButton.Draw(batch);

            placeObjectUI.Draw(batch);
            newObjectUI.Draw(batch);

            if (placing != null) placing.Draw(batch, 0.1f);
        }
    }
}
