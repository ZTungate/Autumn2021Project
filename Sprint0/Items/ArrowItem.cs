using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2.Items
{
    public class ArrowItem : AbstractItem
    {
        public ArrowItem(Vector2 pos) : base(ItemSpriteFactory.Instance.GetItemSprite(ItemEnum.Arrow), pos)
        {

        }
    }
}
