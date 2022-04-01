using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH_Prep_2.Models
{
    public class ComputerPart : ObservableObject
    {
        private string identifier;
        public string Identifier
        {
            get { return identifier; }
            set { SetProperty(ref identifier, value); }
        }
        private string brand;
        public string Brand
        {
            get { return brand; }
            set { SetProperty(ref brand, value); }
        }
        private int price;
        public int Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }
        private string category;
        public string Category
        {
            get { return category; }
            set { SetProperty(ref category, value); }
        }
    }
}
