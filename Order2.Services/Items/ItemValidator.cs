using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Order2.Domain.Items;

namespace Order2.API.Services.Items
{
    public class ItemValidator
    {
        internal static bool ItemIsValid(Item item)
        {
            if(string.IsNullOrWhiteSpace(item.Name) ||
                    string.IsNullOrWhiteSpace(item.Description) ||
                item.Price < 0 ||
                item.Amount < 0)
            {
                return false;
            }

            return true;
        }
    }
}
