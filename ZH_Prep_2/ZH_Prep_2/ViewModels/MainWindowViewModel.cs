using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ZH_Prep_2.Logic;
using ZH_Prep_2.Models;

namespace ZH_Prep_2.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IComputerLogic logic;
        public ObservableCollection<Computer> Computers { get; set; }
        public ObservableCollection<ComputerPart> ComputerParts { get; set; }
        public ObservableCollection<ComputerPart> ComputerToBuy { get; set; }
        private ComputerPart selectedFromAll;
        public ComputerPart SelectedFromAll
        {
            get { return selectedFromAll; }
            set
            {
                SetProperty(ref selectedFromAll, value);
                (AddEditCommand as RelayCommand).NotifyCanExecuteChanged();
                (AddToCartCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        private ComputerPart selectedFromCart;
        public ComputerPart SelectedFromCart
        {
            get { return selectedFromCart; }
            set
            {
                SetProperty(ref selectedFromCart, value);
                (RemoveFromCartCommand as RelayCommand).NotifyCanExecuteChanged();
                (ComputerSaveCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        private Computer selectedComputer;
        public Computer SelectedComputers
        {
            get { return selectedComputer; }
            set
            {
                SetProperty(ref selectedComputer, value);
            }
        }
        public ICommand AddEditCommand { get; set; }
        public ICommand RemoveFromCartCommand { get; set; }
        public ICommand AddToCartCommand { get; set; }
        public ICommand ComputerSaveCommand { get; set; }
        public int AllCost
        {
            get
            {
                return logic.AllCost;
            }
        }
        public static bool IsInDesignerMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel(): this(IsInDesignerMode? null : Ioc.Default.GetService<IComputerLogic>())
        {

        }
        public MainWindowViewModel(IComputerLogic logic)
        {
            this.logic = logic;
            ComputerParts = new ObservableCollection<ComputerPart>();
            ComputerToBuy = new ObservableCollection<ComputerPart>();
            Computers = new ObservableCollection<Computer>();
            var all = File.ReadLines("computerpart.txt");
            foreach (var item in all)
            {
                ComputerPart computerPartTemp = new ComputerPart();
                string[] lineParts = item.Split(',');
                computerPartTemp.Identifier = lineParts[0];
                computerPartTemp.Brand = lineParts[1];
                computerPartTemp.Price = Convert.ToInt32(lineParts[2]);
                computerPartTemp.Category = lineParts[3];
                ComputerParts.Add(computerPartTemp);
            }
            logic.SetupCollections(ComputerParts, ComputerToBuy, Computers);

            AddEditCommand = new RelayCommand(
                ()=>logic.AddEditPart(SelectedFromAll),
                ()=>SelectedFromAll != null 
                );
            AddToCartCommand = new RelayCommand(
                () => logic.AddToCart(SelectedFromAll),
                () => SelectedFromAll != null
                );
            RemoveFromCartCommand = new RelayCommand(
                () => logic.RemoveFromCart(SelectedFromCart),
                () => SelectedFromCart != null
                );
            ComputerSaveCommand = new RelayCommand(
                () => logic.SaveComputer(ComputerToBuy),
                () => ComputerToBuy != null
                );
        }
    }
}
