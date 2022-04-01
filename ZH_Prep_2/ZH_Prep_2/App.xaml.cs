using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ZH_Prep_2.Logic;
using ZH_Prep_2.Service;

namespace ZH_Prep_2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<IComputerLogic, ComputerLogic>()
                .AddSingleton<IComputerPartService, ComputerPartService>()
                .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                .BuildServiceProvider());
        }
    }
}
