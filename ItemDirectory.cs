using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Ramadhan_Discount_System
{
    public class ItemDirectory
    {
        private Dictionary<string, List<Items>> _categories;
        //private Dictionary<int, List<Items>> _bundles;

        public ItemDirectory()
        {
            _categories = new Dictionary<string, List<Items>>();
           // _bundles = new Dictionary<int, List<Items>>();
        }

        


        // Add items with Categories.
        public void AddItemToCategory(string category, Items item)
        {
            if (!_categories.ContainsKey(category))
            {
                _categories[category] = new List<Items>();
            }
            if (isValidItemID(item.ItemId))
            {
            _categories[category].Add(item);
                Console.WriteLine($"Successfully Add item {item.ItemName}");
            }
            else
            {
                Console.WriteLine($"Can't add {item.ItemName} because the item ID already exists.\n");
            }
        }

        public void RemoveItemFromCategory(string category, string ItemId)
        {
            if (_categories.ContainsKey(category))
            {
                // Find the item in the category based on its ItemId
                Items itemToRemove = _categories[category].FirstOrDefault(item => item.ItemId == ItemId);

                // Check if the item exists in the category
                if (itemToRemove != null)
                {
                    // Remove the item from the category
                    _categories[category].Remove(itemToRemove);
                    Console.WriteLine($"Successfully removed item with ID {ItemId} from category {category}.");
                }
                else
                {
                    Console.WriteLine($"Item with ID {ItemId} not found in category {category}.");
                }
            }
            else
            {
                Console.WriteLine($"Category {category} not found.");
            }
        }

        public Items FindItem(string category, Items item)
        {
            if (_categories.ContainsKey(category))
            {
                foreach (var i in _categories[category])
                {
                    if (i == item)
                    {
                        return i;
                    }
                }
                // If the item is not found within the category
                Console.WriteLine("Item not found in category: " + category);
            }
            else
            {
                Console.WriteLine("Category not found: " + category);
            }

            return null; // Return -1 to indicate item or category not found
        }


        // Check if item id is already Exist.
        public bool isValidItemID(string id)
        {
            foreach (var category in _categories)
            {
                foreach (var item in category.Value)
                {
                    // Access the item ID and compare it with the provided ID
                    if (item.ItemId == id)
                    {
                        // If the ID matches, it is a duplicate
                        return false;
                    }
                }
            }
            // If the ID is not found in any category, it is valid
            return true;
        }

        public Dictionary<string, List<Items>> GetItemsByCategory()
        {
            return _categories;
        }

        // Display All Items along with Categories.
        public void DisplayAllItemsByCategory(bool includeStockInfo)
        {
            foreach (var category in _categories)
            {
                Console.WriteLine($"{category.Key}:");
                foreach (var item in category.Value)
                {
                    item.DisplayItemsInformation(includeStockInfo);
                }
                Console.WriteLine();
            }
        }

        public void DisplayItemsOfCategory(bool includeStockInfo,string category)
        {
            if (_categories.ContainsKey(category))
            {
                Console.WriteLine($"{category}: ");
                foreach (var item in _categories[category])
                {
                    item.DisplayItemsInformation(includeStockInfo);
                }
            }
            else
            {
                Console.WriteLine($"Category '{category}' not found.");
            }
            Console.WriteLine();
        }

    }
}




/*
    // Bundles information

public void AddBundleToItems(int bundle_id, List<Items> items)
        {
            if (_bundles.ContainsKey(bundle_id))
            {
                foreach (Items item in items)
                {
                    if (isValidItemID(item.ItemId))
                    {
                        _bundles[bundle_id].Add(item);
                        Console.WriteLine($"Item {item.ItemName} added to Bundle ID {bundle_id}");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid item ID: {item.ItemId}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Bundle ID {bundle_id} not found.");
            }
        }

        public void DisplayAllBundles(bool isStock)
        {
            if(_bundles.Count > 0)
            {
                foreach(var bundles in _bundles)
                {
                    Console.WriteLine($"Bundle {bundles.Key}");

                    foreach(var item in bundles.Value)
                    {
                        item.DisplayItemsInformation(isStock);
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine(" No any bundle Found ");
            }
        }

        public void RemoveBundleFromItems(int bundle_id)
        {
            if (_bundles.ContainsKey(bundle_id))
            {
                // Get the list of items in the bundle
                List<Items> itemsToRemove = _bundles[bundle_id];

                // Remove each item from the bundle
                foreach (Items item in itemsToRemove)
                {
                    _bundles[bundle_id].Remove(item);
                }

                // Finally, remove the bundle itself
                _bundles.Remove(bundle_id);
                Console.WriteLine($"Bundle ID {bundle_id} and all its items removed successfully.");
            }
            else
            {
                Console.WriteLine($"Bundle ID {bundle_id} not found.");
            }
        }

 
 */
