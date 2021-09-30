using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{
    public class Player{

        IPlayerState playerState;
        struct Position
        {
            int x;
            int y;
        }
        public Player()
        {
            playerState = new RightIdleState(); //start the player in the right idle state
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw playerSprite here
            playerState.Draw(spriteBatch);
        }
    }
}