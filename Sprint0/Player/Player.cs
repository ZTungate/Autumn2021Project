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
        
        //Game class contains a sprite factory, which creates each sprite with a source rectangle. this is saved in spriteBatch
        //spritebatch is passed down to the state in the player class (this file), which is sent to the state. The state actually draws the image.

        IPlayerState playerState;
        public Position position;

        public Player()
        {
            playerState = new RightIdleState(); //start the player in the right idle state
            position = new Position { x = 20, y = 20 };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw playerSprite here
            playerState.Draw(spriteBatch, position);
        }
    }
}