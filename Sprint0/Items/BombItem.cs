using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2.Items
{
    public class BombItem : AbstractItem
    {
        public BombItem(Vector2 pos) : base(ItemSpriteFactory.Instance.GetItemSprite(ItemEnum.Bomb), pos)
        {

        }
    }
}
