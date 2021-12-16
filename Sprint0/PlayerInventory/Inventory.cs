using Microsoft.Xna.Framework;
using Poggus.Items;
using Poggus.Items.ItemSprites;
using Poggus.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.PlayerInventory
{
    public class Inventory
    {
        private int arrows = 0; //added for testing: TO REMOVE
        private int blueArrows = 0;
        private int bombs = 0;
        private int rupee = 0;
        private int keys = 0;
        private AbstractItem slotA;
        private AbstractItem slotB;
        protected bool hasMap = false;
        protected bool hasCompass = false;
        protected List<AbstractItem> itemList = new List<AbstractItem>();
        protected int Arrows { get => arrows; set => arrows = value; }
        protected int BlueArrows { get => blueArrows; set => blueArrows = value; }
        protected int Bombs { get => bombs; set => bombs = value; }
        protected int Rupees { get => rupee; set => rupee = value; }
        protected int Keys { get => keys; set => keys = value; }
        protected AbstractItem SlotA { get => slotA; set => slotA = value; }
        int slotBIndex = 1;
        
        public Inventory()
        {
            AddItem(new SwordItem(Point.Zero));
        }

        public void setSlotB(AbstractItem item)
        {
            slotBIndex = itemList.IndexOf(item);


        }

        public int getSlotBIndex()
        {
            return slotBIndex;
        }
        public AbstractItem getSlotB()
        {
            if (itemList.Count > 1) {
                return itemList[slotBIndex];
            }
            else {
                return null;
            }
        }


        public AbstractItem getSlotA()
        {
            return itemList[0];
        }
        public void IncrementBlueArrows()
        {
            BlueArrows++;
        }

        public void DecrementBlueArrows()
        {
            BlueArrows--;
        }

        public int GetBlueArrowCount()
        {
            return BlueArrows;
        }

        public void IncrementKeys()
        {
            Keys++;
        }

        public void DecrementKeys()
        {
            Keys--;
        }

        public int GetKeyCount()
        {
            return Keys;
        }
        public void IncrementArrows()
        {
            Arrows++;
        }

        public void DecrementArrows()
        {
            Arrows--;
        }

        public int GetArrowCount()
        {
            return Arrows;
        }

        public void IncrementBombs()
        {
            Bombs ++;
        }

        public void DecrementBombs()
        {
            Bombs--;
            if (Bombs == 0) {
                
                AbstractItem bombToRemove = null;
                foreach (AbstractItem item in itemList) {
                    if (item is BombItem) {
                        bombToRemove = item;
                    }
                }
                itemList.Remove(bombToRemove);
                if (itemList.Count > 1) {
                    slotBIndex = 1;
                }
            }
        }

        public int GetBombCount()
        {
            return Bombs;
        }

        public void IncrementRupees()
        {
            Rupees++;
        }

        public void DecrementRupees()
        {
            Rupees--;
        }

        public int GetRupeeCount()
        {
            return Rupees;
        }

        public bool GetMapState()
        {
            return hasMap;
        }

        public void AddMap()
        {
            hasMap = true;
        }
        public bool GetCompassState()
        {
            return hasCompass;
        }

        public void AddCompass()
        {
            hasCompass = true;
        }
        public void AddItem(AbstractItem toAdd)
        {
            itemList.Add(toAdd);

        }
        public void RemoveItem(AbstractItem toRemove)
        {
            itemList.Remove(toRemove);

        }
        public bool CheckItem(AbstractItem check)
        {
            return itemList.Contains(check);

        }
        public List<AbstractItem> GetItemList()
        {
            return this.itemList;
        }
    }
}
