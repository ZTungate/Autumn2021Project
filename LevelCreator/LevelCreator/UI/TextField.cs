using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LevelCreator.Sprites;
using Microsoft.Xna.Framework.Input;

namespace LevelCreator.UI
{
    class TextField : IUIObject
    {
        Rectangle textFieldRect;
        ISprite backgroundSprite;
        TextSprite textSprite;
        bool clickedOn;
        Dictionary<Keys, string> numMap = new Dictionary<Keys, string>();
        public TextField(Rectangle textFieldRect, ISprite backgroundSprite, TextSprite textSprite)
        {
            this.textFieldRect = textFieldRect;
            this.backgroundSprite = backgroundSprite;
            this.textSprite = textSprite;

            numMap.Add(Keys.D0, "0");
            numMap.Add(Keys.D1, "1");
            numMap.Add(Keys.D2, "2");
            numMap.Add(Keys.D3, "3");
            numMap.Add(Keys.D4, "4");
            numMap.Add(Keys.D5, "5");
            numMap.Add(Keys.D6, "6");
            numMap.Add(Keys.D7, "7");
            numMap.Add(Keys.D8, "8");
            numMap.Add(Keys.D9, "9");
        }
        KeyboardState state;
        public void Update(GameTime gameTime)
        {
            if (clickedOn)
            {
                KeyboardState lastState = state;
                state = Keyboard.GetState();
                Keys[] keys = state.GetPressedKeys();
                bool shiftDown = false;
                foreach (Keys k in keys)
                {
                    if(k == Keys.LeftShift || k == Keys.RightShift)
                    {
                        shiftDown = true;
                    }
                }
                foreach (Keys k in keys)
                {
                    if (lastState.IsKeyDown(k)) return;

                    switch (k)
                    {
                        case Keys.Back:
                            if (GetText().Length > 0)
                            {
                                SetText(GetText().Substring(0, GetText().Length - 1));
                            }
                            break;
                        case Keys.Space:
                            SetText(GetText() + " ");
                            break;
                        case Keys.LeftShift:
                            break;
                        case Keys.RightShift:
                            break;
                        default:
                            string ch = k.ToString().ToLower() + "";
                            if (shiftDown) ch = ch.ToUpper();
                            if (numMap.ContainsKey(k))
                            {
                                ch = numMap[k];
                            }
                            SetText(GetText() + ch);
                            break;
                    }
                }
            }
        }
        public void Draw(SpriteBatch batch)
        {
            if (backgroundSprite != null) backgroundSprite.Draw(batch, textFieldRect);
            if (textSprite != null) textSprite.Draw(batch, textFieldRect);
        }
        public void SetClickedOn(bool clicked)
        {
            clickedOn = clicked;
        }
        public bool IsClickedOn()
        {
            return clickedOn;
        }
        public string GetText()
        {
            return this.textSprite.GetText();
        }
        public void SetText(string text)
        {
            this.textSprite.SetText(text);
        }
        public Rectangle GetTextFieldRectangle()
        {
            return this.textFieldRect;
        }
        public void ClearText()
        {
            this.SetText("");
        }
    }
}
