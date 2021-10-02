using Microsoft.Xna.Framework;
using Sprint0.Helpers;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class Thrower : IEnemy
    {
        //Sprite for the enemy
        ISprite mySprite;
        //Position vector
        Vector2 pos;
        //State
        IEnemyState currState;
        IEnemyState IEnemy.State
        {
            get => currState;
            set => currState = value;
        }

        Vector2 IEnemy.Position
        {
            get => pos;
            set => pos = value;
        }
        ISprite IEnemy.Sprite 
        {
            get => mySprite;
            set => mySprite = value;
        }

        EnemyTypes IEnemy.Type
        {
            //Return boomerangThrower as type if requested
            get => EnemyTypes.Thrower;
        }

        void IEnemy.Update(GameTime gameTime)
        {
            mySprite.Position = pos;
            mySprite.Update(gameTime);
        }
        
        public Thrower()
        {
            //Default a new thrower as a left thrower
            currState = new LeftThrower(mySprite, this);
            //Assign an arbitrary starting positon for the thrower
            pos = new Vector2(500, 300);
        }
    }
}
