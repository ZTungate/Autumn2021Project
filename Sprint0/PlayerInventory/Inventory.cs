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
        private int arrows = 5; //added for testing: TO REMOVE
        private int blueArrows = 5;
        private int bombs = 5;
        private int rupee = 5;
        private int keys = 0;
        private AbstractItem slotA;
        private AbstractItem slotB;
        protected bool hasMap = true;
        protected bool hasCompass = true;
        protected List<AbstractItem> itemList = new List<AbstractItem>();
        protected int Arrows { get => arrows; set => arrows = value; }
        protected int BlueArrows { get => blueArrows; set => blueArrows = value; }
        protected int Bombs { get => bombs; set => bombs = value; }
        protected int Rupees { get => rupee; set => rupee = value; }
        protected int Keys { get => keys; set => keys = value; }
        protected AbstractItem SlotA { get => slotA; set => slotA = value; }
        protected AbstractItem SlotB { get => slotB; set => slotB = value; }
        
        public Inventory()
        {

            
        }
        public void setSlotA(AbstractItem item)
        {
            item.CreateSprite();
            SlotA = item;
        }
        public void setSlotB(AbstractItem item)
        {
            SlotB = item;
        }
        public AbstractItem getSlotB()
        {
            return SlotB;
        }

        public AbstractItem getSlotA()
        {
            return slotA;
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
