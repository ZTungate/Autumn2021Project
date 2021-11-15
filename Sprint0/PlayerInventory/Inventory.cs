using Poggus.Items;
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
        private int rupee = 0;
        private int keys = 0;
        protected bool hasMap = false;
        protected bool hasCompass = false;
        protected List<AbstractItem> itemList = new List<AbstractItem>();
        protected int Arrows { get => arrows; set => arrows = value; }
        protected int BlueArrows { get => blueArrows; set => blueArrows = value; }
        protected int Bombs { get => bombs; set => bombs = value; }
        protected int Rupees { get => rupee; set => rupee = value; }
        protected int Keys { get => keys; set => keys = value; }

        public Inventory()
        {
            
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
    }
}
