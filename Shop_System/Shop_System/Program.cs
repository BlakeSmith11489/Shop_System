using System;

namespace Shop_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Hood Rat 1");
            Merchant merchant = new Merchant();
            Shop shop = new Shop(player, merchant);
            player.LoadPlayer("Player.txt");
            merchant.LoadMerchant("Shop.txt");
            if (player.GetName == "Hood Rat 1")
            {
                Console.WriteLine("Whats yo name fool?\n");
                player.GetName = Console.ReadLine();
            }
            shop.ShopMenu();
            player.SavePlayer("Player.txt");
            merchant.SaveMerchant("Shop.txt");
            Console.ReadKey();
        }
    }
}
