using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        float volume;
        Boolean[] cursor = new Boolean[3];
        Boolean options = false;
        public PauseMenuHandler(Game1 game)
        {
            cursor[0] = true;
            this.game = game;
            volume = game.soundManager.volume;
            Resume = game.pauseSpriteFactory.GetNewResumeSprite();
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

        public void Draw(SpriteBatch batch, Texture2D fadeImage)
        {
            if (game.Paused())
            {
                if (options)
                {
                    
                }
                else
                {

                    Resume = game.pauseSpriteFactory.GetNewResumeSprite();
                    
                    Resume.Draw(batch, new Rectangle(new Point(330, 100), new Point(384, 64)));
                    game.pauseSpriteFactory.GetNewOptionsSprite().Draw(batch, new Rectangle(new Point(330, 200), new Point(384, 64)));
                }
            }
        }

        public void selectResume()
        {
            Resume.CurrentFrame = (Resume.CurrentFrame + 1) % Resume.FrameCount;
        }
    }
}
