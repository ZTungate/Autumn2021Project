using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class DownThrower : IEnemyState
    {
        private ISprite mySprite;
        private IEnemy thrower;
        public DownThrower(ISprite sprite, IEnemy enemy)
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
            //No implementation needed
        }

        public void TurnLeft()
        {
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new LeftThrowerSprite(texture);
            //manually assign the sprite for leftThrower (leftthrower can't since it is the default.)
            thrower.Sprite = mySprite;
            thrower.Sprite.Position = thrower.Position;
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
            Texture2D texture = thrower.Sprite.Texture;
            mySprite = new UpThrowerSprite(texture);
            thrower.State = new UpThrower(mySprite, thrower);
        }
        public void MoveForward()
        {
            //Get the current position of the thrower
            Vector2 newPos = thrower.Position;
            //Move the thrower the relevant direction to the current state.
            newPos.Y += 5;
            //Set the thrower's position to the new pos.
            thrower.Position = newPos;
        }
        public Vector2 AttackDirection()
        {
            //Return a vector pointing downwards
            return new Vector2(0, 1);
        }
        public void Update(GameTime gameTime, ISprite enemySprite)
        {
            //mySprite = enemySprite;
        }
    }
}
