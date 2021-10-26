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
        public Button loadLevelButton;
        public Button exportLevelButton;
        public TextField levelNameField;
        public NewLevelObjectUI newObjectUI;
        public PlaceLevelObjectUI placeObjectUI;


        public LevelCreatorUIHandler(Point screenSize)
        {
            this.screenSize = screenSize;

            placeObjectButton = new Button(new Rectangle(screenSize.X - 250, 0, 125, 50), GeneralFactory.instance.GetButtonSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "Place Object", Color.Black));
            addObjectButton = new Button(new Rectangle(screenSize.X - 125, 0, 125, 50), GeneralFactory.instance.GetButtonSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "Add Object", Color.Black));

            newLevelButton = new Button(new Rectangle(screenSize.X - 125, screenSize.Y - 150, 125, 50), GeneralFactory.instance.GetButtonSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "New Level", Color.Black));
            loadLevelButton = new Button(new Rectangle(screenSize.X - 125, screenSize.Y - 100, 125, 50), GeneralFactory.instance.GetButtonSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "Load Level", Color.Black));
            exportLevelButton = new Button(new Rectangle(screenSize.X - 125, screenSize.Y - 50, 125, 50), GeneralFactory.instance.GetButtonSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "Export Level", Color.Black));

            levelNameField = new TextField(new Rectangle(screenSize.X - 300, screenSize.Y - 50, 175, 50), GeneralFactory.instance.GetTextFieldSprite(), new TextSprite(GeneralFactory.instance.GetFont(), "", Color.White));

            placeObjectUI = new PlaceLevelObjectUI(new Point(screenSize.X - 250, 50), screenSize);
            newObjectUI = new NewLevelObjectUI(new Point(screenSize.X - 250, 50), screenSize, placeObjectUI);

            placeObjectUI.SetVisible(true);
        }
        LevelObject placing;
        MouseState state;
        public override void Update(GameTime gameTime)
        {
            levelNameField.Update(gameTime);
            newObjectUI.Update(gameTime);
            placeObjectUI.Update(gameTime);

            MouseState lastState = state;
            state = Mouse.GetState();
            Point mousePos = new Point(state.X, state.Y);
            if (state.LeftButton == ButtonState.Pressed && lastState.LeftButton != ButtonState.Pressed)
            {
                if (levelNameField.GetTextFieldRectangle().Contains(mousePos))
                {
                    levelNameField.SetClickedOn(true);
                }
                else
                {
                    levelNameField.SetClickedOn(false);
                }
                if (placing != null && mousePos.X < placeObjectUI.GetPos().X)
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
                        LevelCreator.instace.currentLevel.GenerateLevelXml(levelNameField.GetText());
                    }
                    if (loadLevelButton.IsPointOver(mousePos))
                    {
                        Level returnLevel;
                        if((returnLevel = Level.LoadLevel(levelNameField.GetText())) != null){
                            LevelCreator.instace.currentLevel = returnLevel;
                        }
                    }
                    if (newLevelButton.IsPointOver(mousePos))
                    {
                        LevelCreator.instace.currentLevel = new Level("Unnamed");
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
            if(state.MiddleButton == ButtonState.Pressed && lastState.MiddleButton != ButtonState.Pressed)
            {
                if (firstClick)
                {
                    Point firstPos = mousePos;
                    foreach(LineSprite line in LevelCreator.instace.currentLevel.GetBoundList())
                    {
                        if(LineSprite.Distance(mousePos, line.GetP1()) < 10f)
                        {
                            firstPos = line.GetP1();

                            break;
                        }
                        if(LineSprite.Distance(mousePos,line.GetP2()) < 10f)
                        {
                            firstPos = line.GetP2();

                            break;
                        }
                    }
                    LineSprite newLine = new LineSprite(Color.White, firstPos);
                    currentLine = newLine;
                    LevelCreator.instace.currentLevel.AddBound(newLine);
                    firstClick = false;
                }
                else
                {
                    firstClick = true;
                }
            }
            if (!firstClick)
            {
                Point[] pointArr = new Point[4];

                pointArr[0] = LineSprite.FindNearestPointOnLine(currentLine.GetP1().ToVector2(), currentLine.GetP1().ToVector2() + new Vector2(1000, 0), mousePos.ToVector2()).ToPoint();
                pointArr[1] = LineSprite.FindNearestPointOnLine(currentLine.GetP1().ToVector2(), currentLine.GetP1().ToVector2() + new Vector2(-1000, 0), mousePos.ToVector2()).ToPoint();
                pointArr[2] = LineSprite.FindNearestPointOnLine(currentLine.GetP1().ToVector2(), currentLine.GetP1().ToVector2() + new Vector2(0, 1000), mousePos.ToVector2()).ToPoint();
                pointArr[3] = LineSprite.FindNearestPointOnLine(currentLine.GetP1().ToVector2(), currentLine.GetP1().ToVector2() + new Vector2(0, -1000), mousePos.ToVector2()).ToPoint();

                //Vector2 pointX = LineSprite.FindNearestPointOnLine(currentLine.GetP1().ToVector2(), currentLine.GetP1().ToVector2() + new Vector2(1000, 0), mousePos.ToVector2());
                Point closestPoint = pointArr[0];
                foreach(Point p in pointArr)
                {
                    if(LineSprite.Distance(p, mousePos) < LineSprite.Distance(closestPoint, mousePos))
                    {
                        closestPoint = p;
                    }
                }

                currentLine.SetP2(closestPoint);
            }
            if (placing != null) placing.SetPos(mousePos - new Point(placing.GetRectangle().Width / 2, placing.GetRectangle().Height/2));
        }
        LineSprite currentLine;
        bool firstClick = true;
        public override void Draw(SpriteBatch batch)
        {
            levelNameField.Draw(batch);

            placeObjectButton.Draw(batch);
            addObjectButton.Draw(batch);

            newLevelButton.Draw(batch);
            loadLevelButton.Draw(batch);
            exportLevelButton.Draw(batch);

            placeObjectUI.Draw(batch);
            newObjectUI.Draw(batch);

            if (placing != null) placing.Draw(batch);
        }
    }
}
