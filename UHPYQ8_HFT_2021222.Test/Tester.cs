using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UHPYQ8_HFT_2021222.Logic.Classes;
using UHPYQ8_HFT_2021222.Models;
using UHPYQ8_HFT_2021222.Repository.Interface;

namespace UHPYQ8_HFT_2021222.Test
{
    [TestFixture]
    public class Tester
    {
        GameLogic gameLogic;
        PlatformLogic platformLogic;
        PublisherLogic publisherLogic;
        Game_publisherLogic game_PubliserLogic;

        Mock<IRepository<Game>> mockGameRepo;
        Mock<IRepository<Platform>> mockPlatformRepo;
        Mock<IRepository<Publisher>> mockPublisherRepo;
        Mock<IRepository<Game_publisher>> mockGame_publisherRepo;
        [SetUp]
        public void Init()
        {
            mockPlatformRepo = new Mock<IRepository<Platform>>();
            mockGameRepo = new Mock<IRepository<Game>>();
            mockPublisherRepo = new Mock<IRepository<Publisher>>();
            mockGame_publisherRepo = new Mock<IRepository<Game_publisher>>();

            Platform fakePlatform = new Platform("1#Steam");
            Platform fakePlatform2 = new Platform("2#XBOX");

            var games = new List<Game>()
            {
                new Game()
                {
                    GameId = 1,
                    Platform = fakePlatform,
                    PlatformId = 1, //steam
                    Price = 1,
                    Rating = 3,
                    Title = "Lego Jumanji"
                },
                new Game()
                {
                    GameId = 2,
                    Platform = fakePlatform2,
                    PlatformId = 2, //xbox
                    Price = 1,
                    Rating = 3,
                    Title = "Lego Batman"
                },
                new Game()
                {
                    GameId = 3,
                    Platform = fakePlatform,
                    PlatformId = 1, //steam
                    Price = 1,
                    Rating = 3,
                    Title = "Lego Pirates of the Caribbean"
                }
            }.AsQueryable();
            var platforms = new List<Platform>()
            {
                new Platform()
                {
                    PlatformId = 1,
                    PlatformName = "Steam"
                },
                new Platform()
                {
                    PlatformId = 2,
                    PlatformName = "XBOX"
                }
            }.AsQueryable();
            var publishers = new List<Publisher>()
            {
                new Publisher()
                {
                    PublisherId = 1,
                    PublisherName = "Bela"
                }
            }.AsQueryable();
            var game_publishers = new List<Game_publisher>()
            {
                new Game_publisher()
                {
                    GP_Id = 1,
                    release_year = 1950
                }
            }.AsQueryable();

            mockGameRepo.Setup(t => t.ReadAll()).Returns(games);
            mockPlatformRepo.Setup(t => t.ReadAll()).Returns(platforms);
            mockPublisherRepo.Setup(t => t.ReadAll()).Returns(publishers);
            mockGame_publisherRepo.Setup(t => t.ReadAll()).Returns(game_publishers);


            gameLogic = new GameLogic(mockGameRepo.Object);
            platformLogic = new PlatformLogic(mockPlatformRepo.Object);
            publisherLogic = new PublisherLogic(mockPublisherRepo.Object);
            game_PubliserLogic = new Game_publisherLogic(mockGame_publisherRepo.Object);
        }

        //Free 1.
        [Test]
        public void GameAVGPriceTest()
        {
            var result = gameLogic.GameAVGPrice();
            //(1 + 1 + 1)/3 = 1 
            Assert.That(result, Is.EqualTo(1));
        }
        //Free 2.
        [Test]
        public void GameAVGRatingTest()
        {
            //(3+3+3)/3 = 3
            var result = gameLogic.GameAVGRating();
            Assert.That(result, Is.EqualTo(3));
        }

        //1. Game's Create method test with Exception
        [Test]
        public void CreateGameTestWithInCorrectTitle()
        {
            Game Gm = new Game();
            Gm.Title = "1";
            try
            {
                gameLogic.Create(Gm);
            }
            catch
            {
            }
            mockGameRepo.Verify(r => r.Create(Gm), Times.Never);

        }

        //2. Game's Create method test.
        [Test]
        public void CreateGameTestWithCorrectTitle()
        {
            Game Gm = new Game();
            Gm.Title = "Age of Empire IV";
            gameLogic.Create(Gm);
            mockGameRepo.Verify(r => r.Create(Gm), Times.Once);
        }

        //3. Platform's Create method test with Exception
        [Test]
        public void CreatePlatformTestWithInCorrectName()
        {
            Platform Pl = new Platform();
            Pl.PlatformName = "1";
            try
            {
                platformLogic.Create(Pl);
            }
            catch
            {
            }
            mockPlatformRepo.Verify(r => r.Create(Pl), Times.Never);
        }

        //4. Platform's Create method test
        [Test]
        public void CreatePlatformTestWithCorrectName()
        {
            Platform Pl = new Platform();
            Pl.PlatformName = "Steam";
            platformLogic.Create(Pl);
            mockPlatformRepo.Verify(r => r.Create(Pl), Times.Once);
        }

        //5. Publisher's Create method test with Exception
        [Test]
        public void CreatePublisherTestWithInCorrectName()
        {
            Publisher Pu = new Publisher();
            Pu.PublisherName = "";
            try
            {
                publisherLogic.Create(Pu);
            }
            catch
            {
            }
            mockPublisherRepo.Verify(r => r.Create(Pu), Times.Never);
        }

        //6. Publisher's Create method test
        [Test]
        public void CreatePublisherTestWithCorrectName()
        {
            Publisher Pu = new Publisher();
            Pu.PublisherName = "Mindegy_a_Nev";
            publisherLogic.Create(Pu);
            mockPublisherRepo.Verify(r => r.Create(Pu), Times.Once);
        }

        //7. Game_Publisher's Create method test Exception
        [Test]
        public void CreateGame_PublisherTestWithCorrectName()
        {
            Game_publisher GP = new Game_publisher();
            GP.release_year = 2000;
            game_PubliserLogic.Create(GP);
            mockGame_publisherRepo.Verify(r => r.Create(GP), Times.Once);
        }

        //8. Game_Publisher's Create method test
        [Test]
        public void CreateGame_PublisherTestWithInCorrectName()
        {
            Game_publisher GP = new Game_publisher();
            GP.release_year = 1920;
            try
            {
                game_PubliserLogic.Create(GP);
            }
            catch
            {
            }
            mockGame_publisherRepo.Verify(r => r.Create(GP), Times.Never);
        }
    }
}
