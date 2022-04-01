using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZH_Prep_2.Models;

namespace ZH_Prep_2.Logic
{
    public interface IComputerLogic
    {
        int AllCost { get; }
        void AddEditPart(ComputerPart part);
        void AddToCart(ComputerPart part);
        void RemoveFromCart(ComputerPart part);
        void SaveComputer(ObservableCollection<ComputerPart> computerParts);
        void SetupCollections(IList<ComputerPart> computerParts, IList<ComputerPart> cart, IList<Computer> computers);
    }
}
