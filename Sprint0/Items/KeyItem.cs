using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2.Items
{
    public class KeyItem : AbstractItem
    {
        public KeyItem(Vector2 pos) : base(ItemSpriteFactory.Instance.GetItemSprite(ItemEnum.Key), pos)
        {

        }
    }
}
