using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZH_Prep_2.Models;

namespace ZH_Prep_2.ViewModels
{
    public class ComputerPartEditWindowVM
    {
        public ComputerPart Actual { get; set; }
        public void Setup(ComputerPart part)
        {
            Actual = part;
        }
        public ComputerPartEditWindowVM()
        {
                
        }
    }
}
