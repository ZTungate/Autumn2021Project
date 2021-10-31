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
        private ISprite mySprite;
        private IEnemy thrower;
        public UpThrower(ISprite sprite, IEnemy enemy)
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
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new RightThrowerSprite(texture);
            thrower.State = new RightThrower(mySprite, thrower);
        }

        public void TurnUp()
        {
            //Already facing up, no implementation required.
        }

        public void MoveForward()
        {
            //Get the current position of the thrower
            Vector2 newPos = thrower.Position;
            //Move the thrower the relevant direction to the current state.
            newPos.Y -= EnemyConstants.throwerMoveSpeed;
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
            mySprite = enemySprite;
        }
    }
}
