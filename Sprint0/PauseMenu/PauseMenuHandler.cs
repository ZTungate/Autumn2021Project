using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Enemies;
using Poggus.Levels;
using Poggus.Main;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.PauseMenu
{
    public class PauseMenuHandler
    {
        private static float VOLSCALE = 0.2f;
        private static float VOLFULL = 1.0f;
        private const int ARRAYOFFSET = 1;
        private static float VOLOFF = 0.0f;
        private const float TINT = 0.8f;
        private Game1 game;
        public int difficulty = 0;
        private ISprite Resume;
        private ISprite Options;
        private ISprite SoundBar;
        private String OptionSelector = ">";
        private String soundName = "Sound:";
        private Vector2 soundNameLoc = new Vector2(300, 200);
        private Vector2 soundCursorLoc = new Vector2(280, 200);
        private SpriteFont Font;
        private String[] difficulties = new String[3];
        private Vector2 difficultyLoc = new Vector2(400, 400);
        private String difficultyName = "Difficulty:";
        private Vector2 difficultyNameLoc = new Vector2(300, 400);
        private Vector2 difficultyCursorLoc = new Vector2(280, 400);
        private Rectangle ResumeLoc = new Rectangle(new Point(330, 100), new Point(384, 64));
        private Rectangle OptionsLoc = new Rectangle(new Point(330, 200), new Point(384, 64));
        private Rectangle Backdrop = new Rectangle(new Point(0, 0), new Point(1100, 1100));
        private Rectangle SoundLoc = new Rectangle(new Point(400, 200), new Point(95, 32));
        private float volume;
        public Boolean cursor = true; //true = resume false = options selected
        public Boolean options = false; //true = in options false = normal page
        public Boolean optionCursor = false; //true = difficulty false = volume
        

        public PauseMenuHandler(Game1 game, SpriteFont font)
        {
            difficulties[0] = "Normal";
            difficulties[1] = "Hard";
            difficulties[2] = "Insane";
            this.game = game;
            this.Font = font;
            volume = game.soundManager.volume;
            Resume = game.pauseSpriteFactory.GetNewResumeSprite();
            Resume.CurrentFrame = 1;
            SoundBar = game.pauseSpriteFactory.GetNewSoundBarSprite();
            Options = game.pauseSpriteFactory.GetNewOptionsSprite();
            Options.IsUISprite = true;
            Resume.IsUISprite = true;
            SoundBar.IsUISprite = true;
        }
        public void Reset()
        {
            Resume.CurrentFrame = 1;
            cursor = true;
            options = false;
            optionCursor = false;
            difficulty = 0;
        }
        private void getSoundFrame()
        {
            volume = game.soundManager.volume;
            if(volume <= 0.2f && volume > 0.0f)
            {
                SoundBar.CurrentFrame = 0;
            } else if (volume <= 0.4f && volume > 0.2f)
            {
                SoundBar.CurrentFrame = 1;
            } else if (volume <= 0.6f && volume > 0.4f)
            {
                SoundBar.CurrentFrame = 2;
            } else if (volume <= 0.8f && volume > 0.6f)
            {
                SoundBar.CurrentFrame = 3;
            } else if (volume <= 1.0f && volume > 0.8f)
            {
                SoundBar.CurrentFrame = 4;
            }
        }
        
        public void Update()
        {
            ResumeLoc = new Rectangle(new Point(330, 200), new Point(384, 64));
            OptionsLoc = new Rectangle(new Point(330, 300), new Point(384, 64));
            getSoundFrame();
        }
        public void increaseDifficulty()
        {
            int oldDifficulty = difficulty;
            if(difficulty < 2)
            {
                difficulty++;
            }
            Dictionary<Point, Level> dungeonLevels = game.GetDungeon().GetLevelDictionary();
            foreach (KeyValuePair<Point, Level> entry in dungeonLevels)
            {
                foreach(IEnemy enemy in entry.Value.GetEnemyList()) enemy.changeDifficulty(oldDifficulty + ARRAYOFFSET, difficulty + ARRAYOFFSET);
            }
        }
        public void decreaseDifficulty()
        {
            int oldDifficulty = difficulty;
            if (difficulty > 0)
            {
                difficulty--;
            }
            Dictionary<Point, Level> dungeonLevels = game.GetDungeon().GetLevelDictionary();
            foreach (KeyValuePair<Point, Level> entry in dungeonLevels)
            {
                foreach (IEnemy enemy in entry.Value.GetEnemyList()) enemy.changeDifficulty(oldDifficulty + ARRAYOFFSET, difficulty + ARRAYOFFSET);
            }
        }
        public void increaseVolume()
        {
            if(volume < VOLFULL)
            {
                volume += VOLSCALE;
            }
            game.soundManager.SetVolume(volume);
        }
        public void decreaseVolume()
        {
            if (volume > VOLOFF)
            {
                volume -= VOLSCALE;
            }
            game.soundManager.SetVolume(volume);
            
        }
        public void selectNextOptions()
        {
            optionCursor = !optionCursor;
        }
        public void toggleOptions()
        {
            options = !options;
        }
        public void executeButton()
        {
            if (!options)
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
            if (game.Paused() && !game.inventoryOpen)
            {
                if (options)
                {
                    batch.Draw(fadeImage, Backdrop, Color.Black * TINT);
                    getSoundFrame();
                    if(volume > 0) SoundBar.Draw(batch, SoundLoc);
                    batch.DrawString(Font, soundName, soundNameLoc, Color.White);
                    batch.DrawString(Font, difficultyName, difficultyNameLoc, Color.White);
                    batch.DrawString(Font, difficulties[difficulty], difficultyLoc, Color.White);
                    if (optionCursor)
                    {
                        batch.DrawString(Font, OptionSelector, difficultyCursorLoc, Color.White);
                    }
                    else
                    {
                        batch.DrawString(Font, OptionSelector, soundCursorLoc, Color.White);
                    }
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
