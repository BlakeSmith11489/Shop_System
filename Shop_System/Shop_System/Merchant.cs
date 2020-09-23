using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Shop_System
{
    class Merchant
    {
        private string _name = "Merchant";


        private ShopInventory _shopInventory;

        public Merchant()
        {
            _shopInventory = new ShopInventory();
        }

        public Merchant(ShopInventory newInventory)
        {
            _shopInventory = newInventory;
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

        public ShopInventory GetInventory()
        {
            return _shopInventory;
        }

        public void SaveMerchant(string path)
        {
            StreamWriter writer = File.CreateText(path);

            writer.WriteLine(GetInventory().InventoryLength);
            writer.WriteLine(GetName);


            for (int i = 0; i < GetInventory().GetItemList.Length; i++)
            {
                writer.WriteLine(GetInventory().GetItemList[i].GetID);


                //Weapon
                if (GetInventory().GetItemList[i].GetID == 1)
                {
                    writer.WriteLine(GetInventory().GetItemList[i].GetName);
                    writer.WriteLine(GetInventory().GetItemList[i].GetAttack);
                }
                //Armor
                else if (GetInventory().GetItemList[i].GetID == 2)
                {
                    writer.WriteLine(GetInventory().GetItemList[i].GetName);
                    writer.WriteLine(GetInventory().GetItemList[i].GetDefense);
                }
                //Potions
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

        public void LoadMerchant(string path)
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

                    if (itemID == 1)
                    {
                        Weapon attackItem = new Weapon(reader.ReadLine(),//Name
                            Convert.ToInt32(reader.ReadLine()),//Stat
                            Convert.ToInt32(reader.ReadLine()),//Value
                            itemID,//ID
                            reader.ReadLine());//Description

                        GetInventory().GetItemList[i] = attackItem;
                    }

                    else if (itemID == 2)
                    {
                        Armor defenseItem = new Armor(reader.ReadLine(),
                            Convert.ToInt32(reader.ReadLine()),
                            Convert.ToInt32(reader.ReadLine()),
                            itemID,
                            reader.ReadLine());

                        GetInventory().GetItemList[i] = defenseItem;
                    }

                    else if (itemID == 3)
                    {
                        Potions consumables = new Potions(reader.ReadLine(),
                            Convert.ToInt32(reader.ReadLine()),
                            Convert.ToInt32(reader.ReadLine()),
                            itemID,
                            reader.ReadLine());

                        GetInventory().GetItemList[i] = consumables;
                    }
                }

                GetInventory().Gold = Convert.ToInt32(reader.ReadLine());

                reader.Close();
            }
        }

    }
}
