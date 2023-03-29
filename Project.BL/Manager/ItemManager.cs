
using Project.BL.Manager.IManager;
using Project.DAL.IRepository;
using Project.Model.Database;
using SampleProject.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Manager
    {
        public class ItemManager : IItemManager
    {
            private readonly IItemRepository _itemRepository;
            public ItemManager(IItemRepository itemRepository)
            {
                _itemRepository = itemRepository;
            }
            public IEnumerable<ItemVM> GetItems()
            {
                return _itemRepository.Get().Select(a => new ItemVM()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Price = a.Price,
                    
                });


            }
            //edit
            public void AddItem(ItemVM itemObj)
            {
                Item item = new Item()
                {
                    Id = itemObj.Id,
                    Name = itemObj.Name,
                    Price = itemObj.Price,
               
                };
                _itemRepository.Add(item);
                _itemRepository.SaveChanges();
            }
            /// <summary>
            /// Method To Edit item  by catching the id by method called GetId ....this is step 1  
            /// this method to show the record with a specific id (get id) 
            /// get data from database 
            /// /// </summary>

            public Item GetItem(int ItemId)
            {
                return _itemRepository.GetByID(ItemId);
            }
            /// <summary>
            /// after editing the record i will save the editing record in the database
            /// </summary>
            public void SaveItemAfterEditing(ItemVM itemVM)
            {
                var itemModel = _itemRepository.GetByID(itemVM.Id);
                itemModel.Name = itemVM.Name.Trim();
                itemModel.Price = itemVM.Price;
                _itemRepository.SaveChanges();
            }

            //delete 
            public void Delete(int ItemId)
            {
                _itemRepository.DeleteByID(ItemId);
                _itemRepository.SaveChanges();
            }



        }
    }
