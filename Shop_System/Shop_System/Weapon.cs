using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_System
{
    class Weapon : Items
    {
        private int _damage;
        private int _itemID;

        public override int GetAttack
        {
            set
            {
                _damage = value;
            }
            get
            {
                return _damage;
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
        public Weapon(string newName, int newDamage, int newValue, int newItemID, string newDescription)
        {
            _name = newName;
            _damage = newDamage;
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
