using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_System
{
    class PlayerInventory
    {
        private Items[] _itemList = new Items[4];
        private int _gold = 1000;


        public PlayerInventory()
        {
            _itemList[0] = new Weapon("These hands fool", 7, 5, 1, "Get too close and you gonna get em son.");
            _itemList[1] = new Armor("Bandana", 30, 75, 2, "Nothing like repping your color while rolling through the streets.");
            _itemList[2] = new Armor("Rolex", 25, 60, 2, "If you ain't got you one of these you a broke ass dude.");
            _itemList[3] = new Armor("Yo Saggy Ass Pants", 80, 300, 2, "Never pick these things up, They define what it means to be a street rat.");
        }

        public int Gold
        {
            set
            {
                _gold = value;
            }
            get
            {
                return _gold;
            }


        }

        public int InventoryLength
        {
            set
            {
                _itemList = new Items[value];
            }
            get
            {
                return _itemList.Length;
            }
        }

        public Items[] GetItemList
        {
            set
            {
                _itemList = value;
            }
            get
            {
                return _itemList;
            }
        }

        public Items[] Add(Items item)
        {
            Items[] newInventory = new Items[_itemList.Length + 1];

            for (int i = 0; i < _itemList.Length; i++)
            {
                newInventory[i] = _itemList[i];
            }

            newInventory[newInventory.Length - 1] = item;

            _itemList = newInventory;

            return _itemList;
        }

        public Items[] Remove(int index)
        {
            Items[] newList = new Items[_itemList.Length - 1];

            int n = 0;

            for (int i = 0; i < _itemList.Length; i++)
            {
                if (i != index)
                {
                    newList[n] = _itemList[i];
                    n++;
                }
            }

            _itemList = newList;

            return _itemList;
        }
    }
}
