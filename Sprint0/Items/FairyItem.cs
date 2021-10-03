using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2.Items
{
    public class FairyItem : AbstractItem
    {
        public FairyItem(Vector2 pos) : base(ItemSpriteFactory.Instance.GetItemSprite(ItemEnum.Fairy), pos)
        {

        }
    }
}
