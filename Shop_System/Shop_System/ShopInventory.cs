using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_System
{
    class ShopInventory
    {
        private Items[] _itemList;
        private int _gold = 1500;

    public ShopInventory()
    {
        _itemList = new Items[7];
        _itemList[0] = new Armor("Jordan's", 200, 80, 2, "Can't be up in the streets with some dirty ass shoes now.");
        _itemList[1] = new Armor("Hello Kitty Watch", 2000, 3, 2, "Some watch my kid gave me, love you baby.");
        _itemList[2] = new Weapon("Glock", 20, 75, 1, "Always stay strapped homie.");
        _itemList[3] = new Armor("Blood Stained Shirt", 0, 5, 2, "Some clothes I picked from a hood rat tryna rob me.");
        _itemList[4] = new Armor("Light Weight BP Vest", 50, 100, 2, "You can't be rolling on them streets without one of these puppies son.");
        _itemList[5] = new Potions("Hashbrown", 15, 3, 3, "Yo fat ass know you want this, straigt form mickey D's boy.");
        _itemList[6] = new Potions("KFC Galon Bucket", 250, 350, 3, "If there is one thing all of us hood rats have in common its this stuff right here.");
    }

    public ShopInventory(Items[] newList)
    {
        _itemList = newList;
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
