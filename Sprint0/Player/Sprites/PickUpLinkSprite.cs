using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using Poggus.Items;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;

namespace Poggus.Player
{
    public class PickUpLinkSprite : AbstractSprite
    {
        private AbstractItem myItem;
        ILink player;
        public PickUpLinkSprite(Texture2D spriteSheet, ILink player, AbstractItem item) : base(spriteSheet, new Rectangle[1])
        {
            this.player = player;
            myItem = item;

            if (item is TriforcePieceItem) {
                SourceRect[0] = new Rectangle(230, 11, 16, 16);
            }
            else {
                SourceRect[0] = new Rectangle(213, 11, 16, 16);  //Set the frame for right idle link
            }
            this.Interval = LinkConstants.pickupAnimInterval;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Rectangle rect)
        {
            //LayerDepth set to 1, normally this would mean this object will always been drawn in front but because of Begin() call in Game1 objects are drawn in the order their Draw() method is called
            //spriteBatch.Draw(Texture, rect, SourceRect[CurrentFrame], Color, 0, Vector2.Zero, effects, 1);
            base.Draw(spriteBatch, rect);

            if (myItem is TriforcePieceItem) {
                myItem.SetPosition(LocationHelpers.GetLocationCenteredSpawnUp(player.DestRect, myItem.GetRectangle().Size));
            }
            else {
                myItem.SetPosition(LocationHelpers.GetLocationLeftJustifiedSpawnUp(player.DestRect, myItem.GetRectangle().Size));
            }
            myItem.Draw(spriteBatch);
        }

    }
}
