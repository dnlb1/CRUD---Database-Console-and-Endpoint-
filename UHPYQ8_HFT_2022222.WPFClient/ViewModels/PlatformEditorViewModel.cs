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
    public class PlatformEditorViewModel : ObservableRecipient
    {
        public RestCollection<Platform> Platforms { get; set; }

        private Platform selectedplatform;

        public Platform SelectedPlatform
        {
            get { return selectedplatform; }
            set
            {
                if (value != null)
                {
                    selectedplatform = new Platform()
                    {
                        PlatformId = value.PlatformId,
                        PlatformName = value.PlatformName
                    };
                    OnPropertyChanged();
                    (DeletePlatformCommand as RelayCommand).NotifyCanExecuteChanged();
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

        public ICommand CreatePlatformCommand { get; set; }
        public ICommand DeletePlatformCommand { get; set; }
        public ICommand UpdatePlatformCommand { get; set; }
        public PlatformEditorViewModel()
        {
            if (!IsInDesignMode)
            {

                Platforms = new RestCollection<Platform>("http://localhost:51783/", "Platform", "hub");

                CreatePlatformCommand = new RelayCommand(() =>
                {
                    Platforms.Add(new Platform()
                    {
                        PlatformName = SelectedPlatform.PlatformName
                    });
                }
                );

                UpdatePlatformCommand = new RelayCommand(() =>
                {
                    Platforms.Update(SelectedPlatform);
                });

                DeletePlatformCommand = new RelayCommand(() =>
                {
                    Platforms.Delete(SelectedPlatform.PlatformId);
                },
                () =>
                {
                    return SelectedPlatform != null;
                });
                SelectedPlatform = new Platform();
            }
        }
    }
}
