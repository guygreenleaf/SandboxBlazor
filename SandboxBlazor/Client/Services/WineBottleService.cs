using SandboxBlazor.Shared.Models;
using System.Net.Http.Json;

namespace SandboxBlazor.Client.Services
{
    public class WineBottleService : IWineBottleService
    {

        public readonly HttpClient _httpClient;

        public WineBottleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<WineBottle>?> GetAllWineBottles() 
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<WineBottle>>("api/WineBottle/AllBottles");

                return res;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        public async Task<WineBottle?> GetWineBottleBySku(string sku) 
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<WineBottle>($"api/WineBottle/BySku/{sku}");

                return res;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }



        public async Task<long?> InsertWineBottle(WineBottle newWineBottle)
        {
            try
            {
                var responseID = await _httpClient.PostAsJsonAsync("api/WineBottle/Insert", newWineBottle);

                var returnID = await responseID.Content.ReadFromJsonAsync<long>();

                return returnID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
