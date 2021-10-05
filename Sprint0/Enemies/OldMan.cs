using Microsoft.Xna.Framework;
using Sprint2.Helpers;
using Sprint2;
using Sprint2.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class OldMan : IEnemy
    {
        //ISprite for the old man
        ISprite mySprite;

        //Position of the old man.
        Vector2 pos;
        //State of the old man (not used for this enemy type)
        IEnemyState state;
        public ISprite Sprite
        {
            get => mySprite;
            set => mySprite = value;
        }
        public EnemyTypes Type
        {
            get => EnemyTypes.OldMan;
        }
        public Vector2 Position 
        {
            get => pos;
            set => pos = value;
        }
        public IEnemyState State 
        {
            //This should not be used.
            get => state;
            set => state = value;
        }

        public void Update(GameTime gameTime)
        {
            mySprite.Position = pos;
            mySprite.Update(gameTime);
        }

        public OldMan()
        {
            //Assign an arbitrary starting positon for the old man.
            pos = new Vector2(500, 300);
        }

    }
}
