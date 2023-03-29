using Project.Model.Database;
using SampleProject.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Manager.IManager
    {
        public interface IItemManager
        {
            void Delete(int itemId);
            void AddItem(ItemVM itemVM);
            Item GetItem(int itemId);
            void SaveItemAfterEditing(ItemVM itemVm);
            IEnumerable<ItemVM> GetItems();

        }
    }
