using ConsoleTools;
using System;
using UHPYQ8_HFT_2021222.Models;

namespace UHPYQ8_HFT_2021222.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService rest = new RestService("http://localhost:51783/", typeof(Game).Name);
            CrudService crud = new CrudService(rest);
            NonCrudService nonCrud = new NonCrudService(rest);

            //Crud method Game-nak
            var gameSubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => crud.List<Game>())
               .Add("Create", () => crud.Create<Game>())
               .Add("Delete", () => crud.Delete<Game>())
               .Add("Update", () => crud.Update<Game>())
               .Add("Exit", ConsoleMenu.Close);

            //Crud Method Platformnak-nak
            var platformSubMenu = new ConsoleMenu(args, level: 1)
                 .Add("List", () => crud.List<Platform>())
                 .Add("Create", () => crud.Create<Platform>())
                 .Add("Delete", () => crud.Delete<Platform>())
                 .Add("Update", () => crud.Update<Platform>())
                 .Add("Exit", ConsoleMenu.Close);

            //Crud method Publisher-nek
            var publisherSubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => crud.List<Publisher>())
               .Add("Create", () => crud.Create<Publisher>())
               .Add("Delete", () => crud.Delete<Publisher>())
               .Add("Update", () => crud.Update<Publisher>())
               .Add("Exit", ConsoleMenu.Close);

            //Crud method Game_Publisher-nek
            var Game_publishers_SubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => crud.List<Game_publisher>())
               .Add("Create", () => crud.Create<Game_publisher>())
               .Add("Delete", () => crud.Delete<Game_publisher>())
               .Add("Update", () => crud.Update<Game_publisher>())
               .Add("Exit", ConsoleMenu.Close);

            //NonCrud Methods
            var statsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Average game price", () => nonCrud.GameAVGPrice())
                .Add("Average game rating", () => nonCrud.GameAVGRating())
                .Add("Platform / Income money", () => nonCrud.PlatformICMoney())
                .Add("Platform / Available games (pieces)", () => nonCrud.GameCountByPlatform())
                .Add("Platform / Average Rating", () => nonCrud.AVGRatingByPlatform())
                .Add("Platform / Average Game's price", () => nonCrud.AVGPriceByPlatform())
                .Add("Games at this platform:", () => nonCrud.FindAllGameAtThisPlatform())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Games", () => gameSubMenu.Show())
                .Add("Platforms", () => platformSubMenu.Show())
                .Add("Publishers", () => publisherSubMenu.Show())
                .Add("Game_publishers", () => Game_publishers_SubMenu.Show())
                .Add("Statistics", () => statsSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);


            menu.Show();
        }
    }
}
