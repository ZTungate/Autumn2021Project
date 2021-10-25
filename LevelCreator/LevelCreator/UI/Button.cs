using System;
using System.Collections.Generic;
using System.Text;
using LevelCreator.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LevelCreator.UI
{
    public class Button : IUIObject
    {
        Rectangle buttonRect;
        ISprite backgroundSprite;
        TextSprite textSprite;
        public Button(Rectangle buttonRect, ISprite backgroundSprite, TextSprite textSprite)
        {
            this.buttonRect = buttonRect;
            this.backgroundSprite = backgroundSprite;
            this.textSprite = textSprite;
        }
        public void Update(GameTime gameTime)
        {
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (backgroundSprite != null) backgroundSprite.Draw(spriteBatch, buttonRect);
            if (textSprite != null) textSprite.Draw(spriteBatch, buttonRect);
        }
        public bool IsPointOver(Point p)
        {
            return buttonRect.Contains(p);
        }
        public virtual void Execute()
        {
            //no-op
        }
        public void SetText(string text)
        {
            this.textSprite.SetText(text);
        }
        public string GetText()
        {
            return this.textSprite.GetText();
        }
    }
}
