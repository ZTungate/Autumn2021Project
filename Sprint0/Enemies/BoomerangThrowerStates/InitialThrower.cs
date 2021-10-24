using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class InitialThrower : IEnemyState
    {
/*        private ISprite mySprite;*/
        private IEnemy thrower;
        public InitialThrower(ISprite sprite, IEnemy enemy)
        {
            thrower = enemy;
            enemy.Sprite = sprite;//enemy.Sprite is null
        }

        //No Turn methods, may need to switch order of methods in Thrower if error

        public void MoveForward()
        {
            //Get the current position of the thrower
            Vector2 newPos = thrower.Position;
            //Move the thrower the relevant direction to the current state.
            newPos.X += 5;
            //Set the thrower's position to the new pos.
            thrower.Position = newPos;
        }
        public Vector2 AttackDirection()
        {
            //Return a vector pointing Right
            return new Vector2(1, 0);
        }
        public void Update(GameTime gameTime, ISprite enemySprite)
        {
            /*mySprite = enemySprite;*/
        }
    }
}
