using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_System
{
    class Armor : Items
    {
        private int _defense;
        private int _itemID;

        public override int GetDefense
        {
            set
            {
                _defense = value;
            }
            get
            {
                return _defense;
            }
        }
        public override int GetID
        {
            set
            {
                _itemID = value;
            }
            get
            {
                return _itemID;
            }
        }

        //Constructor
        public Armor(string newName, int newDefense, int newValue, int newItemID, string newDescription)
        {
            _name = newName;
            _defense = newDefense;
            _value = newValue;
            _itemID = newItemID;
            _description = newDescription;
            if (_value < 0)
            {
                _value = 0;
            }
        }
    }
}
