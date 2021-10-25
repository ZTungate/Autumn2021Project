using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Enemies;
using Sprint2.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class Grabber : IEnemy
    {
        //ISprite for the enemy
        ISprite mySprite;
        //Position vector
        Vector2 pos;
        //State for this enemy (unused for now for this type)
        IEnemyState currState;
        IEnemyState IEnemy.State
        {
            //For this enemy type, this should not be used yet.
            get => currState;
            set => currState = value;
        }
        Vector2 IEnemy.Position
        {
            get => pos;
            set => pos = value;
        }
        public ISprite Sprite
        {
            //Allow sprite to be set by the spriteFactory, and return mySprite when requested.
            get => mySprite;
            set => mySprite = value;
        }
        public EnemyTypes Type
        {
            //Return Dragon if type is ever asked for.
            get => EnemyTypes.Grabber;
        }

        public void Update(GameTime gameTime)
        {
            //Update the sprite
            mySprite.Position = pos;
            mySprite.Update(gameTime);
        }
        public Grabber(Vector2 pos)
        {
            //Assign position to the given location.
            this.pos = pos;
        }

        
    }
}
