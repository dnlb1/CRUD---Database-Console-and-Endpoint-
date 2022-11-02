using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UHPYQ8_HFT_2022222.WPFClient.Logic;

namespace UHPYQ8_HFT_2022222.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public ICommand Games { get; set; }
        public ICommand Platforms { get; set; }
        public ICommand Publishers { get; set; }
        ISelectorLogic logic;

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel() : this(IsInDesignMode? null : Ioc.Default.GetService<ISelectorLogic>())
        {

        }
        public MainWindowViewModel(ISelectorLogic logic)
        {
            this.logic = logic;
            Games = new RelayCommand(() =>
            {
                logic.OpenGameEditor();
            });
            Platforms = new RelayCommand(() =>
            {
                logic.OpenPlatformEditor();
            });
            Publishers = new RelayCommand(() =>
            {
                logic.OpenPublisherEditor();
            });
        }
    }
}
