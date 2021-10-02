using Microsoft.Xna.Framework;
using Sprint0.Helpers;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class BoomerangThrower : IEnemy
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
            get => EnemyTypes.BoomerangThrower;
        }

        void IEnemy.Update(GameTime gameTime)
        {
            mySprite.Update(gameTime);
        }
        
        public BoomerangThrower()
        {
            //Default a new thrower as a left thrower
            currState = new LeftThrower(mySprite, this);
        }
    }
}
