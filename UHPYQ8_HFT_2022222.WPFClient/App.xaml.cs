using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UHPYQ8_HFT_2022222.WPFClient.Logic;

namespace UHPYQ8_HFT_2022222.WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(new ServiceCollection()
                .AddSingleton<ISelectorLogic, SelectorLogic>()
                .BuildServiceProvider());
        }
    }
}
