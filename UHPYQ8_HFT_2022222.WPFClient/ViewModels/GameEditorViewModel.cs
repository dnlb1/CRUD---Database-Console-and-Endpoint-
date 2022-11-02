using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UHPYQ8_HFT_2021222.Models;

namespace UHPYQ8_HFT_2022222.WPFClient
{
    public class GameEditorViewModel : ObservableRecipient
    {
        public RestCollection<Game> Games { get; set; }

        private Game selectedgame;

        public Game SelectedGame
        {
            get
            {
                return selectedgame;
            }
            set
            {
                if (value != null)
                {
                    selectedgame = new Game()
                    {
                        GameId = value.GameId,
                        Price = value.Price,
                        Rating = value.Rating,
                        PlatformId = value.PlatformId,
                        Title = value.Title
                    };
                    OnPropertyChanged();
                    (DeleteGameCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }



        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ICommand CreateGameCommand { get; set; }
        public ICommand DeleteGameCommand { get; set; }
        public ICommand UpdateGameCommand { get; set; }
        public GameEditorViewModel()
        {

            if (!IsInDesignMode)
            {

                Games = new RestCollection<Game>("http://localhost:51783/", "Game", "hub");

            CreateGameCommand = new RelayCommand(() =>
            {
                Games.Add(new Game()
                {
                    Title = SelectedGame.Title,
                    Price = SelectedGame.Price,
                    PlatformId = SelectedGame.PlatformId
                });
            }
            );

            UpdateGameCommand = new RelayCommand(() =>
            {
                Games.Update(SelectedGame);
            });

            DeleteGameCommand = new RelayCommand(() =>
            {
                Games.Delete(SelectedGame.GameId);
            },
            () =>
            {
                return SelectedGame != null;
            });
            SelectedGame = new Game() { Title = "" };
            }
        }
    }
}
