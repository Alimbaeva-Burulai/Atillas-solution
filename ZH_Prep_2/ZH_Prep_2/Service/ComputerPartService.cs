using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZH_Prep_2.Models;

namespace ZH_Prep_2.Service
{
    public class ComputerPartService : IComputerPartService
    {
        public void Edit(ComputerPart part)
        {
            new ComputerPartEditWindow(part).ShowDialog();
        }
    }
}
