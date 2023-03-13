using CDub_Maui_Categories_API_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDub_Maui_Categories_API_Client.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();

        Task SaveItemAsync(Category category, bool isNewItem);

        Task DeleteItemAsync(Category category);

    }
}
