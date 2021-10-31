using System;
using System.Collections.Generic;
using System.Text;

namespace LevelCreator.LevelObjects
{
    public enum LevelObjectType
    {
        Block, Enemy, Item
    }
    public static class LevelObjectTypeHelper{

        public static LevelObjectType TypeToString(string type)
        {
            if (type.ToUpper() == "BLOCK")
            {
                return LevelObjectType.Block;
            }
            if (type.ToUpper() == "ITEM")
            {
                return LevelObjectType.Item;
            }
            if (type.ToUpper() == "ENEMY")
            {
                return LevelObjectType.Enemy;
            }

            return LevelObjectType.Block;
        }
    }
}
