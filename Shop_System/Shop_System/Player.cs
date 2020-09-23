using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Shop_System
{
    class Player
    {
        private PlayerInventory _bag = new PlayerInventory();

        private string _name;

        public Player(string name)
        {
            _name = name;
        }
        public string GetName
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

        public PlayerInventory GetInventory()
        {
            return _bag;
        }

        public void SavePlayer(string path)
        {
            StreamWriter writer = File.CreateText(path);

            writer.WriteLine(GetInventory().InventoryLength);
            writer.WriteLine(GetName);


            for (int i = 0; i < GetInventory().GetItemList.Length; i++)
            {
                writer.WriteLine(GetInventory().GetItemList[i].GetID);


                if (GetInventory().GetItemList[i].GetID == 1)
                {
                    writer.WriteLine(GetInventory().GetItemList[i].GetName);
                    writer.WriteLine(GetInventory().GetItemList[i].GetAttack);
                }
                else if (GetInventory().GetItemList[i].GetID == 2)
                {
                    writer.WriteLine(GetInventory().GetItemList[i].GetName);
                    writer.WriteLine(GetInventory().GetItemList[i].GetDefense);
                }
                else if (GetInventory().GetItemList[i].GetID == 3)
                {
                    writer.WriteLine(GetInventory().GetItemList[i].GetName);
                    writer.WriteLine(GetInventory().GetItemList[i].GetHealing);
                }
                writer.WriteLine(GetInventory().GetItemList[i].GetValue);
                writer.WriteLine(GetInventory().GetItemList[i].GetDescription);
            }

            writer.WriteLine(GetInventory().Gold);

            writer.Close();
        }

        public void LoadPlayer(string path)
        {
            if (File.Exists(path))
            {
                StreamReader reader = File.OpenText(path);

                GetInventory().InventoryLength = Convert.ToInt32(reader.ReadLine());

                GetName = reader.ReadLine();

                Items[] newList = new Items[GetInventory().InventoryLength];

                int itemID;

                for (int i = 0; i < GetInventory().InventoryLength; i++)
                {
                    itemID = Convert.ToInt32(reader.ReadLine());

                    //If Attack item
                    if (itemID == 1)
                    {
                        Weapon attackItem = new Weapon(reader.ReadLine(),//Item Name
                            Convert.ToInt32(reader.ReadLine()),//Item damage
                            Convert.ToInt32(reader.ReadLine()),//Item value
                            itemID,//Item ID
                            reader.ReadLine());//item Description

                        GetInventory().GetItemList[i] = attackItem;
                    }
                    //If Defense item
                    else if (itemID == 2)
                    {
                        Armor defenseItem = new Armor(reader.ReadLine(),//Item Name
                            Convert.ToInt32(reader.ReadLine()),//Item defense
                            Convert.ToInt32(reader.ReadLine()),//Item value
                            itemID,//Item ID
                            reader.ReadLine());//item Description

                        GetInventory().GetItemList[i] = defenseItem;
                    }
                    //If consumable item
                    else if (itemID == 3)
                    {
                        Potions consumables = new Potions(reader.ReadLine(),//Item Name
                            Convert.ToInt32(reader.ReadLine()),//Item healing
                            Convert.ToInt32(reader.ReadLine()),//Item value
                            itemID,//Item ID
                            reader.ReadLine());//item Description

                        GetInventory().GetItemList[i] = consumables;
                    }
                }

                GetInventory().Gold = Convert.ToInt32(reader.ReadLine());

                reader.Close();
            }
        }
    }
}
