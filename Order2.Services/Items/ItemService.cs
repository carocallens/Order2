using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Order2.API.Services.Items;
using Order2.Data;
using Order2.Data.Exception;
using Order2.Domain.Exceptions;
using Order2.Domain.Items;

namespace Order2.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly Order2DbContext _context;

        public ItemService(Order2DbContext context)
        {
            _context = context;
        }

        public Item CreateItem(Item item)
        {
            if(!ItemValidator.ItemIsValid(item))
            {
                throw new InvalidObjectException("The given item is not valid");
            }

            _context.Add(item);
            _context.SaveChanges();

            return item;
        }

        public List<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItem(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.ItemID == id);
            if(item == null)
            {
                throw new ObjectNotFoundException("This item does not exist");
            }

            return item;
        }
    }
}
