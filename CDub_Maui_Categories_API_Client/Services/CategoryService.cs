using CDub_Maui_Categories_API_Client.Models;

namespace CDub_Maui_Categories_API_Client.Services
{
    public class CategoryService : ICategoryService
    {
        IRestService _restService;

        public CategoryService(IRestService restService)
        {
            _restService = restService; 
        }

        public Task<List<Category>> GetAllCategories()
        {
            return _restService.RefreshDataAsync();
        }

        public Task SaveItemAsync(Category category, bool isNewItem = false)
        {
            if (category.Id == 0) 
            {
                isNewItem = true;
            };

            return _restService.SaveItemAsync(category, isNewItem);
        }
    }
}
