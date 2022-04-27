using UHPYQ8_HFT_2021222.Models;
using System;
using System.Collections.Generic;

namespace UHPYQ8_HFT_2021222.Client
{
    class NonCrudService
    {
        private RestService rest;

        public NonCrudService(RestService rest)
        {
            this.rest = rest;
        }

        public void GameAVGPrice()
        {
            double price = rest.GetSingle<double>("Stat/GameAVGPrice");
            Console.WriteLine($"Average game price = [{price}]");
            Console.WriteLine("Press [ENTER]");
            Console.ReadLine();
        }
        public void GameAVGRating()
        {
            double price = rest.GetSingle<double>("Stat/GameAVGRating");
            Console.WriteLine($"Average game rating = [{price}]");
            Console.WriteLine("Press [ENTER]");
            Console.ReadLine();
        }

        public void PlatformICMoney()
        {
            var items = rest.Get<KeyValuePair<string, double>>("Stat/PlatformICMoney");
            Console.WriteLine("Platform\tIncoming Money");
            foreach (var item in items)
            {
                Console.WriteLine($"[{item.Key}] \t [{item.Value}]");
            }
            Console.WriteLine("Press [ENTER]");
            Console.ReadLine();
        }

        public void GameCountByPlatform()
        {
            var items = rest.Get<KeyValuePair<string, double>>("Stat/GameCountByPlatform");
            Console.WriteLine("Platform\tAvailable games (pieces)");
            foreach (var item in items)
            {
                Console.WriteLine($"[{item.Key}] \t [{item.Value}]");
            }
            Console.WriteLine("Press [ENTER]");
            Console.ReadLine();
        }

        public void AVGRatingByPlatform()
        {
            var items = rest.Get<KeyValuePair<string, double>>("Stat/AVGRatingByPlatform");
            Console.WriteLine("Platform\tAverage Rating");
            foreach (var item in items)
            {
                Console.WriteLine($"[{item.Key}] \t [{item.Value}]");
            }
            Console.WriteLine("Press [ENTER]");
            Console.ReadLine();
        }

        public void AVGPriceByPlatform()
        {
            var items = rest.Get<KeyValuePair<string, double>>("Stat/AVGPriceByPlatform");
            Console.WriteLine("Platform\tAverage Game's price");
            foreach (var item in items)
            {
                Console.WriteLine($"[{item.Key}] \t [{item.Value}]");
            }
            Console.WriteLine("Press [ENTER]");
            Console.ReadLine();
        }
        public void FindAllGameAtThisPlatform()
        {
            Console.Write("Which platform do u want to know?: ");
            string Platform = Console.ReadLine();
            var items = rest.Get<Game>("/Stat/FindAllGameAtThisPlatform/" + Platform);
            if (items.Count != 0)
            {
                Console.WriteLine("Games at this platform:");
                foreach (var item in items)
                {
                    Console.WriteLine("["+item.Title + "] \t [" + item.Price + "] Euro");
                }
                Console.WriteLine("Press [ENTER]");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("This platform does not exist");
                Console.WriteLine("Press [ENTER]");
                Console.ReadLine();
            }


        }
    }
}