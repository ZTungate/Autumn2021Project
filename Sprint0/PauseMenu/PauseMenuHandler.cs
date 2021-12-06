using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Main;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.PauseMenu
{
    public class PauseMenuHandler
    {
        private static float VOLSCALE = 0.2f;
        private static float VOLFULL = 1f;
        private static float VOLOFF = 1f;
        private Game1 game;
        ISprite Resume;
        ISprite Options;
        Rectangle ResumeLoc = new Rectangle(new Point(330, 100), new Point(384, 64));
        Rectangle OptionsLoc = new Rectangle(new Point(330, 200), new Point(384, 64));
        float volume;
        Boolean cursor = true;
        public Boolean options = false;
        public PauseMenuHandler(Game1 game)
        {
            
            this.game = game;
            volume = game.soundManager.volume;
            Resume = game.pauseSpriteFactory.GetNewResumeSprite();
            Resume.CurrentFrame = 1;
            Options = game.pauseSpriteFactory.GetNewOptionsSprite();
        }

        public void Update()
        {
            ResumeLoc = new Rectangle(new Point(330, 100), new Point(384, 64));
            OptionsLoc = new Rectangle(new Point(330, 200), new Point(384, 64));
        }

        public void increaseVolume()
        {
            if(volume < VOLFULL)
            {
                volume += VOLSCALE;
            }
        }
        public void decreaseVolume()
        {
            if (volume > VOLOFF)
            {
                volume -= VOLSCALE;
            }
        }
        public void toogleOptions()
        {
            options = !options;
        }
        public void executeButton()
        {
            if (options)
            {

            }
            else
            {
                if (cursor)
                {
                    game.togglePause();
                }
                else
                {
                    options = true;
                }
            }
        }

        public void Draw(SpriteBatch batch, Texture2D fadeImage)
        {
            if (game.Paused())
            {
                if (options)
                {
                    
                }
                else
                {

                    
                    
                    Resume.Draw(batch, ResumeLoc);
                    Options.Draw(batch, OptionsLoc);
                }
            }
        }

        public void selectNext()
        {
            if (cursor)
            {
                Options.CurrentFrame = (Options.CurrentFrame + 1) % (Options.FrameCount - 1);
                Resume.CurrentFrame = (Resume.CurrentFrame + 1) % (Resume.FrameCount - 1);
                cursor = !cursor;
            }
            else
            {
                Resume.CurrentFrame = (Resume.CurrentFrame + 1) % (Resume.FrameCount - 1);
                Options.CurrentFrame = (Options.CurrentFrame + 1) % (Options.FrameCount - 1);
                cursor = !cursor;
            }
        }
    }
}
