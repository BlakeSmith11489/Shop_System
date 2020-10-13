using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Shop_System
{
    class Shop
    {
        private Merchant _merchant;
        private Player _player;


        public Shop(Player player, Merchant merchant)
        {
            _player = player;
            _merchant = merchant;
        }

        public void ShopMenu()
        {
            Console.Clear();
            Console.WriteLine("What up my dude, " + _player.GetName + "!");
            string choice = "";
            while (choice != "0")
            {
                Console.Clear();
                Console.WriteLine("What you tryna do bruh?");
                Console.WriteLine("0: Exit\n1: Buy\n2: Sell\n3:Open Shop");
                Console.WriteLine(_player.GetName + ": " + _player.GetInventory().Gold);
                choice = Console.ReadLine();

                if (choice == "0")
                {
                    return;
                }
                else if (choice == "1")
                {
                    BuyingMenu();
                }
                else if (choice == "2")
                {
                    SellingMenu();
                }
                else if (choice == "Cheat Stuff")
                {
                    UserEditingMenu();
                }
            }
        }

        public void BuyingMenu()
        {

            int choice = 1;

            while (choice != 0 && _merchant.GetInventory().GetItemList.Length > 0)
            {
                Console.Clear();

                Console.WriteLine("What you want boy?\n");


                Console.WriteLine("0: Exit\n");

                //Iterates through the shop inventory array to display info to the user.
                for (int i = 0; i < _merchant.GetInventory().GetItemList.Length; i++)
                {
                    Console.WriteLine((i + 1) + ": " + _merchant.GetInventory().GetItemList[i].GetName);
                    Console.WriteLine("Cash: " + _merchant.GetInventory().GetItemList[i].GetValue + "\n");
                }
                Console.WriteLine(_player.GetName + ": " + _player.GetInventory().Gold + "        " + _merchant.GetName + ": " + _merchant.GetInventory().Gold);
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice - 1 >= 0 && choice - 1 < _merchant.GetInventory().GetItemList.Length)
                {
                    choice -= 1;

                    if (_merchant.GetInventory().GetItemList[choice].GetID == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Name: " + _merchant.GetInventory().GetItemList[choice].GetName);
                        Console.WriteLine("Damage: " + _merchant.GetInventory().GetItemList[choice].GetAttack);
                        Console.WriteLine("Value: " + _merchant.GetInventory().GetItemList[choice].GetValue);
                        Console.WriteLine("\n" + _merchant.GetInventory().GetItemList[choice].GetDescription + "\n");
                        Console.WriteLine("Buy?\nyes      No");
                        string decide = Console.ReadLine();
                        if (decide == "yes")
                        {
                            PlayerBuying(choice);
                        }
                    }
                    else if (_merchant.GetInventory().GetItemList[choice].GetID == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Name: " + _merchant.GetInventory().GetItemList[choice].GetName);
                        Console.WriteLine("Defense: " + _merchant.GetInventory().GetItemList[choice].GetDefense);
                        Console.WriteLine("Value: " + _merchant.GetInventory().GetItemList[choice].GetValue);
                        Console.WriteLine("\n" + _merchant.GetInventory().GetItemList[choice].GetDescription + "\n");
                        Console.WriteLine("Buy?\nyes      No");
                        string decide = Console.ReadLine();
                        if (decide == "yes")
                        {
                            PlayerBuying(choice);
                        }
                    }
                    else if (_merchant.GetInventory().GetItemList[choice].GetID == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Name: " + _merchant.GetInventory().GetItemList[choice].GetName);
                        Console.WriteLine("Healing: " + _merchant.GetInventory().GetItemList[choice].GetHealing);
                        Console.WriteLine("Value: " + _merchant.GetInventory().GetItemList[choice].GetValue);
                        Console.WriteLine("\n" + _merchant.GetInventory().GetItemList[choice].GetDescription + "\n");
                        Console.WriteLine("Buy?\nyes      No");
                        string decide = Console.ReadLine();
                        if (decide == "yes")
                        {
                            PlayerBuying(choice);
                        }
                    }
                }

                Console.Clear();
            }

            if (_merchant.GetInventory().GetItemList.Length <= 0)
            {
                Console.Clear();
                Console.WriteLine("This broke dude ain't got a damn thing.");
                Console.ReadKey();
            }
        }

        //Displays possible items that can be sold from player inventory
        public void SellingMenu()
        {
            int choice = 1;

            while (choice != 0 && _player.GetInventory().GetItemList.Length > 0)
            {
                Console.Clear();

                Console.WriteLine("What you tryna get rid of my dude?\n");

                Console.WriteLine("0: Exit\n");

                //Iterates through the player Inventory to display info to the user


                for (int i = 0; i < _player.GetInventory().GetItemList.Length; i++)
                {
                    Console.WriteLine((i + 1) + ": " + _player.GetInventory().GetItemList[i].GetName);
                    Console.WriteLine("Cash: " + _player.GetInventory().GetItemList[i].GetValue + "\n");
                }
                Console.WriteLine(_player.GetName + ": " + _player.GetInventory().Gold + "        " + _merchant.GetName + ": " + _merchant.GetInventory().Gold);
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice - 1 >= 0 && choice - 1 < _player.GetInventory().GetItemList.Length)
                {
                    choice -= 1;

                    if (_player.GetInventory().GetItemList[choice].GetID == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Name: " + _player.GetInventory().GetItemList[choice].GetName);
                        Console.WriteLine("Damage: " + _player.GetInventory().GetItemList[choice].GetAttack);
                        Console.WriteLine("Value: " + _player.GetInventory().GetItemList[choice].GetValue);
                        Console.WriteLine("\n" + _player.GetInventory().GetItemList[choice].GetDescription + "\n");
                        Console.WriteLine("Sell?\nyes      no");
                        string decide = Console.ReadLine();
                        if (decide == "yes")
                        {
                            PlayerSelling(choice);
                        }
                    }
                    else if (_player.GetInventory().GetItemList[choice].GetID == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Name: " + _player.GetInventory().GetItemList[choice].GetName);
                        Console.WriteLine("Defense: " + _player.GetInventory().GetItemList[choice].GetDefense);
                        Console.WriteLine("Value: " + _player.GetInventory().GetItemList[choice].GetValue);
                        Console.WriteLine("\n" + _player.GetInventory().GetItemList[choice].GetDescription + "\n");
                        Console.WriteLine("Sell?\nyes      no");
                        string decide = Console.ReadLine();
                        if (decide == "yes")
                        {
                            PlayerSelling(choice);
                        }
                    }
                    else if (_player.GetInventory().GetItemList[choice].GetID == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Name: " + _player.GetInventory().GetItemList[choice].GetName);
                        Console.WriteLine("Healing: " + _player.GetInventory().GetItemList[choice].GetHealing);
                        Console.WriteLine("Value: " + _player.GetInventory().GetItemList[choice].GetValue);
                        Console.WriteLine("\n" + _player.GetInventory().GetItemList[choice].GetDescription + "\n");
                        Console.WriteLine("Sell?\nyes      no");
                        string decide = Console.ReadLine();
                        if (decide == "yes")
                        {
                            PlayerSelling(choice);
                        }
                    }
                }


            }

            if (_player.GetInventory().GetItemList.Length <= 0)
            {
                Console.Clear();
                Console.WriteLine("You got nothing to sell homie.");
                Console.ReadKey();
            }
        }

        public void PlayerBuying(int choice)
        {

            if (_player.GetInventory().Gold >= _merchant.GetInventory().GetItemList[choice].GetValue)
            {
                _player.GetInventory().Gold -= _merchant.GetInventory().GetItemList[choice].GetValue;
                _merchant.GetInventory().Gold += _merchant.GetInventory().GetItemList[choice].GetValue;

                _player.GetInventory().Add(_merchant.GetInventory().GetItemList[choice]);
                _merchant.GetInventory().Remove(choice);

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bruh you broke as hell, get outta here with that. \n");
                Console.ReadKey();
            }
        }

        public void PlayerSelling(int choice)
        {

            if (_merchant.GetInventory().Gold >= _player.GetInventory().GetItemList[choice].GetValue)
            {
                //Gold is added to the player and subtracted from the merchant
                _merchant.GetInventory().Gold -= _player.GetInventory().GetItemList[choice].GetValue;
                _player.GetInventory().Gold += _player.GetInventory().GetItemList[choice].GetValue;

                //Player item is added to shop inventory and removed from player inventory
                _merchant.GetInventory().Add(_player.GetInventory().GetItemList[choice]);
                _player.GetInventory().Remove(choice);
            }
            else if (_merchant.GetInventory().Gold < _player.GetInventory().GetItemList[choice].GetValue)
            {
                Console.Clear();
                Console.WriteLine("Ya boi " + _merchant.GetName + " got: " + _merchant.GetInventory().Gold + "\nWorth: " + _player.GetInventory().GetItemList[choice].GetValue + "\n1: Still wanna give it? \nEnter: No.");
                string decide = Console.ReadLine();

                if (decide == "1")
                {
                    _player.GetInventory().Gold += _merchant.GetInventory().Gold;
                    _merchant.GetInventory().Gold -= _merchant.GetInventory().Gold;

                    _player.GetInventory().Remove(choice);
                    _merchant.GetInventory().Add(_player.GetInventory().GetItemList[choice]);
                }
                else
                {
                    return;
                }
            }
        }

        

        //Displays options for the super user
        public void UserEditingMenu()
        {
            string choice = "";
            while (choice != "0")
            {
                Console.Clear();
                Console.WriteLine("This is the cheat fuction.... have fun.\n");
                Console.WriteLine("0: Exit User Editing\n1: Add\n2: Remove");

                choice = Console.ReadLine();

                if (choice == "0")
                {
                    return;
                }
                else if (choice == "1")
                {
                    AddMenu();
                }
                else if (choice == "2")
                {
                    RemoveMenu();
                }
            }
        }

        public void AddMenu()
        {

            string choice = "";

            while (choice != "0")
            {
                Console.Clear();
                Console.WriteLine("Where do you want to make something new at?\n0: Exit\n1: Shop \n2: Character");

                choice = Console.ReadLine();

                if (choice == "0")
                {
                    return;
                }
                else if (choice == "1")
                {
                    ShopAdd();
                }
                else if (choice == "2")
                {
                    PlayerAdd();
                }
            }
        }

        public void RemoveMenu()
        {

            string choice = "";

            while (choice != "0")
            {
                Console.Clear();
                Console.WriteLine("Where do you want to remove something from from?\n0: Exit\n1: Shop \n2: Player");

                choice = Console.ReadLine();

                if (choice == "0")
                {
                    return;
                }
                else if (choice == "1")
                {
                    ShopRemove();
                }
                else if (choice == "2")
                {
                    PlayerRemove();
                }
            }
        }

        //Allows the super user to add items and gold to the shop inventory
        public void ShopAdd()
        {
            Console.Clear();
            string choice = "";

            while (choice != "0")
            {
                Console.Clear();
                Console.WriteLine("What type of item do you want to make?\n0: Exit\n1: Armor\n2: Weapon\n3: Potion\n4: Gold");

                choice = Console.ReadLine();

                if (choice == "0")
                {
                    return;
                }
                else if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Too add some armor you need to \nCreate the armor's: 'Name', 'Defense stat, 'Gold value', and a 'Description'\nPress enter after each");
                    _merchant.GetInventory().Add(new Armor(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), 2, Console.ReadLine()));
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Console.WriteLine("To create a weapon you need to \nCreate the weapon's: 'Name', 'Damage stat', 'Gold vlaue', and a 'Description'\nPress enter after each");
                    _merchant.GetInventory().Add(new Weapon(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), 1, Console.ReadLine()));
                }
                else if (choice == "3")
                {
                    Console.Clear();
                    Console.WriteLine("To make a potion you need to \nCreate the potion's: 'Name', 'Healing', 'Gold value', and a 'Description' \nPress enter after each");
                    _merchant.GetInventory().Add(new Potions(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), 3, Console.ReadLine()));
                }
                else if (choice == "4")
                {
                    Console.Clear();
                    Console.WriteLine("How much gold do you want to give this merchant?");
                    Console.WriteLine("Gold Balance: " + _merchant.GetInventory().Gold + "\n");
                    int newGold = (Convert.ToInt32(Console.ReadLine()));
                    _merchant.GetInventory().Gold += newGold;
                }
            }

        }

        //Allows the super user to add items and gold to user inventory
        public void PlayerAdd()
        {
            string choice = "";

            while (choice != "0")
            {
                Console.Clear();
                Console.WriteLine("What kind of item do you want to make if any?\n0: Exit\n1: Armor\n2: Weapon\n3: Potion\n4: Gold");

                choice = Console.ReadLine();

                if (choice == "0")
                {
                    return;
                }
                else if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("To add some armor you need to \nCreate the armor's: 'Name', 'Defense stat, 'Gold value', and a 'Description'\nPress enter after each");

                    //Uses the add function of the player to add a new item into the player's inventory
                    _player.GetInventory().Add(new Armor(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), 2, Console.ReadLine()));
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Console.WriteLine("To create a weapon you need to \nCreate the weapon's: 'Name', 'Damage stat', 'Gold vlaue', and a 'Description'\nPress enter after each");

                    //Uses the add function of the player to add a new item into the player's inventory
                    _player.GetInventory().Add(new Weapon(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), 1, Console.ReadLine()));
                }
                else if (choice == "3")
                {
                    Console.Clear();
                    Console.WriteLine("To make a potion you need to \nCreate the potion's: 'Name', 'Healing', 'Gold value', and a 'Description' \nPress enter after each");

                    //Uses the add function of the player to add a new item into the player's inventory
                    _player.GetInventory().Add(new Potions(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), 3, Console.ReadLine()));
                }
                else if (choice == "4")
                {
                    Console.Clear();
                    Console.WriteLine("How much mons would you like to give yourself?");
                    Console.WriteLine("Gold Balance: " + _player.GetInventory().Gold + "\n");
                    int newGold = (Convert.ToInt32(Console.ReadLine()));

                    //Adds gold to the player
                    _player.GetInventory().Gold += newGold;
                }
            }
        }

        public void ShopRemove()
        {
            Console.Clear();

            Console.WriteLine("What have you had enough of seeing in the shop?");

            Console.WriteLine("0: Exit\n");

            //Iterates through the shop inventory array to display info to the user.
            for (int i = 0; i < _merchant.GetInventory().GetItemList.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + _merchant.GetInventory().GetItemList[i].GetName);
            }

            int choice = Convert.ToInt32(Console.ReadLine()) - 1;

            if (choice >= 0)
            {
                _merchant.GetInventory().Remove(choice);
            }
        }

        public void PlayerRemove()
        {
            Console.Clear();

            Console.WriteLine("What don't you want in your inventory?");

            Console.WriteLine("0: Exit\n");

            //Iterates through the shop inventory array to display info to the user.
            for (int i = 0; i < _player.GetInventory().GetItemList.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + _player.GetInventory().GetItemList[i].GetName);
            }

            int choice = Convert.ToInt32(Console.ReadLine()) - 1;

            if (choice >= 0)
            {
                _player.GetInventory().Remove(choice);
            }
        }
    }
}
