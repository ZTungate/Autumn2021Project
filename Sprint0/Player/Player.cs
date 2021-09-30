using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{
    public struct Position
    {
        public float x;
        public float y;
    }
    public class Player{
        

        IPlayerState playerState;
        public Position position;

        public Player()
        {
            playerState = new RightIdleState(); //start the player in the right idle state
            position = new Position { x = 20, y = 20 };
        }

        public void Draw(SpriteBatch spriteBatch, Position playerPosition)
        {
            //Draw playerSprite here
            playerState.Draw(spriteBatch, playerPosition);
        }
    }
}