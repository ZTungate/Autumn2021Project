using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class UpThrower : IEnemyState
    {
        /*private ISprite mySprite;*/
        private IEnemy thrower;
        public UpThrower(IEnemy enemy)
        {
            enemy.Sprite = new UpThrowerSprite(enemy.Sprite.Texture);   //Set the enemy's sprite to this state's sprite.
            enemy.Sprite.Position = enemy.Position;                     //Set the enemy's sprite position to the enemy's position
            thrower = enemy;                                            //update state's enemy to match the actual enemy
        }

        /* public void TurnDown()
         {
             Texture2D texture = thrower.Sprite.Texture;
             mySprite = new DownThrowerSprite(texture);
         }

         public void TurnLeft()
         {
             Texture2D texture = thrower.Sprite.Texture;
             mySprite = new LeftThrowerSprite(texture);
             //manually assign the sprite for leftThrower (leftthrower can't since it is the default.)
             thrower.Sprite = mySprite;
             thrower.Sprite.Position = thrower.Position;
         }

         public void TurnRight()
         {
             Texture2D texture = thrower.Sprite.Texture;
             mySprite = new RightThrowerSprite(texture);
         }

         public void TurnUp()
         {
             //Already facing up, no implementation required.
         }*/

        public void MoveForward()
        {
            //Get the current position of the thrower
            Vector2 newPos = thrower.Position;
            //Move the thrower the relevant direction to the current state.
            newPos.Y -= 5;
            //Set the thrower's position to the new pos.
            thrower.Position = newPos;
        }
        public Vector2 AttackDirection()
        {
            //Return a vector pointing up.
            return new Vector2(0, -1);
        }
        public void Update(GameTime gameTime, ISprite enemySprite)
        {
            thrower.Sprite = enemySprite;
        }
    }
}
