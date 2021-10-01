using Microsoft.Xna.Framework;
using Sprint0.Helpers;
using Sprint2;
using Sprint2.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class OldMan : IEnemy
    {
        //ISprite for the old man
        ISprite mySprite;
        
        public ISprite Sprite
        {
            get => mySprite;
            set => mySprite = value;
        }
        public EnemyTypes Type
        {
            get => EnemyTypes.OldMan;
        }

        public void Update(GameTime gameTime)
        {
            mySprite.Update(gameTime);
        }

        public OldMan()
        {
            //No implementation needed.
        }

    }
}
