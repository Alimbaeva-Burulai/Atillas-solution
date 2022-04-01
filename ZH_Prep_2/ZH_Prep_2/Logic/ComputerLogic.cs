using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZH_Prep_2.Models;
using ZH_Prep_2.Service;

namespace ZH_Prep_2.Logic
{
    class ComputerLogic : IComputerLogic
    {
        IList<Computer> computers;
        IList<ComputerPart> computerparts;
        IList<ComputerPart> cart;
        IMessenger messenger;
        IComputerPartService computerPartService;

        public ComputerLogic(IMessenger messenger, IComputerPartService editorService)
        {
            this.messenger = messenger;
            this.computerPartService = editorService;
        }
        public int AllCost
        {
            get
            {
                return cart.Count == 0 ? 0 : cart.Sum(x => x.Price);
            }
        }

        public void AddEditPart(ComputerPart part)
        {
            computerPartService.Edit(part);
        }

        public void AddToCart(ComputerPart part)
        {
            cart.Add(part);
            computerparts.Remove(part);
            messenger.Send("part removed from cart", "PartInfo");
        }

        public void RemoveFromCart(ComputerPart part)
        {
            computerparts.Add(part);
            cart.Remove(part);
            messenger.Send("part added to cart", "PartInfo");
        }

        public void SaveComputer(ObservableCollection<ComputerPart> computerParts)
        {
            computers.Add(new Computer{
                ComputerParts = new List<ComputerPart>(computerParts),
                SumPrice = AllCost 
            });
            cart.Clear();
        }

        public void SetupCollections(IList<ComputerPart> computerParts, IList<ComputerPart> cart, IList<Computer> computers)
        {
            this.computerparts = computerParts;
            this.cart = cart;
            this.computers = computers;
        }
    }
}
