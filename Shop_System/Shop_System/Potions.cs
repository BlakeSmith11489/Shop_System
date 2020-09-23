using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_System
{
    class Potions : Items
    {
        private int _healing;
        private int _itemID;

        //Constructor
        public Potions(string newName, int newHealing, int newValue, int newItemID, string newDescription)
        {
            _name = newName;
            _healing = newHealing;
            _value = newValue;
            _itemID = newItemID;
            _description = newDescription;
            if (_value < 0)
            {
                _value = 0;
            }
        }

        public override int GetHealing
        {
            set
            {
                _healing = value;
            }
            get
            {
                return _healing;
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
    }
}
