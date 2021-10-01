using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{

    public class Link{
        
        //Game class contains a sprite factory, which creates each sprite with a source rectangle. this is saved in spriteBatch
        //spritebatch is passed down to the state in the player class (this file), which is sent to the state. The state actually draws the image.

        IPlayerState playerState;
        public Vector2 position;
        public ISprite sprite;

        public Link()
        {
            playerState = new RightIdleState(); //start the player in the right idle state
            position = new Vector2(20,20);  //Link's initial position
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            /*playerState.Update();*/
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);   //draw the player sprite
            /*playerState.Draw(SpriteBatch);*/
        }
    }
}