using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class RightThrower : IEnemyState
    {
        private ISprite mySprite;
        private IEnemy thrower;
        public RightThrower(ISprite sprite, IEnemy enemy)
        {
            //Get the sprite and enemy passed in, and the position of the enemy
            mySprite = sprite;
            mySprite.Position = enemy.Position;
            thrower = enemy;
            //Set the enemy's sprite to this state's sprite.
            thrower.Sprite = mySprite;
        }

        public void TurnDown()
        {
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new DownThrowerSprite(texture);
            thrower.State = new DownThrower(mySprite, thrower);
        }

        public void TurnLeft()
        {
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new LeftThrowerSprite(texture);
            thrower.State = new LeftThrower(mySprite, thrower);
        }

        public void TurnRight()
        {
            //No implementation needed
        }

        public void TurnUp()
        {
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new UpThrowerSprite(texture);
            thrower.State = new UpThrower(mySprite, thrower);
        }
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
            mySprite = enemySprite;
        }
    }
}
