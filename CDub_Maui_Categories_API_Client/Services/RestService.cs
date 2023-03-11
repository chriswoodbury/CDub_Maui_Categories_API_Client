using System.Diagnostics;
using System.Text;
using CDub_Maui_Categories_API_Client.Models;
using System.Text.Json;


namespace CDub_Maui_Categories_API_Client.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        IHttpsClientHandlerService _httpsClientHandlerService;

        public List<Category> Items { get; private set; }

        public RestService(IHttpsClientHandlerService service)
        {
            _httpsClientHandlerService= service;    
            
            _client = new HttpClient();

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Category>> RefreshDataAsync()
        {
            Items = new List<Category>();

            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<Category>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items.OrderBy(o => o.DisplayOrder).ToList();
               
        }

        public async Task SaveItemAsync(Category category, bool isNewItem)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<Category>(category, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                    response = await _client.PostAsync(uri, content);
                else
                    response = await _client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tCategory successfully saved.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
