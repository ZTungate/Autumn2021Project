using Microsoft.Xna.Framework;
using Sprint0.Helpers;
using Sprint2;
using Sprint2.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class Dragon : IEnemy
    {
        //ISprite for the enemy
        ISprite mySprite;
        public ISprite Sprite
        {
            //Allow sprite to be set by the spriteFactory, and return mySprite when requested.
            get => mySprite;
            set => mySprite = value;
        }

        public EnemyTypes Type
        {
            //Return Dragon if type is ever asked for.
            get => EnemyTypes.Dragon;
        }

        public void Update(GameTime gameTime)
        {
            //Update the sprite
            mySprite.Update(gameTime);
        }
        public Dragon()
        {
            //Nothing special about the dragon object itself, no implementation required
        }
    }
}
