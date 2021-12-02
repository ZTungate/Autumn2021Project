using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    internal class StateChanges
    {
        const int screenWidth = 1024;
        const int screenHeight = 704;
        const int textScale = 2;
        const int blackoutScale = 10000;
        const float totalBlackout = 1.0f;
        const float blackoutSpeed = 0.01f;
        const int halfing = 2;
        private Game1 game;
        private SpriteFont font;
        private string endGameText;
        private Texture2D fadeImage;
        private SpriteBatch _spriteBatch;
        private Rectangle screenDims = new Rectangle(new Point(), new Point(screenWidth, screenHeight));
        private float fadeTimer = 0.0f;
        private bool fade = false;


        public StateChanges(Game1 game, SpriteFont font, Texture2D fadeImage, SpriteBatch _spriteBatch)
        {
            this.game = game;
            this.font = font;
            this.fadeImage = fadeImage;
            this._spriteBatch = _spriteBatch;
        }
        public void Update()
        {
            if (fade)
            {
                fadeTimer += blackoutSpeed;

            }
        }
        public void loseGame()
        {

            endGameText = "Game Over!\nPress R to restart or Q to quit out.";
            fade = true;
        }

        public void winGame()
        {
            endGameText = "Congrats you win!";
            fade = true;

        }

        public void Reset()
        {
            fadeTimer = 0;
            fade = false;
        }


        private void printEndMessage()
        {
            Vector2 textMiddlePoint = font.MeasureString(endGameText) / halfing;
            _spriteBatch.DrawString(font, endGameText, new Vector2(screenDims.Width / halfing, screenDims.Height / halfing), Color.White, 0, textMiddlePoint, textScale, SpriteEffects.None, 0);
        }
        public void fadeOut()
        {
            if (fade)
            {
                _spriteBatch.Draw(fadeImage, new Vector2(screenDims.X, screenDims.Y), null, Color.Black * fadeTimer, 0, new Vector2(screenDims.X, screenDims.Y), blackoutScale, SpriteEffects.None, 1.0f);
                if (fadeTimer > 1f)
                {
                    printEndMessage();
                    if (game.soundManager.volume > 0)
                    {
                        game.toggleSound();
                    }

                }


            }


        }
    }
}
