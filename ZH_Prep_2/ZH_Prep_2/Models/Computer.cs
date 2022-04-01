using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH_Prep_2.Models
{
    public class Computer : ObservableObject
    {
        private List<ComputerPart> computerParts;
        public List<ComputerPart> ComputerParts
        {
            get { return computerParts; }
            set { SetProperty(ref computerParts, value); }
        }
        private int sumPrice;
        public int SumPrice
        {
            get { return sumPrice; }
            set { SetProperty(ref sumPrice, value); }
        }

        public Computer GetCopy()
        {
            return new Computer()
            {
                ComputerParts = this.ComputerParts,
                SumPrice = this.SumPrice
            };
        }
    }
}
