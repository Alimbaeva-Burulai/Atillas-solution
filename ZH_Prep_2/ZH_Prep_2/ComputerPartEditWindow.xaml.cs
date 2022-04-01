using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZH_Prep_2.Models;
using ZH_Prep_2.ViewModels;

namespace ZH_Prep_2
{
    /// <summary>
    /// Interaction logic for ComputerPartEditWindow.xaml
    /// </summary>
    public partial class ComputerPartEditWindow : Window
    {
        public ComputerPartEditWindow(ComputerPart part)
        {
            InitializeComponent();
            var viewmodel = new ComputerPartEditWindowVM();
            viewmodel.Setup(part);
            DataContext = viewmodel;
        }

        private void Edit_click(object sender, RoutedEventArgs e)
        {
            string first = IDbox.Text.Substring(0, 2); //"00"
            string second = IDbox.Text.Substring(2, 2); //"MM"
            string third = IDbox.Text.Substring(4, 2); //"22"
            if (first.All(char.IsDigit) == false || second.All(char.IsDigit) == true || third.All(char.IsDigit) == false || IDbox.Text.Length > 6)
            {
                MessageBox.Show("The Given text has wrong format, please fix it");
            }
            else
            {
                foreach (var item in stackpanel.Children)
                {
                    if (item is TextBox t)
                    {
                        t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    }
                }
                this.DialogResult = true;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stackpanel.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
                }
            }
            this.DialogResult = true;
        }
    }
}
