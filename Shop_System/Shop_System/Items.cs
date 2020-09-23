using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_System
{
    class Items
    {

        protected int _value = 1;

        protected string _name = "";

        protected string _description;
        public virtual string GetName
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }

        public virtual int GetValue
        {
            set
            {
                _value = value;
            }
            get
            {
                return _value;
            }
        }

        public virtual int GetAttack
        {
            set
            {

            }
            get
            {
                return 0;
            }
        }

        public virtual int GetDefense
        {
            set
            {

            }
            get
            {
                return 0;
            }
        }

        public virtual int GetHealing
        {
            set
            {

            }
            get
            {
                return 0;
            }
        }

        public string GetDescription
        {
            set
            {
                _description = value;
            }
            get
            {
                return _description;
            }
        }

        public virtual int GetID
        {
            set
            {

            }
            get
            {
                return 0;
            }
        }
    }
}
