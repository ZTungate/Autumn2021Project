using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player;
using Sprint2.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public class PickUpLinkSprite : AbstractSprite
    {
        private AbstractItem myItem;
        ILink player;
        public PickUpLinkSprite(Texture2D spriteSheet, ILink player, AbstractItem item) : base(spriteSheet, new Rectangle[2])
        {
            this.player = player;
            myItem = item;

            SourceRect[0] = new Rectangle(213 , 11, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(230, 11, 16, 16);
            this.Interval = 128f;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }

        /*public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Texture, player.position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), (int)LinkConstants.scaleX, SpriteEffects.None, 1);
            //draw item above link
            Vector2 itemPos = new Vector2(player.position.X + (player.position.X - myItem.GetSprite().SourceRect[CurrentFrame].X)/2, player.position.Y - myItem.GetSprite().SourceRect[CurrentFrame].Y);
            myItem.SetRectangle(new Rectangle((int)(myItem.GetRectangle().X + itemPos.X), (int)(myItem.GetRectangle().Y + itemPos.Y), myItem.GetRectangle().Width, myItem.GetRectangle().Height));
            //TODO: Draw item 
            //myItem.Draw()

        }*/

    }
}
